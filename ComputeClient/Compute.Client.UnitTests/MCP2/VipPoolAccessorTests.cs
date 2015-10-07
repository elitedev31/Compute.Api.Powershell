using System;
using System.Linq;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.MCP2
{
	[TestClass]
	public class VipPoolAccessorTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task CreatePool_ReturnsResponse()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.CreatePool(this.accountId), RequestFileResponseType.AsGoodResponse("CreatePoolResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.CreatePool(new createPool
		    {
		        networkDomainId = Guid.NewGuid().ToString(),
                name = "NetworkPoolTest"
		    });

			Assert.IsNotNull(response);
            Assert.AreEqual("CREATE_POOL", response.operation);
            Assert.AreEqual("OK", response.responseCode);
            Assert.AreEqual("9e6b496d-5261-4542-91aa-b50c7f569c54", response.info[0].value);
        }

        [TestMethod]
        public async Task GetPool_ReturnsResponse()
        {
            var poolId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetPool(this.accountId, poolId), RequestFileResponseType.AsGoodResponse("GetPoolResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.GetPool(poolId);

            Assert.IsNotNull(response);
            Assert.AreEqual("NORMAL", response.state);
            Assert.AreEqual("myDevelopmentPool.1", response.name);
            Assert.AreEqual("4d360b1f-bc2c-4ab7-9884-1f03ba2768f7", response.id);
        }

        [TestMethod]
        public async Task GetPools_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetPools(this.accountId), RequestFileResponseType.AsGoodResponse("ListPoolsResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.GetPools();

            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Count());
        }

        [TestMethod]
        public async Task EditPool_ReturnsResponse()
        {
            var poolId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.EditPool(this.accountId), RequestFileResponseType.AsGoodResponse("EditPoolResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.EditPool(new EditPoolType
            {
                id = poolId.ToString()
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("EDIT_POOL", response.operation);
        }

        [TestMethod]
        public async Task DeletePool_ReturnsResponse()
        {
            var poolId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeletePool(this.accountId), RequestFileResponseType.AsGoodResponse("DeletePoolResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.DeletePool(poolId);

            Assert.IsNotNull(response);
            Assert.AreEqual("DELETE_POOL", response.operation);
        }

        [TestMethod]
        public async Task AddPoolMember_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.AddPoolMember(this.accountId), RequestFileResponseType.AsGoodResponse("AddPoolMemberResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.AddPoolMember(new addPoolMember
            {
                poolId = Guid.NewGuid().ToString()
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("ADD_POOL_MEMBER", response.operation);
            Assert.AreEqual("OK", response.responseCode);
            Assert.AreEqual("3dd806a2-c2c8-4c0c-9a4f-5219ea9266c0", response.info[0].value);
        }

        [TestMethod]
        public async Task GetPoolMember_ReturnsResponse()
        {
            var poolMemberId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetPoolMember(this.accountId, poolMemberId), RequestFileResponseType.AsGoodResponse("GetPoolMemberResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.GetPoolMember(poolMemberId);

            Assert.IsNotNull(response);
            Assert.AreEqual("NORMAL", response.state);
            Assert.AreEqual("3dd806a2-c2c8-4c0c-9a4f-5219ea9266c0", response.id);
        }

        [TestMethod]
        public async Task GetPoolMembers_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetPoolMembers(this.accountId), RequestFileResponseType.AsGoodResponse("ListPoolMembersResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.GetPoolMembers();

            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Count());
        }

        [TestMethod]
        public async Task EditPoolMember_ReturnsResponse()
        {
            var poolMemberId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.EditPoolMember(this.accountId), RequestFileResponseType.AsGoodResponse("EditPoolMemberResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.EditPoolMember(new editPoolMember
            {
                id = poolMemberId.ToString()
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("EDIT_POOL_MEMBER", response.operation);
        }

        [TestMethod]
        public async Task RemovePoolMember_ReturnsResponse()
        {
            var poolMemberId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeletePoolMember(this.accountId), RequestFileResponseType.AsGoodResponse("RemovePoolMemberResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new VipPoolAccessor(client);

            var response = await accessor.RemovePoolMember(poolMemberId);

            Assert.IsNotNull(response);
            Assert.AreEqual("REMOVE_POOL_MEMBER", response.operation);
        }
    }
}
