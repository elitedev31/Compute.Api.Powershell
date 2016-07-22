# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.Tests.TestContext] $TestContext
		)

Describe "Get-CaaSServer" {
    It "Count Should be 32" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$servers = Get-CaaSServer -Connection $testConnection.CaaSConnection
        $servers.Count | Should Be 33
		$testConnection | Verify "GET" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/server' 1
	}
}
