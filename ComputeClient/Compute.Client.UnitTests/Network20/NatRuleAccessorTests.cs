using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.Network20
{
    [TestClass]
    public class NatRuleAccessorTests : BaseApiClientTestFixture
    {
        [TestMethod]
        public async Task CreateNatRule_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.CreateNatRule(accountId), RequestFileResponseType.AsGoodResponse("CreateNatRuleResponse.xml"));

            var webApi = GetWebApiClient();
            var createNatRule = new createNatRule();

            var NatRule = new NatAccessor(webApi);
            ResponseType domainResponse = await NatRule.CreateNatRule(createNatRule);

            Assert.IsNotNull(domainResponse);
            Assert.AreEqual("OK", domainResponse.responseCode);
            Assert.AreEqual("CREATE_NAT_RULE", domainResponse.operation);
            Assert.IsNotNull(domainResponse.info.Any(q => q.name == "natRuleId"));
        }

        [TestMethod]
        public async Task GetNatRules_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.GetDomainNatRules(accountId, networkDomainId.ToString()), RequestFileResponseType.AsGoodResponse("ListNatRules.xml"));
            var webApi = GetWebApiClient();
            var NatRule = new NatAccessor(webApi);

            var result = await NatRule.GetNatRules(networkDomainId);

            Assert.AreEqual(2, result.Count());
            Assert.IsNotNull(result.First().internalIp);
            Assert.IsNotNull(result.First().externalIp);
        }

        [TestMethod]
        public async Task GetNatRulesPaginated_ReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.GetDomainNatRules(accountId, networkDomainId.ToString()), RequestFileResponseType.AsGoodResponse("ListNatRules.xml"));
            var webApi = GetWebApiClient();
            var NatRule = new NatAccessor(webApi);

            var result = await NatRule.GetNatRulesPaginated(networkDomainId);

            Assert.AreEqual(2, result.items.Count());
            Assert.IsNotNull(result.items.First().internalIp);
            Assert.IsNotNull(result.items.First().externalIp);
        }

        [TestMethod]
        public async Task GetNatRule_ReturnsResponse()
        {
            var natRuleId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.GetNatRule(accountId, natRuleId.ToString()), RequestFileResponseType.AsGoodResponse("GetNatRule.xml"));
            var webApi = GetWebApiClient();
            var NatRule = new NatAccessor(webApi);

            var result = await NatRule.GetNatRule(natRuleId);

            Assert.IsNotNull(result.internalIp);
            Assert.IsNotNull(result.externalIp);
        }

        [TestMethod]
        public async Task DeleteNatRule_ReturnsResponse()
        {
            var natRuleId = Guid.NewGuid();
            requestsAndResponses.Add(ApiUris.DeleteNatRule(accountId), RequestFileResponseType.AsGoodResponse("DeleteNatRule.xml"));
            var webApi = GetWebApiClient();
            var NatRule = new NatAccessor(webApi);

            var result = await NatRule.DeleteNatRule(natRuleId);

            Assert.AreEqual("DELETE_NAT_RULE", result.operation);
            Assert.AreEqual("OK", result.responseCode);
        }
    }
}
