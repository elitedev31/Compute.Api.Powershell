###
 # Requirements - install PowerShell for AWS 
 # http://aws.amazon.com/powershell/
###

## Replace these with your target image details..
$region = "ap-southeast-2"
$transferBucket = "export-examples-dd" # Note you need to add 
$instanceToMove = "i-fgj7kblz" # Name of the Amazon instance to migrate.
$targetNetworkName = "EXAMPLE-WEB" # Name of the network you want to migrate to
$targetLocation = "AU1" # CaaS location to migrate to.
$targetImageName = "Example-WEB" # Name of the virtual machine you want to create

# Import the AWS PowerShell Commands.
Import-Module AWSPowerShell 

# Import the AWS Utilities for CaaS
. .\AWS_Utilities.ps1

$akid = "AKIAIFY64H7FAB2L712D" # Replace with your API Key ID
$aksec = "wLmkFh3Ow177Moy1asdu2kcoyc3jCWSs7wWA" # Key Secret from the UI

# Setup AWS API
Set-DefaultAWSRegion -Region $region
Set-AWSCredentials -AccessKey $akid -SecretKey $aksec -StoreAs "export"

$exportJob = ExportImageFromAWS -region $region -bucketName $transferBucket -instanceId $instanceToMove
DownloadAWSExport -region $region -bucketName $transferBucket -exportId $exportJob

SetupCaaS
# Upload our virtual appliance.
New-CaasUploadCustomerImage -VirtualAppliance "$exportJob.ova"

# import OVF into CaaS.
$package = Get-CaasOvfPackages | Where { $_.name -eq "$exportJob.mf" }
$network = Get-CaasNetworks -Name $targetNetworkName -Location $targetLocation
New-CaasImportCustomerImage -CustomerImageName $targetImageName -OvfPackage $package -Network $network -Description "Imported image from AWS - $instanceToMove"

