using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Exceptions;
using DD.CBU.Compute.Api.Client.Server20;
using DD.CBU.Compute.Api.Contracts.Network20;
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
			Assert.AreEqual(5, servers.Count());
			Assert.AreEqual("0fad8eeb-83d7-4703-b450-171c33a79682", servers.First().id);
            Assert.AreEqual("AU10", servers.First().datacenterId);
            Assert.AreEqual("6ac5f462-f611-4590-bd3a-b3f66ea93815", servers.First().networkInfo.primaryNic.id);
            Assert.AreEqual("ecf85a96-e753-429f-a7b7-a455767ac1bd", servers.First().networkInfo.additionalNic.First().id);
        }

        [TestMethod]
		public async Task GetServer_ReturnsResponse()
		{
			Guid serverId = new Guid("0fad8eeb-83d7-4703-b450-171c33a79682");

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.GetMcp2Server(accountId, serverId), RequestFileResponseType.AsGoodResponse("GetServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
			var server = await accessor.GetServer(serverId);

            Assert.IsNotNull(server);
            Assert.AreEqual("0fad8eeb-83d7-4703-b450-171c33a79682", server.id);
            Assert.AreEqual("AU10", server.datacenterId);
            Assert.AreEqual("6ac5f462-f611-4590-bd3a-b3f66ea93815", server.networkInfo.primaryNic.id);
            Assert.AreEqual("ecf85a96-e753-429f-a7b7-a455767ac1bd", server.networkInfo.additionalNic.First().id);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task GetServer_NotFound()
        {
            Guid serverId = new Guid("0ab41d5f-4c0f-4804-a807-7015ee2adb61");
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetMcp2Server(accountId, serverId), new RequestFileResponseType { ResponseFile = "GetServerNotFound.xml", Status = HttpStatusCode.BadRequest });

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            await accessor.GetServer(serverId);
        }

        [TestMethod]
        public async Task DeleteServer_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeleteServer(accountId), RequestFileResponseType.AsGoodResponse("DeleteServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.DeleteServer(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("DELETE_SERVER", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task StartServer_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.StartServer(accountId), RequestFileResponseType.AsGoodResponse("StartServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.StartServer(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("START_SERVER", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task ShutdownServer_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.ShutdownServer(accountId), RequestFileResponseType.AsGoodResponse("ShutdownServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.ShutdownServer(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("SHUTDOWN_SERVER", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task RebootServer_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.RebootServer(accountId), RequestFileResponseType.AsGoodResponse("RebootServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.RebootServer(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("REBOOT_SERVER", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task ResetServer_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.ResetServer(accountId), RequestFileResponseType.AsGoodResponse("ResetServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.ResetServer(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("RESET_SERVER", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task PowerOffServer_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.PowerOffServer(accountId), RequestFileResponseType.AsGoodResponse("PowerOffServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.PowerOffServer(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("POWER_OFF_SERVER", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task UpdateVmwareTools_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.UpdateVmwareTools(accountId), RequestFileResponseType.AsGoodResponse("UpdateVmwareToolsResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.UpdateVmwareTools(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("UPDATE_VMWARE_TOOLS", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task DeployServer_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeployMCP20Server(accountId), RequestFileResponseType.AsGoodResponse("DeployServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.DeployServer(new DeployServerType());

            Assert.IsNotNull(response);
            Assert.AreEqual("DEPLOY_SERVER", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task CleanServer_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.CleanServer(accountId), RequestFileResponseType.AsGoodResponse("CleanServerResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.CleanServer(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("CLEAN_SERVER", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task AddNic_ReturnsResponse()
        {
            Guid serverId = new Guid("d577a691-e116-4913-a440-022d2729fc84");

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.AddNic(accountId), RequestFileResponseType.AsGoodResponse("AddNicResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.AddNic(serverId, Guid.NewGuid(), null);

            Assert.IsNotNull(response);
            Assert.AreEqual("ADD_NIC", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
            Assert.AreEqual("a202e51b-41c0-4cfc-add0-b1c62fc0ecf6", response.info.First().value);
        }

        [TestMethod]
        public async Task RemoveNic_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.RemoveNic(accountId), RequestFileResponseType.AsGoodResponse("RemoveNicResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.RemoveNic(Guid.NewGuid());

            Assert.IsNotNull(response);
            Assert.AreEqual("REMOVE_NIC", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }

        [TestMethod]
        public async Task NotifyNicIpChange_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.NotifyNicIpChange(accountId), RequestFileResponseType.AsGoodResponse("NotifyNicIpChangeResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new ServerAccessor(client);
            var response = await accessor.NotifyNicIpChange(new NotifyNicIpChangeType());

            Assert.IsNotNull(response);
            Assert.AreEqual("NOTIFY_NIC_IP_ADDRESS_CHANGE", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
        }
    }
}
