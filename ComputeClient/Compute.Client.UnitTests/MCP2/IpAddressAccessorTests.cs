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
    public class IpAddressAccessorTests : BaseApiClientTestFixture
    {
        private Guid NetworkDomainId = Guid.NewGuid();

        [TestMethod]
        public async Task AddPublicIpBlock_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.AddPublicIpBlock(accountId), RequestFileResponseType.AsGoodResponse("AddPublicIpBlockResponse.xml"));

            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressAccessor(webApi);

            var domainResponse = await ipAddressManagementAccessor.AddPublicIpBlock(NetworkDomainId);

            Assert.IsNotNull(domainResponse);
            Assert.AreEqual("OK", domainResponse.responseCode);
            Assert.AreEqual("ADD_PUBLIC_IP_BLOCK", domainResponse.operation);
            Assert.IsNotNull(domainResponse.info.Any(q => q.name == "publicIpBlockId"));
        }

        [TestMethod]
        public async Task ListPublicIpBlocks_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.GetPublicIpBlocks(accountId, NetworkDomainId.ToString()), RequestFileResponseType.AsGoodResponse("ListPublicIpBlocksResponse.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressAccessor(webApi);

            var result = await ipAddressManagementAccessor.GetPublicIpBlocks(NetworkDomainId);

            Assert.AreEqual(2, result.Count());
            Assert.IsNotNull(result.First().networkDomainId);
        }

        [TestMethod]
        public async Task GetPublicIpBlockPaginated_ReturnsResponse()
        {
            var publicIpBlockId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.GetPublicIpBlock(accountId, publicIpBlockId.ToString()), RequestFileResponseType.AsGoodResponse("GetPublicIpBlockReponse.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressAccessor(webApi);

            var result = await ipAddressManagementAccessor.GetPublicIpBlock(NetworkDomainId, publicIpBlockId);

            Assert.IsNotNull(result.networkDomainId);
            Assert.IsNotNull(result.baseIp);
            Assert.IsNotNull(result.size);
            Assert.IsNotNull(result.createTime);
            Assert.IsNotNull(result.state);
        }

        [TestMethod]
        public async Task DeletePublicIpBlock_ReturnsResponse()
        {
            var publicIpBlockId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.RemovePublicIpv4AddressBlock(accountId), RequestFileResponseType.AsGoodResponse("DeletePublicIpBlock.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressAccessor(webApi);
            

            var result = await ipAddressManagementAccessor.DeletePublicIpBlock(NetworkDomainId, publicIpBlockId);

            Assert.AreEqual("REMOVE_PUBLIC_IP_BLOCK", result.operation);
            Assert.AreEqual("OK", result.responseCode);
        }

        [TestMethod]
        public async Task GetReservedPublicAddressesForNetworkDomain_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.GetReservedPublicAddresses(accountId, NetworkDomainId.ToString()), RequestFileResponseType.AsGoodResponse("GetReservedPublicAddresses.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressAccessor(webApi);

            var editVirtualListener = new editVirtualListener();

            var result = await ipAddressManagementAccessor.GetReservedPublicAddressesForNetworkDomain(NetworkDomainId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetReservedPublicAddressesForNetwork_ReturnsResponse()
        {
            var ipAddressManagementAccessorId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.GetReservedPublicAddressesForNetwork(accountId, NetworkDomainId.ToString()), RequestFileResponseType.AsGoodResponse("GetReservedPublicAddressesForNetwork.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressAccessor(webApi);

            var result = await ipAddressManagementAccessor.GetReservedPublicAddressesForNetwork(NetworkDomainId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetReservedPrivateAddressesForVlan_ReturnsResponse()
        {
            var vlanId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.GetReservedPrivateAddresses(accountId, vlanId.ToString()), RequestFileResponseType.AsGoodResponse("GetReservedPrivateAddresses.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressAccessor(webApi);
            

            var editVirtualListener = new editVirtualListener();

            var result = await ipAddressManagementAccessor.GetReservedPrivateAddressesForVlan(vlanId);
            Assert.AreEqual(4, result.Count());
        }
    }
}
