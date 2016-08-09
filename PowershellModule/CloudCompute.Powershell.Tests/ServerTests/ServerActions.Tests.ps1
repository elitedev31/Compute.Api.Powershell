# Find a better way of passing the connection around
param (		
		[Parameter(Mandatory=$True)]
		[DD.CBU.Compute.Powershell.Tests.TestContext] $TestContext
		)


Describe "Start-CaaSServer" {
    It "Start-CaaSServer Should work" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$server = Get-CaaSServer -Connection $testConnection.CaaSConnection -ServerId 94e46b99-0e94-4625-9d36-eede640ca909
		$server | Should Not BeNullOrEmpty		
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "START_SERVER"
		$response.message = "START_SERVER"
		$response.responseCode = "OK"
		$testConnection | Setup "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/startServer' $response 200
		Start-CaasServer -Server $server -Connection $testConnection.CaaSConnection	
		$testConnection | Verify "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/startServer' 1
	}
}

Describe "Stop-CaaSServer" {
    It "Stop-CaaSServer Should call shutdown API" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$server = Get-CaaSServer -Connection $testConnection.CaaSConnection -ServerId 94e46b99-0e94-4625-9d36-eede640ca909
		$server | Should Not BeNullOrEmpty		
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "STOP SERVER"
		$response.message = "STOP SERVER"
		$response.responseCode = "OK"
		$testConnection | Setup "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/shutdownServer' $response 200
		Stop-CaasServer -Server $server -Connection $testConnection.CaaSConnection	
		$testConnection | Verify "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/shutdownServer' 1
	}
}

Describe "Stop-CaaSServer -Force" {
    It "Stop-CaaSServer -Force Should call poweroff API" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$server = Get-CaaSServer -Connection $testConnection.CaaSConnection -ServerId 94e46b99-0e94-4625-9d36-eede640ca909
		$server | Should Not BeNullOrEmpty		
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "POWEROFF SERVER"
		$response.message = "POWEROFF SERVER"
		$response.responseCode = "OK"
		$testConnection | Setup "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/powerOffServer' $response 200
		Stop-CaasServer -Server $server -Connection $testConnection.CaaSConnection -Force
		$testConnection | Verify "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/powerOffServer' 1
	}
}

Describe "Restart-CaaSServer" {
    It "Restart-CaaSServer Should call reboot API" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$server = Get-CaaSServer -Connection $testConnection.CaaSConnection -ServerId 94e46b99-0e94-4625-9d36-eede640ca909
		$server | Should Not BeNullOrEmpty		
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "RESTART SERVER"
		$response.message = "RESTART SERVER"
		$response.responseCode = "OK"
		$testConnection | Setup "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/rebootServer' $response 200
		Restart-CaasServer -Server $server -Connection $testConnection.CaaSConnection	
		$testConnection | Verify "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/rebootServer' 1
	}
}

Describe "Restart-CaaSServer -Force" {
    It "Restart-CaaSServer -Force Should call reset API" {
		$testConnection = New-CaaSTestConnection -TestContext $TestContext
		$server = Get-CaaSServer -Connection $testConnection.CaaSConnection -ServerId 94e46b99-0e94-4625-9d36-eede640ca909
		$server | Should Not BeNullOrEmpty		
		$response = new-object -TypeName  DD.CBU.Compute.Api.Contracts.Network20.ResponseType
		$response.operation = "RESET SERVER"
		$response.message = "RESET SERVER"
		$response.responseCode = "OK"
		$testConnection | Setup "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/resetServer' $response 200
		Restart-CaasServer -Server $server -Connection $testConnection.CaaSConnection -Force
		$testConnection | Verify "POST" '/caas/2.1/a4f484de-b9ed-43e4-b565-afbf69417615/server/resetServer' 1
	}
}