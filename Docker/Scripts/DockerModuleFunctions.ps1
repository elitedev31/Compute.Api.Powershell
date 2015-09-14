function New-CaasDockerHost
{
   param(
        [Parameter(Mandatory=$true)]
		[string] $Name,
        [Parameter(Mandatory=$true)]
		[string] $NetworkName,
        [Parameter(Mandatory=$true)]
		[string] $RootPassword	
	)   
    # picking 14.04 makes installing docker much easier
    $osimagename = "Ubuntu 14.04 2 CPU"

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
    $server = New-CaasServer -ServerDetails $serverdetails -PassThru | Wait-CaasServerOperation
   
    if (-Not $server){
		Write-Error "Failed to create server"
		return;
	}
   
    # Write-Verbose "Creating server with id : $($server.id)" 
    # Get-CaasServers -ServerId $server.id | Wait-CaasServerOperation

	#Add firewall/ACL rule to permit TCP traffic on port 22 from any network(SSH)
    #    New-CaasAclRule -AclRuleName "AllowSSHPort22" -Network $network -Position 120 -DestinationIpAddress $server.nic[0].privateIpv4 -Action PERMIT -Protocol TCP -PortRangeType EQUAL_TO -Port1 22 -AclType OUTSIDE_ACL  -ErrorAction SilentlyContinue
    
    #SSH onto the server
    $sshusername = "root"
    $sshpassword = convertto-securestring $RootPassword -asplaintext -force
    $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $sshusername, $sshpassword
    Remove-SSHSession -SessionId 0
    Write-Host "SSHing into ..." $server.nic[0].privateIpv4    
    New-SSHSession -ComputerName $server.nic[0].privateIpv4 -Credential $cred -AcceptKey 
    $output = Invoke-SSHCommand -Command "wget -qO- https://get.docker.com/ | sh" -SessionId 0 -TimeOut 3600
    Remove-SSHSession -SessionId 0
    Write-host $output
    Write-Host "Docker container setup done." $server.nic[0].privateIpv4
}

function Invoke-CaasDockerContainer
{
   param(
        [Parameter(Mandatory=$true)]
		[string] $Name,
        [Parameter(Mandatory=$true)]		
        [string] $NetworkName,
		[string] $Parameters = "",
        [Parameter(Mandatory=$true)]
        [string] $RootPassword			
	)      
	
    #Get the network with a specific name
    Write-Host "Trying to find the network $NetworkName"
    $network=Get-CaasNetworks -Name $NetworkName
 
    #Find the first docker host
    $servers = Get-CaasServers -Network $network
    
    foreach ($server in $servers){   
        if ($server.description -like "##dockerhost##"){
            $hostServer = $server;
            break;
        }
    }

	if (-Not $hostServer){
		Write-Error "Cannot find Docker host in $NetworkName"
		return;
	}
	
    #SSH onto the server
    $sshusername = "root"
    $sshpassword = convertto-securestring $RootPassword -asplaintext -force
    $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $sshusername, $sshpassword
    Remove-SSHSession -SessionId 0
    Write-Host "SSHing into ..." $hostServer.nic[0].privateIpv4      
    New-SSHSession -ComputerName $hostServer.nic[0].privateIpv4   -Credential $cred -AcceptKey 
    $output = Invoke-SSHCommand -Command "docker run $Parameters $Name"  -SessionId 0 -TimeOut 3600
    Remove-SSHSession -SessionId 0
    Write-host $output
}