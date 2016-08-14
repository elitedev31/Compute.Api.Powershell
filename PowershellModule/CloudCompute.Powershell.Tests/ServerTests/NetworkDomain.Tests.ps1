# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.Tests.TestContext] $TestContext
		)

Describe "Get-CaaSNetworkDomain" {
    It "List Network Domain Api Should have no filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domains = Get-CaaSNetworkDomain -Connection $testConnection.CaaSConnection
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/networkDomain" 1
	}
}

Describe "Get-CaaSNetworkDomain By Datacenter Id" {
    It "List Network Domain Api Should have Datacenter id filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domains = Get-CaaSNetworkDomain -Connection $testConnection.CaaSConnection -DatacenterId AU9
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/networkDomain?datacenterId=AU9" 1
	}
}

Describe "Get-CaaSNetworkDomain filter by NetworkDomainName" {
    It "Get-CaaSNetworkDomain Should Get the list of Network Domains" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domains = Get-CaaSNetworkDomain -Connection $testConnection.CaaSConnection -Name River_Lab
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/networkDomain?name=River_Lab" 1
	}
}

Describe "Get-CaaSNetworkDomain By Network Domain Id" {
    It "List Network Domain Api Should have Network domain id filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domains = Get-CaaSNetworkDomain -Connection $testConnection.CaaSConnection -Id a4f484de-b9ed-43e4-b565-afbf69417615
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/networkDomain?id=a4f484de-b9ed-43e4-b565-afbf69417615" 1
	}
}

Describe "New-CaaSNetworkDomain" {
    It "New-CaaSNetworkDomain Should Create a new Network Domain" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "CREATE NETWORKDOMAIN"
		$response.message = "CREATE NETWORKDOMAIN"
		$response.info = @()
		$networkIdInfo = new-object -TypeName DD.CBU.Compute.Api.Contracts.Network20.NameValuePairType
		$networkIdInfo.name = "networkDomainId"
		$networkIdInfo.value = "a4f484de-b9ed-43e4-b565-afbf69417615"
		$response.info += $networkIdInfo
		$response.responseCode = "OK"
		$testConnection | Setup "POST" "/caas/2.1/$($testConnection.CaaSClientId)/network/deployNetworkDomain" $response 200
		New-CaasNetworkDomain -Connection $testConnection.CaaSConnection -DatacenterId AU9 -Name RandomNetworkName_1 -Type Advanced
		$testConnection | Verify "POST" "/caas/2.1/$($testConnection.CaaSClientId)/network/deployNetworkDomain" 1
	}
}

Describe "Remove-CaaSNetworkDomain" {
    It "Remove-CaaSNetworkDomain Should remove a Network Domain" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$domains = Get-CaaSNetworkDomain -Connection $testConnection.CaaSConnection -Id a4f484de-b9ed-43e4-b565-afbf69417615
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "REMOVE NETWORKDOMAIN"
		$response.message = "REMOVE NETWORKDOMAIN"
		$response.info = @()
		$networkIdInfo = new-object -TypeName DD.CBU.Compute.Api.Contracts.Network20.NameValuePairType
		$networkIdInfo.name = "networkDomainId"
		$networkIdInfo.value = "a4f484de-b9ed-43e4-b565-afbf69417615"
		$response.info += $networkIdInfo
		$response.responseCode = "OK"
		$testConnection | Setup "POST" "/caas/2.1/$($testConnection.CaaSClientId)/network/deployNetworkDomain" $response 200
		New-CaasNetworkDomain -Connection $testConnection.CaaSConnection -DatacenterId AU9 -Name RandomNetworkName_1 -Type Advanced
		$testConnection | Verify "POST" "/caas/2.1/$($testConnection.CaaSClientId)/network/deployNetworkDomain" 1
	}
}