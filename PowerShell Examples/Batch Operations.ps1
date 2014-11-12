$servername = "PSTestSever"
$networkname = "ADSyncTest"
$osimagename = "Win2012 DC 64-bit 2 CPU"
$administratorPassword= "password123"

#import Caas Module
Import-Module CaaS

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


# 
#Create new Caas server using the server details created before, using the -PassThru paramenter will return a Server object that can be pipped to Out-CaasWaitForOperation
#Out-CaasWaitForOperation cmdlet will monitor the progress of any server provisioning operation, you MUST use the -PassThru paramenter
#The command below will perform the following actions in one goal:
#1) Create a CaaS server with a High Performance disk as system drive (based on the server details created above)
#2) Modify the CPU and memory to 4 CPUs and 8GB RAM
#3) Rezise the System drive to 100GB
#4) Add another Economy drive to the server
#5) Start the server



New-CaasServer -ServerDetails $serverdetails -PassThru | Out-CaasWaitForOperation |` 
Set-CaasServer -CPUCount 4 -MemoryInMB 8192 -PassThru | Out-CaasWaitForOperation |`
Resize-CaasServerDisk -ScsiId 0 -NewSizeInGB 100 -PassThru | Out-CaasWaitForOperation |`
Add-CaasServerDisk -SizeInGB 200 -SpeedId "ECONOMY" -PassThru | Out-CaasWaitForOperation |`
Set-CaasServerState -Action PowerOn


#Add a nat rule so the server
$server = Get-CaasDeployedServer -Name $servername
$natrule=Add-CaasNatRule -NatRuleName Test -Network $network -SourceIpAddress $server.privateIp

#Add firewall/ACL rule to permit TCP traffic on port 80 from any network
Add-CaasAclRule -AclRuleName "AllowPort80" -Network $network -Position 120 -DestinationIpAddress $natrule.natIp -Action PERMIT -Protocol TCP -PortRangeType EQUAL_TO -Port1 80 -AclType OUTSIDE_ACL

