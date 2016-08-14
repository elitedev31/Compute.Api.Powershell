param (
		[Parameter(Mandatory=$false)]
		[bool] $UseMockCredentials = $False,
		[Parameter(Mandatory=$false)]
		[bool] $FallbackToDefaultApi = $True,
		[Parameter(Mandatory=$false)]
		[string] $BuildConfiguration = 'Debug',
		[Parameter(Mandatory=$false)]
		[Guid] $CaaSClientId = 'a4f484de-b9ed-43e4-b565-afbf69417615',
		[parameter(Mandatory=$false)]
		[PSCredential]$Cred
		)

Write-Host "!!!Using the '$BuildConfiguration' Configuration!!!"
import-module (Join-Path $PSScriptRoot "..\CloudCompute.Powershell\bin\$BuildConfiguration\CaaS.psd1")
import-module (Join-Path $PSScriptRoot "..\packages\Pester.3.4.0\tools\Pester.psd1")
import-module (Join-Path $PSScriptRoot "bin\$BuildConfiguration\CaaS_Tests.psd1")
import-module (Join-Path $PSScriptRoot ".\CaaSTestUtilities.psm1")
$mockApiPath = (Join-Path $PSScriptRoot ".\MockApis")
if($FallbackToDefaultApi -eq $True){
	$mockApiRecordingPath = (Join-Path $PSScriptRoot ".\MockApisRecordings")
}
else{
	$mockApiRecordingPath = $mockApiPath
}
if($UseMockCredentials -eq $True){
	Write-Host "Using the Fake credentials, as we will be mocking all calls"
	$pwd = ConvertTo-SecureString -AsPlainText "junk" -Force
	$credential = new-object -typename System.Management.Automation.PSCredential ("Test", $pwd)				
}
else{		
	Write-Host "Using the real credentials"
	if ($Cred -eq $null)
	{
		$credential = (Get-Credential)
	}
	else
	{
		$credential = $Cred
	}
}

$testContext = New-CaasTestContext -UseMockCredentials $UseMockCredentials -FallbackToDefaultApi $FallbackToDefaultApi -MockApisPath $mockApiPath -MockApisRecordingPath $mockApiRecordingPath -ApiCredentials $credential -DefaultApiAddress 'https://api-au.dimensiondata.com/' -RecordApiRequestResponse $True -CaaSClientId $CaaSClientId
Invoke-Pester -Script @{ Path = '.\*Tests'; Parameters = @{ TestContext = $testContext }; } -OutputFile .\nunit-results.xml -OutputFormat NUnitXml