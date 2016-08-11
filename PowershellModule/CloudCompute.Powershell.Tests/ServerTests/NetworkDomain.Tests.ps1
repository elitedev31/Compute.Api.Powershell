# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.Tests.TestContext] $TestContext
		)


Describe "Get-CaaSNetworkDomain filter by datacenterId" {
    It "Get-CaaSNetworkDomain Should Get the list of Network Domains" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domain = Get-CaasNetworkDomain -NetworkDomainName River_Lab -Connection $testConnection.CaaSConnection -DatacenterId AU9
		$domain | Should Not BeNullOrEmpty
		$testConnection | Verify "GET" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/networkDomain?name=River_Lab&datacenterId=AU9' 1
	}
}

Describe "Get-CaaSNetworkDomain filter by NetworkDomainName" {
    It "Get-CaaSNetworkDomain Should Get the list of Network Domains" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domain = Get-CaasNetworkDomain -NetworkDomainName River_Lab -Connection $testConnection.CaaSConnection
		$domain | Should Not BeNullOrEmpty
		$testConnection | Verify "GET" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/networkDomain?name=River_Lab' 1
	}
}


Describe "Get-CaaSNetworkDomain filter by NetworkDomainId" {
    It "Get-CaaSNetworkDomain Should Get the list of Network Domains" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domain = Get-CaasNetworkDomain -NetworkDomainId bcf42c64-8d19-4844-b0ae-eac6a2f4b486 -Connection $testConnection.CaaSConnection
		$domain | Should Not BeNullOrEmpty
		$testConnection | Verify "GET" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/networkDomain?id=bcf42c64-8d19-4844-b0ae-eac6a2f4b486' 1
	}
}

Describe "New-CaaSNetworkDomain" {
    It "New-CaaSNetworkDomain Should Create a new Network Domain" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "CREATE NETWORKDOMAIN"
		$response.message = "CREATE NETWORKDOMAIN"
		$response.responseCode = "OK"
		$testConnection | Setup "POST" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/deployNetworkDomain' $response 200
		$NetworkDomain = New-CaasNetworkDomain -DatacenterId AU9 -Name NetworkDomainName -Type Advanced -Connection $testConnection.CaaSConnection
		$NetworkDomain | Should Not BeNullOrEmpty
		$testConnection | Verify "POST" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/deployNetworkDomain' 1
	}
}

Describe "Remove-CaaSNetworkDomain" {
    It "Remove-CaaSNetworkDomain Should Remove a Network Domain" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$NetworkDomain = Get-CaasNetworkDomain -NetworkDomainId bcf42c64-8d19-4844-b0ae-eac6a2f4b486 -Connection $testConnection.CaaSConnection
		$NetworkDomain | Should Not BeNullOrEmpty
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "REMOVE NETWORKDOMAIN"
		$response.message = "REMOVE NETWORKDOMAIN"
		$response.responseCode = "OK"
		$testConnection | Setup "POST" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/deleteNetworkDomain' $response 200
		$NetworkDomain = Remove-CaasNetworkDomain -NetworkDomain $NetworkDomain -Connection $testConnection.CaaSConnection
		$testConnection | Verify "POST" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/deleteNetworkDomain' 1
	}
}
