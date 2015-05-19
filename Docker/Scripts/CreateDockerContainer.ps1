#import Caas Module
Import-Module CaaS
Set-Location $PSScriptRoot
Import-Module (Join-Path $PSScriptRoot "Docker.psm1") -DisableNameChecking

#capture the Caas credentials and create a new Caas conneciton
$login = Get-Credential -Message "Enter Caas api credentials"
New-CaasConnection -ApiCredentials $login -ApiBaseUri https://api-au.dimensiondata.com/oec/0.9/

New-CaasDockerContainer -Name "DockerHost19" -NetworkName "Innovation Lab" -RootPassword "password123"