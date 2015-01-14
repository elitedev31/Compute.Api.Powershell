
$connectionDev=New-CaasConnection -Name "AustraliaConnection" -ApiCredentials (Get-Credential -Message "Dev Connection") -Vendor DimensionData -Region Australia_AU 

$connectionDev2=New-CaasConnection -Name "APACConnection" -ApiCredentials (Get-Credential -Message "Dev2 Connection") -Vendor DimensionData -Region AsiaPacific_AP


Write-Host "Get Deployed Servers from connection AustraliaConnection"

#list deployed servers on the active connection (AustraliaConnection)
Get-CaasDeployedServer

#set the active connection to APACConnection
Set-CaasActiveConnection -Name "APACConnection"



Write-Host "Get Deployed Servers from connection APACConnection"
#list deployed servers on the active connection (APACConnection)
Get-CaasDeployedServer


#use the connection parameter to execute the cmdlet agains the AustraliaConnection 
Get-CaasDeployedServer -Connection $connectionDev


#list all connections stored on the PS session 
Get-CaasConnection