param (
		[Parameter(Mandatory=$false)]
		[bool] $UseMockCredentials = $False,
		[Parameter(Mandatory=$false)]
		[bool] $FallbackToDefaultApi = $True,
		[Parameter(Mandatory=$false)]
		[string] $BuildConfiguration = 'Debug'
		)
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
	$credential = (Get-Credential)	
}

$testContext = New-CaasTestContext -UseMockCredentials $UseMockCredentials -FallbackToDefaultApi $FallbackToDefaultApi -MockApisPath $mockApiPath -MockApisRecordingPath $mockApiRecordingPath -ApiCredentials $credential -DefaultApiAddress 'https://api-au.dimensiondata.com/' -RecordApiRequestResponse $True
Invoke-Pester -Script @{ Path = '.\*Tests'; Parameters = @{ TestContext = $testContext }; } -OutputFile .\nunit-results.xml -OutputFormat NUnitXml