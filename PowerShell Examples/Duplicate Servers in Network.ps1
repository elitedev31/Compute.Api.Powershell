Import-Module CaaS

# Create a connection
$secpasswd = ConvertTo-SecureString "MyPassword123!" -AsPlainText -Force
$login= New-Object System.Management.Automation.PSCredential ("MyUsername", $secpasswd)

New-CaasConnection -ApiCredentials $login -ApiBaseUri "https://api-au.dimensiondata.com/oec/0.9/"

# Get the network called "My Network"
$myTestNetwork  = Get-CaasNetworks | Where name -eq "My Network"
#Get all machines in that network
$myTestServers = Get-CaasDeployedServer | Where networkId -eq $myTestNetwork.Id

# Print on the screen
$myTestServers | Format-Table

# For each server
foreach ($server in $myTestServers){

	# Determine the source image- either the stock image or a custom image (this contains the CPU/RAM spec also)
    $sourceImage = Get-CaasOsImages -NetworkWithLocations $myTestNetwork | Where Id -eq $server.sourceImageId
    if ($sourceImage -eq $Null){
        $sourceImage = Get-CaasCustomerImages -NetworkWithLocations $myTestNetwork | Where Id -eq $server.sourceImageId
    }
	
	# Create a new version from the same image template
    if ($sourceImage -ne $Null){
        $newServerDetails = New-CaasServerDetails -Name $($server.name+"-new") -Description $server.description -AdminPassword "MyPassword123!" -IsStarted $true -OsServerImage $sourceImage -Network $myTestNetwork
        New-CaasVM -ServerDetails $newServerDetails
        Write-Host "Created $($server.name+'-new') "
        Set-CaasServerState -Server $server -Action PowerOff
        Remove-CaasVM -Server $server
    } else {
        Write-Warning "Cannot find original source image for server $($server.name)"
    }
}