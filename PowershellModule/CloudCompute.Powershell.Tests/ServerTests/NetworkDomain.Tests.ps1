# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.Tests.TestContext] $TestContext
		)


Describe "Get-CaaSNetworkDomain filter by datacenterId" {
    It "Get-CaaSNetworkDomain Should Get the list of servers" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domain = Get-CaasNetworkDomain -NetworkDomainName River_Lab -Connection $testConnection.CaaSConnection -DatacenterId AU9
		$domain | Should Not BeNullOrEmpty
		$testConnection | Verify "GET" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/networkDomain?name=River_Lab&datacenterId=AU9' 1
	}
}

Describe "Get-CaaSNetworkDomain filter by NetworkDomainName" {
    It "Get-CaaSNetworkDomain Should Get the list of servers" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domain = Get-CaasNetworkDomain -NetworkDomainName River_Lab -Connection $testConnection.CaaSConnection
		$domain | Should Not BeNullOrEmpty
		$testConnection | Verify "GET" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/networkDomain?name=River_Lab' 1
	}
}


Describe "Get-CaaSNetworkDomain filter by NetworkDomainId" {
    It "Get-CaaSNetworkDomain Should Get the list of servers" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domain = Get-CaasNetworkDomain -NetworkDomainId bcf42c64-8d19-4844-b0ae-eac6a2f4b486 -Connection $testConnection.CaaSConnection
		$domain | Should Not BeNullOrEmpty
		$testConnection | Verify "GET" '/caas/2.3/a4f484de-b9ed-43e4-b565-afbf69417615/network/networkDomain?id=bcf42c64-8d19-4844-b0ae-eac6a2f4b486' 1
	}
}
