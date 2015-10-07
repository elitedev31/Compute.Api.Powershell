using System;
using System.Linq;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.Network20
{
	[TestClass]
	public class NetworkDomainAccessorTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task DeployNetworkDomain_ReturnsResponse()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.CreateNetworkDomain(this.accountId), RequestFileResponseType.AsGoodResponse("DeployNetworkDomainResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new NetworkDomainAccessor(client);

            var response = await accessor.DeployNetworkDomain(new DeployNetworkDomainType()
			{
				datacenterId = "DC1",
				description = "my description",
				name = "domain1",
				type = "ESSENTIALS"
			});

			Assert.IsNotNull(response);
            Assert.AreEqual("DEPLOY_NETWORK_DOMAIN", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
            Assert.AreEqual("f14a871f-9a25-470c-aef8-51e13202e1aa", response.info[0].value);
        }

        [TestMethod]
        public async Task GetNetworkDomain_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.NetworkDomain(this.accountId, networkDomainId), RequestFileResponseType.AsGoodResponse("GetNetworkDomainResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new NetworkDomainAccessor(client);

            var response = await accessor.GetNetworkDomain(networkDomainId);

            Assert.IsNotNull(response);
            Assert.AreEqual("NORMAL", response.state);
            Assert.AreEqual("Development Network Domain", response.name);
            Assert.AreEqual("8cdfd607-f429-4df6-9352-162cfc0891be", response.id);
        }

        [TestMethod]
        public async Task GetNetworkDomains_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.NetworkDomains(this.accountId), RequestFileResponseType.AsGoodResponse("ListNetworkDomainsResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new NetworkDomainAccessor(client);

            var response = await accessor.GetNetworkDomains();

            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Count());
        }

        [TestMethod]
        public async Task EditNetworkDomain_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.ModifyNetworkDomain(this.accountId), RequestFileResponseType.AsGoodResponse("EditNetworkDomainResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new NetworkDomainAccessor(client);

            var response = await accessor.ModifyNetworkDomain(new EditNetworkDomainType
            {
                id = networkDomainId.ToString()
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("EDIT_NETWORK_DOMAIN", response.operation);
        }

        [TestMethod]
        public async Task DeleteNetworkDomain_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeleteNetworkDomain(this.accountId), RequestFileResponseType.AsGoodResponse("DeleteNetworkDomainResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new NetworkDomainAccessor(client);

            var response = await accessor.DeleteNetworkDomain(networkDomainId);

            Assert.IsNotNull(response);
            Assert.AreEqual("DELETE_NETWORK_DOMAIN", response.operation);
        }
    }
}
