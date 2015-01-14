#Requirements

#import Caas Module
Import-Module CaaS

#capture the Caas credentials and create a new Caas conneciton
$login = Get-Credential

$scriptblock = { `

$servername = "Server1"
$networkname = "Network1"
$osimagename = "Win2012 DC 64-bit 2 CPU"
$administratorPassword= "password123"


New-CaasConnection -ApiCredentials $args[0] -Vendor DimensionData -Region Australia_AU


#Get the network with a specific name
$network=Get-CaasNetworks -Name $networkname

#Get a OS image with a specific name 
$os=Get-CaasOsImages -Network $network -Name $osimagename

#create a new server details configuration
$serverdetails = New-CaasServerDetails -Name $servername  -AdminPassword $administratorPassword -IsStarted $false -OsServerImage $os -Network $network

# create new server, change memory to 8GB and 4 vCPU, start the server

 New-CaasServer -ServerDetails $serverdetails -PassThru | Out-CaasWaitForOperation | Set-CaasServer -CPUCount 4 -MemoryInMB 8192 -PassThru | Out-CaasWaitForOperation | Set-CaasServerState -Action PowerOn 

 }

 Start-Job -Name "CreateServer" -ScriptBlock $scriptblock -ArgumentList $login


