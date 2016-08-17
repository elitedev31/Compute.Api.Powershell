# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.Tests.TestContext] $TestContext
		)

Describe "Get-CaaSServer" {
    It "List Server Api Should have no filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$servers = Get-CaaSServer -Connection $testConnection.CaaSConnection  
        #$servers.Count | Should be 21     
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/server/server" 1
	}
}

Describe "Get-CaaSServer By Network Domain Id" {
    It "List Server Api Should have Network domain id filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$servers = Get-CaaSServer -Connection $testConnection.CaaSConnection -NetworkDomainId a4f484de-b9ed-43e4-b565-afbf69417615
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/server/server?networkDomainId=a4f484de-b9ed-43e4-b565-afbf69417615" 1
	}
}

Describe "Get-CaaSServer By Vlan Id" {
    It "List Server Api Should have Network domain id filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$servers = Get-CaaSServer -Connection $testConnection.CaaSConnection -VlanId a4f484de-b9ed-43e4-b565-afbf69417615
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/server/server?vlanId=a4f484de-b9ed-43e4-b565-afbf69417615" 1
	}
}

Describe "Get-CaaSServer Throws Error" {
    It "List Server Api Should throw" {
		$account = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Directory.Account
		$account.OrganizationId = 'a4f484de-b9ed-43e4-b565-afbf69417615'
		$account.UserName = "TestUser"
		$testConnection = New-CaaSTestConnection -TestContext $TestContext -MockAccount $account
		$errorResponse = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$errorResponse.operation = "LIST_SERVER"
		$errorResponse.message = "LIST_SERVER"
		$errorResponse.responseCode = "TEST_FAILURE"
		$testConnection | Setup "GET" "/caas/2.3/$($testConnection.CaaSClientId)/server/server" $errorResponse 400
		{ Get-CaaSServer -Connection $testConnection.CaaSConnection -ErrorAction Stop } | Should Throw		
	}
}
