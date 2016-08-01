# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.Tests.TestContext] $TestContext
		)

Describe "New-CaaSServerDetails For MCP1 OS Image" {
    It "Image Id is mapped correctly" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$mcp1ServerImage = Get-CaasOsImage -Connection $testConnection.CaaSConnection -Id defd95e3-7a7b-4649-b231-8c0b2efbddd1 -Mcp1
		$mcp1ServerImage | Should Not BeNullOrEmpty
		$mcp1Network = Get-CaasNetwork -Name "Manish Test" -Connection $testConnection.CaaSConnection
		$mcp1Network | Should Not BeNullOrEmpty
		$serverDetails = New-CaaSServerDetails -ServerImage $mcp1ServerImage -Name "Blah" -AdminPassword "Junkwer12!!" -IsStarted $True -Network  $mcp1Network
        $serverDetails.ImageId | Should be defd95e3-7a7b-4649-b231-8c0b2efbddd1		
	}
}

Describe "New-CaaSServerDetails For MCP1 Customer Image" {
    It "Image Id is mapped correctly" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$mcp1CustomerImage = Get-CaasCustomerImage -Connection $testConnection.CaaSConnection -ImageId 5ae04f29-1f03-4850-97b6-f287d1cd23ca -Mcp1
		$mcp1CustomerImage | Should Not BeNullOrEmpty
		$mcp1Network = Get-CaasNetwork -Name "Manish Test" -Connection $testConnection.CaaSConnection
		$mcp1Network | Should Not BeNullOrEmpty
		$serverDetails = New-CaaSServerDetails -ServerImage $mcp1CustomerImage -Name "Blah" -AdminPassword "Junkwer12!!" -IsStarted $True -Network  $mcp1Network
        $serverDetails.ImageId | Should be 5ae04f29-1f03-4850-97b6-f287d1cd23ca		
	}
}

Describe "New-CaaSServerDetails For MCP2 OS Image" {
    It "Image Id is mapped correctly" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$mcp2ServerImage = Get-CaasOsImage -Connection $testConnection.CaaSConnection -Id defd95e3-7a7b-4649-b231-8c0b2efbddd1
		$mcp2ServerImage | Should Not BeNullOrEmpty
		$mcp2Network = Get-CaasNetworkDomain -NetworkDomainName "Manish Net Domain" -Connection $testConnection.CaaSConnection
		$mcp2Network | Should Not BeNullOrEmpty
		$serverDetails = New-CaaSServerDetails -ServerImage $mcp2ServerImage -Name "Blah" -AdminPassword "Junkwer12!!" -IsStarted $True -NetworkDomain  $mcp2Network -PrivateIp "10.2.3.4"
        $serverDetails.ImageId | Should be defd95e3-7a7b-4649-b231-8c0b2efbddd1		
	}
}

Describe "New-CaaSServerDetails For MCP2 Customer Image" {
    It "Image Id is mapped correctly" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$mcp2CustomerImage = Get-CaasCustomerImage -Connection $testConnection.CaaSConnection -ImageId 5ae04f29-1f03-4850-97b6-f287d1cd23ca
		$mcp2CustomerImage | Should Not BeNullOrEmpty
		$mcp2Network = Get-CaasNetworkDomain -NetworkDomainName "Manish Net Domain" -Connection $testConnection.CaaSConnection
		$mcp2Network | Should Not BeNullOrEmpty
		$serverDetails = New-CaaSServerDetails -ServerImage $mcp2CustomerImage -Name "Blah" -AdminPassword "Junkwer12!!" -IsStarted $True -NetworkDomain  $mcp2Network -PrivateIp "10.2.3.4"
        $serverDetails.ImageId | Should be 5ae04f29-1f03-4850-97b6-f287d1cd23ca		
	}
}
