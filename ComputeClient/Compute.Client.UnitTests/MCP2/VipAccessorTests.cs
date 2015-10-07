using System;
using System.Linq;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.MCP2
{
	[TestClass]
	public class VipAccessorTests : BaseApiClientTestFixture
	{
        [TestMethod]
        public async Task GetDefaultHealthMonitors_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetDefaultHealthMonitors(this.accountId, networkDomainId), RequestFileResponseType.AsGoodResponse("ListDefaultHealthMonitorsResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipAccessor(client);

            var response = await accessor.GetDefaultHealthMonitors(networkDomainId);

            Assert.IsNotNull(response);
            Assert.AreEqual(6, response.Count());
        }

        [TestMethod]
        public async Task GetDefaultPersistenceProfiles_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetDefaultPersistenceProfile(this.accountId, networkDomainId), RequestFileResponseType.AsGoodResponse("ListDefaultPersistenceProfilesResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipAccessor(client);

            var response = await accessor.GetDefaultPersistenceProfiles(networkDomainId);

            Assert.IsNotNull(response);
            Assert.AreEqual(4, response.Count());
        }

        [TestMethod]
        public async Task GetDefaultIrules_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetDefaultIrule(this.accountId, networkDomainId), RequestFileResponseType.AsGoodResponse("ListDefaultIrulesResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipAccessor(client);

            var response = await accessor.GetDefaultIrules(networkDomainId);

            Assert.IsNotNull(response);
            Assert.AreEqual(4, response.Count());
        }
    }
}
