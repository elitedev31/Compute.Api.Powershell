import-module (Join-Path $PSScriptRoot "..\CloudCompute.Powershell\bin\Release\CaaS.psd1")
import-module (Join-Path $PSScriptRoot "bin\Release\CaaS_Tests.psd1")
.\SetupConnection.ps1
#List all the tests below