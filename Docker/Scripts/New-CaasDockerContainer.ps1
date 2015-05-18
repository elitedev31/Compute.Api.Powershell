$servername = "DockerHost"
$networkname = "Innovation Lab"
# picking 14.04 makes installing docker much easier
$osimagename = "Ubuntu 14.04 2 CPU" 
$administratorPassword= "password123"

#import Caas Module
Import-Module CaaS
Import-Module Posh-SSH

#capture the Caas credentials and create a new Caas conneciton
$login = Get-Credential
New-CaasConnection -ApiCredentials $login -ApiBaseUri https://api-au.dimensiondata.com/oec/0.9/

#Get the network with a specific name
$network=Get-CaasNetworks -Name $networkname

#Get a OS image with a specific name 
$os=Get-CaasOsImages -Network $network -Name $osimagename

#create a new server details configuration
$serverdetails = New-CaasServerDetails -Name $servername  -AdminPassword $administratorPassword -IsStarted $false -OsServerImage $os -Network $network

#set the the disk speed on the server to be provisioned. Disk speeds can retrieved by (Get-CaasDataCentre).hypervisor.diskSpeed
$serverdetails = Set-CaasServerDiskDetails -ServerDetails $serverdetails -ScsiId 0 -SpeedId "HIGHPERFORMANCE"



New-CaasServer -ServerDetails $serverdetails -PassThru | Out-CaasWaitForOperation |` 
Set-CaasServerState -Action PowerOn


#Add a nat rule so the server
$server = Get-CaasDeployedServer -Name $servername
$natrule=Add-CaasNatRule -NatRuleName Test -Network $network -SourceIpAddress $server.privateIp

#Add firewall/ACL rule to permit TCP traffic on port 22 from any network(SSH)
Add-CaasAclRule -AclRuleName "AllowSSHPort22" -Network $network -Position 120 -DestinationIpAddress $natrule.natIp -Action PERMIT -Protocol TCP -PortRangeType EQUAL_TO -Port1 22 -AclType OUTSIDE_ACL

#SSH onto the server
$sshusername = "root"
$sshpassword = convertto-securestring $administratorPassword -asplaintext -force
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
New-SSHSession -ComputerName $server.privateIp -Credential $cred
Invoke-SSHCommand -Command "wget -qO- https://get.docker.com/ | sh" -SessionId 0 -TimeOut 3600
