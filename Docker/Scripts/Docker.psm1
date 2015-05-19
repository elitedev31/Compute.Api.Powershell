function New-CaasDockerContainer
{
   param(
		[string] $Name,
		[string] $NetworkName,
		[string] $RootPassword		
	)   
    # picking 14.04 makes installing docker much easier
    $osimagename = "Ubuntu 14.04 2 CPU"

    Import-Module Posh-SSH
    #Get the network with a specific name
    Write-Host "Trying to find the network $NetworkName"
    $network=Get-CaasNetworks -Name $NetworkName

    #Get a OS image with a specific name 
    Write-Host "Trying to find the OS image $osimagename"
    $os=Get-CaasOsImages -Network $network -Name $osimagename

    #create a new server details configuration
    $serverdetails = New-CaasServerDetails -Name $Name  -AdminPassword $RootPassword -IsStarted $True -OsServerImage $os -Network $network -Description "##dockerhost##"
    #set the the disk speed on the server to be provisioned. Disk speeds can retrieved by (Get-CaasDataCentre).hypervisor.diskSpeed
    $serverdetails = Set-CaasServerDiskDetails -ServerDetails $serverdetails -ScsiId 0 -SpeedId "HIGHPERFORMANCE"
    Write-Host "Trying to create docker host container server $Name"
    $server = New-CaasServer -ServerDetails $serverdetails -PassThru | Out-CaasWaitForOperation

    #Add firewall/ACL rule to permit TCP traffic on port 22 from any network(SSH)
    New-CaasAclRule -AclRuleName "AllowSSHPort22" -Network $network -Position 120 -DestinationIpAddress $server.privateIp -Action PERMIT -Protocol TCP -PortRangeType EQUAL_TO -Port1 22 -AclType OUTSIDE_ACL  -ErrorAction SilentlyContinue

    #SSH onto the server
    $sshusername = "root"
    $sshpassword = convertto-securestring $RootPassword -asplaintext -force
    $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $sshusername, $sshpassword
    Remove-SSHSession -SessionId 0
    Write-Host "SSHing into ..." $server.privateIp    
    New-SSHSession -ComputerName $server.privateIp -Credential $cred -AcceptKey 
    $output = Invoke-SSHCommand -Command "wget -qO- https://get.docker.com/ | sh" -SessionId 0 -TimeOut 3600
    Remove-SSHSession -SessionId 0
    Write-host $output
    Write-Host "Docker container setup done." $server.privateIp
}

function Run-CaasDockerApp
{
   param(
		[string] $Name,
		[string] $NetworkName,
		[string] $Parameters = "",
        [string] $RootPassword			
	)      
    Import-Module Posh-SSH
    #Get the network with a specific name
    Write-Host "Trying to find the network $NetworkName"
    $network=Get-CaasNetworks -Name $NetworkName
 
    #Find the first docker host
    $servers = Get-CaasDeployedServer -Network $network
    
    foreach ($server in $servers){   
        if ($server.description -like "##dockerhost##"){
            $hostServer = $server;
            break;
        }
    }

    #SSH onto the server
    $sshusername = "root"
    $sshpassword = convertto-securestring $RootPassword -asplaintext -force
    $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $sshusername, $sshpassword
    Remove-SSHSession -SessionId 0
    Write-Host "SSHing into ..." $hostServer.privateIp    
    New-SSHSession -ComputerName $hostServer.privateIp -Credential $cred -AcceptKey 
    $output = Invoke-SSHCommand -Command "docker run $Parameters $Name"  -SessionId 0 -TimeOut 3600
    Remove-SSHSession -SessionId 0
    Write-host $output
}