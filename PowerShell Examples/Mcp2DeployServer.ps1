$networkDomainName = "Test API network"
$location = "NASH_PCS01_N2_VMWARE_1"
$osImageName = "RedHat 6 64-bit 2 CPU"
$administratorPassword= "password123"
$vlanName = "testV1"

#import Caas Module
#Import-Module CaaS
Import-Module "C:\Sources\DD\DimensionData.ComputeClient\PowershellModule\CloudCompute.Powershell\bin\Debug\CaaS.psd1"
#capture the Caas credentials and create a new Caas conneciton
$login = Get-Credential
New-CaasConnection -ApiCredentials $login -ApiDomainName apinashpcs01.opsourcecloud.net

#Get the network with a specific name
$networkDomain = Get-CaasNetworkDomain -NetworkDomainName $networkDomainName

#Get a OS image with a specific name 
$os=Get-CaasOsImages -Location $location -Name $osImageName

#create a new server details configuration
$vlan = get-CaasVlan -Name $vlanName -NetworkDomain $networkDomain

new-CaasServerOnNetworkDomain -Name "MyTestServer" -Description "Server Created using PS" -NetworkDomain $networkDomain -ServerImage $os -IsStarted $True -AdminPassword $administratorPassword -PrimaryNetwork $vlan 
