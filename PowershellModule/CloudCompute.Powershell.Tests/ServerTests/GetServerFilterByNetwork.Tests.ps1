# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.ComputeServiceConnection] $Connection
		)

Describe "Get-CaaSServer For a network Domain" {
    It "Count Should be 32" {
		$servers = Get-CaaSServer -NetworkDomainId '493fdff6-455d-11e3-9153-001b21cfdbe0' -Connection $Connection
        $servers.Count | Should Be 32
    }
}
