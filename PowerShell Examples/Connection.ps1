
$connectionDev=New-CaasConnection -Name "AustraliaConnection" -ApiCredentials (Get-Credential -Message "Dev Connection") -Vendor DimensionData -Region Australia_AU 

$connectionDev2=New-CaasConnection -Name "APACConnection" -ApiCredentials (Get-Credential -Message "Dev2 Connection") -Vendor DimensionData -Region AsiaPacific_AP

#list deployed servers on the active connection (AustraliaConnection)
Write-Host "Get Deployed Servers from connection AustraliaConnection"
Get-CaasDeployedServer

#set the active connection to APACConnection
Set-CaasActiveConnection -Name "APACConnection"


#list deployed servers on the active connection (APACConnection)
Write-Host "Get Deployed Servers from connection APACConnection"
Get-CaasDeployedServer


#use the connection parameter to force the cmdlet to use the AustraliaConnection 
Get-CaasDeployedServer -Connection $connectionDev


#list all connections stored on the PS session 
Get-CaasConnection

#Remove the APACConnection from PS Session
Remove-CaasConnection -Name "APACConnection"