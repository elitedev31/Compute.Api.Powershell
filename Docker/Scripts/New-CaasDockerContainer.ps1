$servername = "DockerHost17"
$networkname = "Innovation Lab"
# picking 14.04 makes installing docker much easier
$osimagename = "Ubuntu 14.04 2 CPU" 
$administratorPassword= "password123"

#import Caas Module
Import-Module "C:\Sources\DD\DimensionData.ComputeClient\PowershellModule\CloudCompute.Powershell\bin\Debug\CaaS.psd1"
#Import-Module CaaS
Import-Module Posh-SSH

#capture the Caas credentials and create a new Caas conneciton
$login = Get-Credential
New-CaasConnection -ApiCredentials $login -ApiBaseUri https://api-au.dimensiondata.com/oec/0.9/

#Get the network with a specific name
$network=Get-CaasNetworks -Name $networkname

#Get a OS image with a specific name 
$os=Get-CaasOsImages -Network $network -Name $osimagename

#create a new server details configuration
$serverdetails = New-CaasServerDetails -Name $servername  -AdminPassword $administratorPassword -IsStarted $True -OsServerImage $os -Network $network -Description "##docker##"

#set the the disk speed on the server to be provisioned. Disk speeds can retrieved by (Get-CaasDataCentre).hypervisor.diskSpeed
$serverdetails = Set-CaasServerDiskDetails -ServerDetails $serverdetails -ScsiId 0 -SpeedId "HIGHPERFORMANCE"



New-CaasServer -ServerDetails $serverdetails -PassThru | Out-CaasWaitForOperation


#Add a nat rule so the server
$server = Get-CaasDeployedServer -Name $servername

#Add firewall/ACL rule to permit TCP traffic on port 22 from any network(SSH)
New-CaasAclRule -AclRuleName "AllowSSHPort22" -Network $network -Position 120 -DestinationIpAddress $server.privateIp -Action PERMIT -Protocol TCP -PortRangeType EQUAL_TO -Port1 22 -AclType OUTSIDE_ACL  -ErrorAction SilentlyContinue

#SSH onto the server
$sshusername = "root"
$sshpassword = convertto-securestring $administratorPassword -asplaintext -force
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $sshusername, $sshpassword
Write-Host "SSHing into .." $server.privateIp
New-SSHSession -ComputerName $server.privateIp -Credential $cred -AcceptKey 
Invoke-SSHCommand -Command "wget -qO- https://get.docker.com/ | sh" -SessionId 0 -TimeOut 3600
