# Handle the connection 
$credential = (Get-Credential)
$mockApiPath = (Join-Path $PSScriptRoot ".\MockApis")
$httpClient = New-CaasApiProxyHttpClient `
				-ApiMocksPath $mockApiPath `
				-ApiRecordingPath $mockApiPath `
				-ApiCredentials $credential `
				-FallbackToDefaultApi $True `
				-RecordApiRequestResponse $True `
				-DefaultApiAddress 'https://api-au.dimensiondata.com/'

New-CaasConnection -HttpClient $httpClient -ApiCredentials $credential