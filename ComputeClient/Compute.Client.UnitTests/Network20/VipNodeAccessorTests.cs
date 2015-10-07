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
	public class VipNodeAccessorTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task CreateNode_ReturnsResponse()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.AddVipNode(this.accountId), RequestFileResponseType.AsGoodResponse("CreateNodeResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipNodeAccessor(client);

            var response = await accessor.CreateNode(new CreateNodeType
		    {
		        networkDomainId = Guid.NewGuid().ToString(),
                name = "NetworkNodeTest"
		    });

			Assert.IsNotNull(response);
            Assert.AreEqual("CREATE_NODE", response.operation);
            Assert.AreEqual("OK", response.responseCode);
            Assert.AreEqual("9e6b496d-5261-4542-91aa-b50c7f569c54", response.info[0].value);
        }

        [TestMethod]
        public async Task GetNode_ReturnsResponse()
        {
            var nodeId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetVipNode(this.accountId, nodeId), RequestFileResponseType.AsGoodResponse("GetNodeResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipNodeAccessor(client);

            var response = await accessor.GetNode(nodeId);

            Assert.IsNotNull(response);
            Assert.AreEqual("NORMAL", response.state);
            Assert.AreEqual("ProductionNode.2", response.name);
            Assert.AreEqual("34de6ed6-46a4-4dae-a753-2f8d3840c6f9", response.id);
        }

        [TestMethod]
        public async Task GetNodes_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetVipNodes(this.accountId), RequestFileResponseType.AsGoodResponse("ListNodesResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipNodeAccessor(client);

            var response = await accessor.GetNodes();

            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Count());
        }

        [TestMethod]
        public async Task EditNode_ReturnsResponse()
        {
            var nodeId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.EditVipNode(this.accountId), RequestFileResponseType.AsGoodResponse("EditNodeResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipNodeAccessor(client);

            var response = await accessor.EditNode(new EditNodeType
            {
                id = nodeId.ToString()
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("EDIT_NODE", response.operation);
        }

        [TestMethod]
        public async Task DeleteNode_ReturnsResponse()
        {
            var nodeId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeleteVipNode(this.accountId), RequestFileResponseType.AsGoodResponse("DeleteNodeResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipNodeAccessor(client);

            var response = await accessor.DeleteNode(nodeId);

            Assert.IsNotNull(response);
            Assert.AreEqual("DELETE_NODE", response.operation);
        }
    }
}
