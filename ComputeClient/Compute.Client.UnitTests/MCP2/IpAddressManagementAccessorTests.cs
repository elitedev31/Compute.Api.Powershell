using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Vip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.MCP2
{
    [TestClass]
    public class IpAddressManagementAccessorTests : BaseApiClientTestFixture
    {
        string NetworkDomainId = Guid.NewGuid().ToString();

        [TestMethod]
        public async Task AddPublicIpBlockReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.AddPublicIpBlock(accountId), RequestFileResponseType.AsGoodResponse("AddPublicIpBlockResponse.xml"));

            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressManagementAccessor(webApi);

            var domainResponse = await ipAddressManagementAccessor.AddPublicIpBlock(NetworkDomainId);

            Assert.IsNotNull(domainResponse);
            Assert.AreEqual("OK", domainResponse.responseCode);
            Assert.AreEqual("ADD_PUBLIC_IP_BLOCK", domainResponse.operation);
            Assert.IsNotNull(domainResponse.info.Any(q => q.name == "publicIpBlockId"));
        }

        [TestMethod]
        public async Task ListPublicIpBlocksReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.GetPublicIpBlocks(accountId, NetworkDomainId), RequestFileResponseType.AsGoodResponse("ListPublicIpBlocksResponse.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressManagementAccessor(webApi);

            var result = await ipAddressManagementAccessor.GetPublicIpBlocks(NetworkDomainId);

            Assert.AreEqual(2, result.Count());
            Assert.IsNotNull(result.First().networkDomainId);
        }

        [TestMethod]
        public async Task GetPublicIpBlockReturnsPaginatedResponse()
        {
            var publicIpBlockId = Guid.NewGuid().ToString();
            requestsAndResponses.Add(ApiUris.GetPublicIpBlock(accountId, publicIpBlockId), RequestFileResponseType.AsGoodResponse("GetPublicIpBlockReponse.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressManagementAccessor(webApi);

            var result = await ipAddressManagementAccessor.GetPublicIpBlock(NetworkDomainId, publicIpBlockId);

            Assert.IsNotNull(result.networkDomainId);
            Assert.IsNotNull(result.baseIp);
            Assert.IsNotNull(result.size);
            Assert.IsNotNull(result.createTime);
            Assert.IsNotNull(result.state);
        }

        [TestMethod]
        public async Task DeletePublicIpBlockReturnsResponse()
        {
            var publicIpBlockId = Guid.NewGuid().ToString();
            requestsAndResponses.Add(ApiUris.RemovePublicIpv4AddressBlock(accountId), RequestFileResponseType.AsGoodResponse("DeletePublicIpBlock.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressManagementAccessor(webApi);
            

            var result = await ipAddressManagementAccessor.DeletePublicIpBlock(NetworkDomainId, publicIpBlockId);

            Assert.AreEqual("REMOVE_PUBLIC_IP_BLOCK", result.operation);
            Assert.AreEqual("OK", result.responseCode);
        }

        [TestMethod]
        public async Task GetReservedPublicAddressesReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.GetReservedPublicAddresses(accountId, NetworkDomainId), RequestFileResponseType.AsGoodResponse("GetReservedPublicAddresses.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressManagementAccessor(webApi);

            var editVirtualListener = new editVirtualListener();

            var result = await ipAddressManagementAccessor.GetReservedPublicAddresses(NetworkDomainId);
            Assert.IsNotNull(result.ip);
        }

        [TestMethod]
        public async Task GetReservedPublicAddressesForNetworkReturnsResponse()
        {
            var ipAddressManagementAccessorId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.GetReservedPublicAddressesForNetwork(accountId, NetworkDomainId), RequestFileResponseType.AsGoodResponse("GetReservedPublicAddressesForNetwork.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressManagementAccessor(webApi);

            var result = await ipAddressManagementAccessor.GetReservedPublicAddressesForNetwork(NetworkDomainId);
            Assert.IsNotNull(result.ip);
        }

        [TestMethod]
        public async Task GetReservedPrivateAddressesReturnsResponse()
        {
            var vlanId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.GetReservedPrivateAddresses(accountId, vlanId.ToString()), RequestFileResponseType.AsGoodResponse("GetReservedPrivateAddresses.xml"));
            var webApi = GetWebApiClient();
            var ipAddressManagementAccessor = new IpAddressManagementAccessor(webApi);
            

            var editVirtualListener = new editVirtualListener();

            var result = await ipAddressManagementAccessor.GetReservedPrivateAddresses(vlanId);
            Assert.AreEqual(4, result.ipv4.Count());
        }
    }
}
