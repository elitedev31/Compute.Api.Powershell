$httpClient = New-CaasApiProxyHttpClient `
				-ApiMocksPath "C:\Sources\DD\GitHubApiProxy\ApiProxy.Host\MocksApis" `
				-ApiRecordingPath "C:\Sources\DD\GitHubApiProxy\ApiProxy.Host\MocksApis" `
				-ApiCredentials $credential -FallbackToDefaultApi $True `
				-RecordApiRequestResponse $True `
				-DefaultApiAddress 'https://api-au.dimensiondata.com/'

New-CaasConnection -HttpClient $apiClient -ApiCredentials $httpClient