function New-CaaSTestConnection {
	param (
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.Tests.TestContext] $TestContext
		)
	Process {								
			$httpClient = New-CaasApiProxyHttpClient `
					-ApiMocksPath $TestContext.ApiMocksPath `
					-ApiRecordingPath $TestContext.ApiRecordingPath `
					-ApiCredentials $TestContext.ApiCredentials `
					-FallbackToDefaultApi $TestContext.FallbackToDefaultApi `
					-RecordApiRequestResponse $TestContext.RecordApiRequestResponse `
					-DefaultApiAddress $TestContext.DefaultApiAddress

			$connection = New-CaasConnection -Name "Test" -HttpClient $httpClient.HttpClient `
									 -ApiCredentials $httpClient.Credential				
			return New-TestConnection -TestHttpClient $httpClient `
										 -CaaSConnection $connection 
		}
}

function Verify {
	param (
		[Parameter(Mandatory=$true, ValueFromPipeline)]
		[DD.CBU.Compute.Powershell.Tests.TestCaaSConnection] $TestCaaSConnection,
		[Parameter(Mandatory=$true, Position=1)]
		[string] $HttpMethod,
		[Parameter(Mandatory=$true, Position=2)]
		[string] $RequestUri,
		[Parameter(Mandatory=$false, Position=3)]
		[Int] $Times = -1
		)
	Process {									
			$apiRecords = $TestCaaSConnection.GetApiCalledRecords($RequestUri, $HttpMethod)
		    $lineText = $MyInvocation.Line.TrimEnd("`n")
            $line = $MyInvocation.ScriptLineNumber
            $file = $MyInvocation.ScriptName

			if($apiRecords.Count -le 0)
			{
				throw ( New-VerifyErrorRecord -Message "No Requests received for '$HttpMethod : $RequestUri'" -File $file -Line $line -LineText $lineText)
			}

			if($Times -ne -1 -and $apiRecords.Count -ne $Times)
			{
				throw ( New-VerifyErrorRecord -Message "Api Requests received for '$HttpMethod : $RequestUri' was received for: $($apiRecords.Count) , expected: $Times" -File $file -Line $line -LineText $lineText)
			}
		}
}

function New-VerifyErrorRecord ([string] $Message, [string] $File, [string] $Line, [string] $LineText) {
    $exception = New-Object Exception $Message
    $errorID = 'CaaSApiVerifyAssertionFailed'
    $errorCategory = [Management.Automation.ErrorCategory]::InvalidResult
    # we use ErrorRecord.TargetObject to pass structured information about the error to a reporting system.
    $targetObject = @{Message = $Message; File = $File; Line = $Line; LineText = $LineText}
    $errorRecord = New-Object Management.Automation.ErrorRecord $exception, $errorID, $errorCategory, $targetObject
    return $errorRecord
}
Export-ModuleMember -Function New-CaaSTestConnection, Verify ,New-VerifyErrorRecord