# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.ComputeServiceConnection] $Connection
		)

Describe "Get-CaaSServer" {
    It "Count Should be 32" {
		$servers = Get-CaaSServer -Connection $Connection
        $servers.Count | Should Be 32
    }
}
