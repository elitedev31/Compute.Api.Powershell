using System;
using System.Linq;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Server20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.Server20
{
	[TestClass]
	public class AntiAffinityRuleAccessorTests : BaseApiClientTestFixture
	{
        [TestMethod]
        public async Task GetAntiAffinityRulesForServer_ReturnsResponse()
        {
            var serverId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetMcp2GetAntiAffinityRulesForServer(accountId, serverId), RequestFileResponseType.AsGoodResponse("GetAntiAffinityRulesResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new AntiAffinityRuleAccessor(client);
            var response = await accessor.GetAntiAffinityRulesForServer(serverId);

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Count());
            Assert.AreEqual(2, response.First().serverSummary.Count());
            Assert.AreEqual("681a6db2-9c7c-4d98-a0c4-7b3d7c1619ba", response.First().serverSummary.First().id);
            Assert.AreEqual("5783e93f-5370-44fc-a772-cd3c29a2ecaa", response.First().serverSummary.Last().id);
        }

        [TestMethod]
        public async Task GetAntiAffinityRulesForNetwork_ReturnsResponse()
        {
            var networkId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetMcp2GetAntiAffinityRulesForNetwork(accountId, networkId), RequestFileResponseType.AsGoodResponse("GetAntiAffinityRulesResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new AntiAffinityRuleAccessor(client);
            var response = await accessor.GetAntiAffinityRulesForNetwork(networkId);

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Count());
            Assert.AreEqual(2, response.First().serverSummary.Count());
            Assert.AreEqual("681a6db2-9c7c-4d98-a0c4-7b3d7c1619ba", response.First().serverSummary.First().id);
            Assert.AreEqual("5783e93f-5370-44fc-a772-cd3c29a2ecaa", response.First().serverSummary.Last().id);
        }

        [TestMethod]
        public async Task GetAntiAffinityRulesForNetworkDomain_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetMcp2GetAntiAffinityRulesForNetworkDomain(accountId, networkDomainId), RequestFileResponseType.AsGoodResponse("GetAntiAffinityRulesResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new AntiAffinityRuleAccessor(client);
            var response = await accessor.GetAntiAffinityRulesForNetworkDomain(networkDomainId);

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Count());
            Assert.AreEqual(2, response.First().serverSummary.Count());
            Assert.AreEqual("681a6db2-9c7c-4d98-a0c4-7b3d7c1619ba", response.First().serverSummary.First().id);
            Assert.AreEqual("5783e93f-5370-44fc-a772-cd3c29a2ecaa", response.First().serverSummary.Last().id);
        }
    }
}
