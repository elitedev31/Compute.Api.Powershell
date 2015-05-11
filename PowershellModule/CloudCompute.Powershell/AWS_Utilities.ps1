
function Import-ImageToAWS {
	param (
		[string] $imageFile , # Path to the disk image (VMDK)
		[string] $bucketName, # Name of the S3 bucket to temporarily store in.
		[string] $arch = "x86_64"
	)
	SetupBucket -bucketName $bucketName
	
	$importJob = Import-EC2Instance -InstanceType m1.xlarge -ImageFile $imageFile -FileFormat "VMDK" -BucketName $bucketName -Architecture $arch -ProfileName "export"# Or i386 (unlikely so just set default)

	$task = Get-EC2ConversionTask -ConversionTaskId $importJob.ConversionTaskId -ProfileName "export" 
}

function Download-AWSExport {
	param (
		[string] $bucketName,
		[string] $exportId,
		[string] $region
	)
	Read-S3Object -BucketName $bucketName -File "$exportId.ova" -Key "$exportId.ova" -ProfileName "export" -Region $region
}

function Export-ImageFromAWS {
	param (
		[string] $instanceId,
		[string] $bucketName,
		[string] $region
	)
	SetupAWSBucket -bucketName $bucketName -region $region
	
	$exportTask = New-EC2InstanceExportTask -InstanceId $instanceId -TargetEnvironment "VMWare"	-ExportToS3Task_S3Bucket $bucketName -ProfileName "export" -Region $region 
		
	# Wait for export to complete.
	$complete = $False
	while (!$complete){
		$status = Get-EC2ExportTasks -ExportTaskId $exportTask.ExportTaskId -ProfileName "export" -Region $region
		if ($status.State.Value -eq "active"){
			Write-Host "Waiting for job to complete.."
			Start-Sleep -s 10 # Wait 10 seconds
		} else {
			Write-Host "$status.State.Value $status.StatusMessage"
			$complete = $True
		}
	}
	
	return $exportTask.ExportTaskId
}

function Setup-AWSBucket {
	param (
		[string] $bucketName,
		[string] $region
	)
	# Does the bucket exist?
	$bucket = Get-S3Bucket -BucketName $bucketName -ProfileName "export" -Region $region
	
	if ($bucket -eq $Null){
		$bucket = New-S3Bucket -BucketName $bucketName -ProfileName "export"
		
		# Setup the ACL to allow the Amazon import processor access to write and read from the bucket.
		# Can't find any documentation on how the syntax is. 
		#$grants = @(
		#			@{
		#				Grantee = @{
		#					CanonicalUser = "vm-import-export@amazon.com"
		#				};
		#				Permission = "FULL_CONTROL"
		#			}
		#		)
		# Set-S3ACL -BucketName $bucketName -Grant $grants -ProfileName "export"
	}
}