using System;
using System.Net;
using System.Runtime;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Exceptions;
using DD.CBU.Compute.Api.Client.Server20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.MCP2
{
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Network20;

	using Moq;

	[TestClass]
	public class ServerTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task GetServersFromXML()
		{
			requestsAndResponses.Add(ApiUris.MyAccount,RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.GetMcp2Servers(accountId), RequestFileResponseType.AsGoodResponse("GetMcp2ServersResponse.xml"));

			var client = GetApiClient();
			await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));
			var servers = await client.GetMcp2DeployedServers();
			Assert.IsNotNull(servers);
			Assert.IsNotNull(servers.Server);
			Assert.AreEqual(servers.Server.Length, 1);
			Assert.AreEqual(servers.Server[0].id, "d577a691-e116-4913-a440-022d2729fc84");
			Assert.AreEqual(servers.Server[0].datacenterId, "NA9");
			Assert.AreEqual(servers.Server[0].name, "Production Web Server");
			Assert.IsNotNull(servers.Server[0].networkInfo);
		}

		[TestMethod]
		public async Task GetServerFromXML()
		{
			Guid serverId = new Guid("d577a691-e116-4913-a440-022d2729fc84");
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.GetMcp2Server(accountId, serverId), RequestFileResponseType.AsGoodResponse("GetMcp2ServerResponse.xml"));

			var client = GetApiClient();
			await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));
			var server = await client.GetMcp2DeployedServer(serverId);
			Assert.IsNotNull(server);
			Assert.AreEqual(server.id, "d577a691-e116-4913-a440-022d2729fc84");
			Assert.AreEqual(server.datacenterId, "NA9");
			Assert.AreEqual(server.name, "Production Web Server");
			Assert.IsNotNull(server.networkInfo);
		}

		[TestMethod]
		[ExpectedException(typeof(BadRequestException))]
		public async Task GetServerNotFoundFromXML()
		{
			Guid serverId = new Guid("0ab41d5f-4c0f-4804-a807-7015ee2adb61");
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.GetMcp2Server(accountId, serverId), new RequestFileResponseType{ ResponseFile = "ServerNotFound.xml", Status = HttpStatusCode.BadRequest});

			var client = GetApiClient();
			await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));
			
			// This should explode.
			await client.GetMcp2DeployedServer(serverId);
		}
	}
}
