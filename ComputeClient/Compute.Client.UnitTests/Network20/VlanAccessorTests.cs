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
	public class VlanAccessorTests : BaseApiClientTestFixture
	{
        [TestMethod]
        public async Task DeployVlan_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeployVlan(this.accountId), RequestFileResponseType.AsGoodResponse("DeployVlanResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VlanAccessor(client);

            var response = await accessor.DeployVlan(new DeployVlanType()
            {
                name = "VLAN 1",
                description = "my description"
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("DEPLOY_VLAN", response.operation);
            Assert.AreEqual("IN_PROGRESS", response.responseCode);
            Assert.AreEqual("cee8df03-9117-44cc-baaa-631ffa099683", response.info[0].value);
        }

        [TestMethod]
        public async Task GetVlan_ReturnsResponse()
        {
            var vlanId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetVlan(this.accountId, vlanId), RequestFileResponseType.AsGoodResponse("GetVlanResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VlanAccessor(client);

            var response = await accessor.GetVlan(vlanId);

            Assert.IsNotNull(response);
            Assert.AreEqual("NORMAL", response.state);
            Assert.AreEqual("Test VLAN", response.name);
            Assert.AreEqual("0e56433f-d808-4669-821d-812769517ff8", response.id);
        }

        [TestMethod]
        public async Task GetVlans_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetVlanByOrgId(this.accountId), RequestFileResponseType.AsGoodResponse("ListVlansResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VlanAccessor(client);

            var response = await accessor.GetVlans();

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Count());
        }

        [TestMethod]
        public async Task EditVlan_ReturnsResponse()
        {
            var vlanId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.EditVlan(this.accountId), RequestFileResponseType.AsGoodResponse("EditVlanResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VlanAccessor(client);

            var response = await accessor.EditVlan(new EditVlanType
            {
                id = vlanId.ToString()
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("EDIT_VLAN", response.operation);
        }

        [TestMethod]
        public async Task ExpandVlan_ReturnsResponse()
        {
            var vlanId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.ExpandVlan(this.accountId), RequestFileResponseType.AsGoodResponse("ExpandVlanResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VlanAccessor(client);

            var response = await accessor.ExpandVlan(new ExpandVlanType
            {
                id = vlanId.ToString()
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("EXPAND_VLAN", response.operation);
        }

        [TestMethod]
        public async Task DeleteVlan_ReturnsResponse()
        {
            var vlanId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeleteVlan(this.accountId), RequestFileResponseType.AsGoodResponse("DeleteVlanResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VlanAccessor(client);

            var response = await accessor.DeleteVlan(vlanId);

            Assert.IsNotNull(response);
            Assert.AreEqual("DELETE_VLAN", response.operation);
        }
    }
}
