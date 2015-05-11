function Disable-InternetExplorerESC {
    $AdminKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}"
    $UserKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}"

    if ( (Get-ItemProperty -Path $AdminKey).IsInstalled -eq "1" ) {
        Set-ItemProperty -Path $AdminKey -Name "IsInstalled" -Value 0
        Set-ItemProperty -Path $UserKey -Name "IsInstalled" -Value 0
        Stop-Process -Name Explorer -Force
        Write-Host "IE Enhanced Security Configuration (ESC) has been disabled." -ForegroundColor Green
    }
}
function Enable-InternetExplorerESC {
    $AdminKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}"
    $UserKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}"

    if ( (Get-ItemProperty -Path $AdminKey).IsInstalled -eq "0" ) {
        Set-ItemProperty -Path $AdminKey -Name "IsInstalled" -Value 1
        Set-ItemProperty -Path $UserKey -Name "IsInstalled" -Value 1
        Stop-Process -Name Explorer -force
        Write-Host "IE Enhanced Security Configuration (ESC) has been enabled." -ForegroundColor Green
    }
}
function Disable-UserAccessControl {
    Set-ItemProperty "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" -Name "ConsentPromptBehaviorAdmin" -Value 00000000
    Write-Host "User Access Control (UAC) has been disabled." -ForegroundColor Green    
}
function Enable-AutoAdminLogon {
    param (
    [string]$user,
    [string]$pass
    )
     
    $autoLogonFlag = (Get-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon' -ErrorAction SilentlyContinue)

    if ($autoLogonFlag.AutoAdminLogon -ne "1") {
        Write-Host "Enabling Auto admin logon"
        New-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon' -Name DefaultUserName -Value $user -ErrorAction SilentlyContinue
        New-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon' -Name DefaultPassword -Value $pass -ErrorAction SilentlyContinue

        Set-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon' -Name AutoAdminLogon -Value 1 -ErrorAction SilentlyContinue
        Set-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon' -Name DefaultUserName -Value $user -ErrorAction SilentlyContinue
        Set-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon' -Name DefaultPassword -Value $pass -ErrorAction SilentlyContinue
            
        #TODO: Make sure that SQL install is not running! Or post Caas deployment config scripts.

        #Reboot - if we made a change to the settings
        #Restart-Computer -ComputerName localhost -Force
        return $true
    } else {
        Write-Verbose "AutoAdmin logon is already enabled. Skipping this step"
        return $false
    }

}

# copy and run the backup client install file to download the server
function Install-BackupClientOnWindowsMachine($dLink, $bForceRedownload = $false, $bInstallClient = $false)
{
    $dest = "$env:HOMEDRIVE\$env:HOMEPATH\Desktop\CloudBackupInstaller.msi"

    if($dLink -eq $null) {
        Write-Host "Downloading link is null - cannot get Cloud Backup client for download and install" -ForegroundColor Red
        return
    }

    if( (Get-Command $dest) -eq $null -or $bForceRedownload -eq $true) {
        Write-Host "Downloading Cloud Backup Client ... " -NoNewline

        $client = new-object System.Net.WebClient
        $client.DownloadFile( $dLink, $dest)

        Write-Host "Done!" -ForegroundColor Green
    }

    if($bInstallClient -eq $true) {

        $apps = (Get-WmiObject -Class win32_product |where { $_.Name -like "*Cloud Backup*"})

        if ($apps -eq $null) {
            Write-Host "Installing Cloud Backup client..." -NoNewline
            & msiexec /i $dest /qn
            Write-Host "Done!" -ForegroundColor Green
        } else { 
            Write-Host "Cloud Backup is already installed ... not going to re-install. You will need to remove the client and add it back to re-install"
        }
    }
}
function Install-BackupClient {
	param (
		[string] $publicIp,
		[string] $adminPassword,
		[string] $windowLocalAdminUser = "administrator"
		)
		$Global:cred = New-Object System.Management.Automation.PSCredential -ArgumentList @($windowLocalAdminUser,(ConvertTo-SecureString -String $adminPassword -AsPlainText -Force))
        $s = New-PSSession -Computername $publicIp -Credential $Global:cred -Authentication Default -ErrorAction SilentlyContinue

        #If starting PS session fails - Enable PS PSRemoting and rety
        if($s -eq $null) {
            Write-Host "Enabling Powershell Remoting - Does not work in 2003/8" -ForegroundColor Yellow
            $argString = "\\$publicIp -u $windowLocalAdminUser -p " + $adminPassword + " -c -f -h $suportFilesFolder\enablePSRemoting.cmd"
            Start-Process -PassThru -Wait $psexec $argString
            $s = New-PSSession -Computername $publicIp -Credential $Global:cred -Authentication Default -ErrorAction SilentlyContinue

            if($s -eq $null) {
                Write-Host "Cannot enable PSRemoting on machine ... Skipping config on machine " -ForegroundColor Red
                break
            }
        }

        #TODO: This could be modified to run parallel on all windows machines at once

        $result = Invoke-Command -Session $s -ScriptBlock ${function:Enable-AutoAdminLogon} -ArgumentList $windowLocalAdminUser, $adminPassword

        if($result -eq $true) {
            Restart-Computer -ComputerName $publicIp -Wait -Credential $Global:cred -Force
            $s = New-PSSession -Computername $publicIp -Credential $Global:cred -Authentication Default -ErrorAction SilentlyContinue
        }
        
        #Disable IE Enhanced security to allow download of backup client etc.
        Invoke-Command -Session $s -ScriptBlock ${function:Disable-InternetExplorerESC} -Debug
        Invoke-Command -Session $s -ScriptBlock ${function:Install-BackupClientOnWindowsMachine} -ArgumentList $dLink, $false, $true -ErrorVariable errorText
        
        Write-Host "Done processing windows machine: $vmName"
}

Export-ModuleMember -Function Disable-UserAccessControl, Install-BackupClientOnWindowsMachine, Install-BackupClient, Enable-AutoAdminLogon, Disable-UserAccessControl, Disable-InternetExplorerESC, Enable-InternetExplorerESC