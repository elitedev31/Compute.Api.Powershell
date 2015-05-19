#import Caas Module
Import-Module "C:\Sources\DD\DimensionData.ComputeClient\PowershellModule\CloudCompute.Powershell\bin\Debug\CaaS.psd1"
#Import-Module CaaS
Set-Location $PSScriptRoot
Import-Module (Join-Path $PSScriptRoot "Docker.psm1") -DisableNameChecking

#capture the Caas credentials and create a new Caas conneciton
$login = Get-Credential -Message "Enter Caas api credentials"
New-CaasConnection -ApiCredentials $login -ApiBaseUri https://api-au.dimensiondata.com/oec/0.9/

Run-CaasDockerApp -Name "hello-world" -NetworkName "Innovation Lab" -Parameters ""  -RootPassword "password123"