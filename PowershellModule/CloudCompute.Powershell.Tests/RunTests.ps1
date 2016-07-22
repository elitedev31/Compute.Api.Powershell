param (
		[Parameter(Mandatory=$false)]
		[bool] $UseMockCredentials = $False,
		[Parameter(Mandatory=$false)]
		[bool] $FallbackToDefaultApi = $True
		)
import-module (Join-Path $PSScriptRoot "..\CloudCompute.Powershell\bin\Release\CaaS.psd1")
import-module (Join-Path $PSScriptRoot "..\packages\Pester.3.4.0\tools\Pester.psd1")
import-module (Join-Path $PSScriptRoot "bin\Release\CaaS_Tests.psd1")
import-module (Join-Path $PSScriptRoot ".\CaaSTestUtilities.psm1")
$mockApiPath = (Join-Path $PSScriptRoot ".\MockApis")
if($FallbackToDefaultApi -eq $True){
	$mockApiRecordingPath = (Join-Path $PSScriptRoot ".\MockApisRecordings")
}
else{
	$mockApiRecordingPath = $mockApiPath
}
$connection = New-CaaSTestConnection -UseMockCredentials $UseMockCredentials -FallbackToDefaultApi $FallbackToDefaultApi -MockApisPath $mockApiPath -MockApisRecordingPath $mockApiRecordingPath

Invoke-Pester -Script @{ Path = '.\*'; Parameters = @{ Connection = $connection}; } -OutputFile .\TestOutput.xml -OutputFormat NUnitXml