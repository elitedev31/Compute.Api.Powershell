using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Exceptions;
using DD.CBU.Compute.Api.Client.Server20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.Server20
{
	[TestClass]
	public class ServerAccessorTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task GetServers_ReturnsResponse()
		{
			requestsAndResponses.Add(ApiUris.MyAccount,RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.GetMcp2Servers(accountId), RequestFileResponseType.AsGoodResponse("GetServersResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var servers = await accessor.GetServers();

            Assert.IsNotNull(servers);
			Assert.AreEqual(1, servers.Count());
			Assert.AreEqual("d577a691-e116-4913-a440-022d2729fc84", servers.First().id);
            Assert.AreEqual("NA9", servers.First().datacenterId);
            Assert.AreEqual("Production Web Server", servers.First().name);
			Assert.IsNotNull(servers.First().networkInfo);
		}

		[TestMethod]
		public async Task GetServer_ReturnsResponse()
		{
			Guid serverId = new Guid("d577a691-e116-4913-a440-022d2729fc84");

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.GetMcp2Server(accountId, serverId), RequestFileResponseType.AsGoodResponse("GetServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
			var server = await accessor.GetServer(serverId);

            Assert.IsNotNull(server);
			Assert.AreEqual("d577a691-e116-4913-a440-022d2729fc84", server.id);
            Assert.AreEqual("NA9", server.datacenterId);
            Assert.AreEqual(server.name, "Production Web Server");
			Assert.IsNotNull(server.networkInfo);
		}

		[TestMethod]
		[ExpectedException(typeof(BadRequestException))]
		public async Task GetServer_NotFound()
		{
			Guid serverId = new Guid("0ab41d5f-4c0f-4804-a807-7015ee2adb61");
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.GetMcp2Server(accountId, serverId), new RequestFileResponseType{ ResponseFile = "GetServerNotFound.xml", Status = HttpStatusCode.BadRequest});

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            await accessor.GetServer(serverId);
		}
	}
}
