function New-CaaSTestConnection {
	param (
		[Parameter(Mandatory=$false)]
		[bool] $UseMockCredentials = $False,
		[Parameter(Mandatory=$false)]
		[bool] $FallbackToDefaultApi = $True,
		[Parameter(Mandatory=$true)]
		[string] $MockApisPath,
		[Parameter(Mandatory=$true)]
		[string] $MockApisRecordingPath
		)
	Process {				
			if($UseMockCredentials -eq $True){
				Write-Host "Using the Fake credentials, as we will be mocking all calls"
				$pwd = ConvertTo-SecureString -AsPlainText "junk" -Force
				$credential = new-object -typename System.Management.Automation.PSCredential ("Test", $pwd)				
			}
			else{		
				Write-Host "Using the real credentials"
				$credential = (Get-Credential)	
			}
					
			$httpClient = New-CaasApiProxyHttpClient `
					-ApiMocksPath $MockApisPath `
					-ApiRecordingPath $MockApisRecordingPath `
					-ApiCredentials $credential `
					-FallbackToDefaultApi $FallbackToDefaultApi `
					-RecordApiRequestResponse $True `
					-DefaultApiAddress 'https://api-au.dimensiondata.com/'

			return New-CaasConnection -HttpClient $httpClient -ApiCredentials $credential
		}
}

Export-ModuleMember -Function New-CaaSTestConnection