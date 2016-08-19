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
		$testConnection | Setup "POST" "/caas/2.1/$($testConnection.CaaSClientId)/network/deleteNetworkDomain" $response 200
		Remove-CaasNetworkDomain -Connection $testConnection.CaaSConnection -NetworkDomain $domains
		$testConnection | Verify "POST" "/caas/2.1/$($testConnection.CaaSClientId)/network/deleteNetworkDomain" 1
	}
}

Describe "Get-CaasVlan" {
    It "List Vlan Api Should have no filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$vlans = Get-CaasVlan -Connection $testConnection.CaaSConnection
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/vlan" 1
	}
}

Describe "Get-CaasVlan By Datacenter Id" {
    It "List Vlan Api Should have Datacenter id filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$vlans = Get-CaasVlan -Connection $testConnection.CaaSConnection -DatacenterId AU9
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/vlan?datacenterId=AU9" 1
	}
}

Describe "Get-CaasVlan filter by Vlan Name" {
    It "Get-CaasVlan Should Get the list of Vlan by name" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$vlans = Get-CaasVlan -Connection $testConnection.CaaSConnection -Name vlan01
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/vlan?name=vlan01" 1
	}
}

Describe "Get-CaasVlan By Vlan Id" {
    It "List Vlan Should have id filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$vlans = Get-CaasVlan -Connection $testConnection.CaaSConnection -Id 91d21154-3414-4f87-9af5-a656884b49bc
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/vlan?id=91d21154-3414-4f87-9af5-a656884b49bc" 1
	}
}

Describe "Get-CaasVlan By Network Domain" {
    It "List Vlan Should have id filter" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$networkdomain = Get-CaaSNetworkDomain -Connection $testConnection.CaaSConnection -Id 0fdb588c-867f-42ef-b839-16f518ae4f6a
		$vlans = Get-CaasVlan -Connection $testConnection.CaaSConnection -NetworkDomain $networkdomain
		$testConnection | Verify "GET" "/caas/2.3/$($testConnection.CaaSClientId)/network/vlan?networkDomainid=$($networkdomain.id)" 1
	}
}

Describe "New-CaasVlan" {
    It "New-CaasVlan Should Create a new Vlan" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$networkdomain = Get-CaaSNetworkDomain -Connection $testConnection.CaaSConnection -Name River_Lab
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "CREATE VLAN"
		$response.message = "CREATE VLAN"
		$response.info = @()
		$vlanInfo = new-object -TypeName DD.CBU.Compute.Api.Contracts.Network20.NameValuePairType
		$vlanInfo.name = "vlanId"
		$vlanInfo.value = "1578108f-e4aa-4ab7-8b2b-b9244482df93"
		$response.info += $vlanInfo
		$response.responseCode = "OK"
		$testConnection | Setup "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/deployVlan" $response 200
		New-CaasVlan -Connection $testConnection.CaaSConnection -NetworkDomain $networkdomain -Name vlan02 -PrivateIpv4BaseAddress 172.20.2.0 -PrivateIpv4PrefixSize 24
		$testConnection | Verify "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/deployVlan" 1
	}
}

Describe "New-CaasVlan" {
    It "New-CaasVlan Should Create a new Vlan With GatewayAddressing" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$networkdomain = Get-CaaSNetworkDomain -Connection $testConnection.CaaSConnection -Name River_Lab
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "CREATE VLAN"
		$response.message = "CREATE VLAN"
		$response.info = @()
		$vlanInfo = new-object -TypeName DD.CBU.Compute.Api.Contracts.Network20.NameValuePairType
		$vlanInfo.name = "vlanId"
		$vlanInfo.value = "1578108f-e4aa-4ab7-8b2b-b9244482df93"
		$response.info += $vlanInfo
		$response.responseCode = "OK"
		$testConnection | Setup "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/deployVlan" $response 200
		New-CaasVlan -Connection $testConnection.CaaSConnection -NetworkDomain $networkdomain -Name vlan02 -PrivateIpv4BaseAddress 172.20.2.0 -PrivateIpv4PrefixSize 24 -GatewayAddressing 'HIGH'
		$testConnection | Verify "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/deployVlan" 1
	}
}

Describe "Remove-CaasVlan" {
    It "Remove-CaasVlan Should remove a Vlan" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$vlans = Get-CaasVlan -Connection $testConnection.CaaSConnection -Id 91d21154-3414-4f87-9af5-a656884b49bc
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "REMOVE VLAN"
		$response.message = "REMOVE VLAN"
		$response.info = @()
		$vlanInfo = new-object -TypeName DD.CBU.Compute.Api.Contracts.Network20.NameValuePairType
		$vlanInfo.name = "vlanId"
		$vlanInfo.value = "1578108f-e4aa-4ab7-8b2b-b9244482df93"
		$response.info += $vlanInfo
		$response.responseCode = "OK"
		$testConnection | Setup "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/deleteVlan" $response 200
		Remove-CaasVlan -Connection $testConnection.CaaSConnection -Vlan $vlans
		$testConnection | Verify "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/deleteVlan" 1
	}
}

Describe "Set-CaasVlan" {
    It "Set-CaasVlan Should Update the Name and description" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$vlan = Get-CaasVlan -Connection $testConnection.CaaSConnection -Id 91d21154-3414-4f87-9af5-a656884b49bc
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "EDIT_VLAN"
		$response.message = "EDIT_VLAN"
		$response.info = @()
		$vlanInfo = new-object -TypeName DD.CBU.Compute.Api.Contracts.Network20.NameValuePairType
		$vlanInfo.name = "vlanId"
		$vlanInfo.value = "1578108f-e4aa-4ab7-8b2b-b9244482df93"
		$response.info += $vlanInfo
		$response.responseCode = "OK"
		$testConnection | Setup "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/editVlan" $response 200
		Set-CaasVlan -Connection $testConnection.CaaSConnection -Vlan $vlan -Name vlan02 -Description TestDescription
		$testConnection | Verify "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/editVlan" 1
	}
}

Describe "Resize-CaasVlan" {
    It "Resize-CaasVlan Should Expand the VLAN" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$vlan = Get-CaasVlan -Connection $testConnection.CaaSConnection -Id 91d21154-3414-4f87-9af5-a656884b49bc
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "EXPAND_VLAN"
		$response.message = "EXPAND_VLAN"
		$response.info = @()
		$vlanInfo = new-object -TypeName DD.CBU.Compute.Api.Contracts.Network20.NameValuePairType
		$vlanInfo.name = "vlanId"
		$vlanInfo.value = "1578108f-e4aa-4ab7-8b2b-b9244482df93"
		$response.info += $vlanInfo
		$response.responseCode = "OK"
		$testConnection | Setup "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/expandVlan" $response 200
		Resize-CaasVlan -Connection $testConnection.CaaSConnection -Vlan $vlan -PrivateIpv4PrefixSize 22
		$testConnection | Verify "POST" "/caas/2.3/$($testConnection.CaaSClientId)/network/expandVlan" 1
	}
}
