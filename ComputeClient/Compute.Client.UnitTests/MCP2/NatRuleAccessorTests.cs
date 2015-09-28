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
    public class NatRuleAccessorTests : BaseApiClientTestFixture
    {
        [TestMethod]
        public async Task CreateNatRuleReturnsResponse()
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
        public async Task ListNatRulesReturnsResponse()
        {
            var networkDomainId = Guid.NewGuid().ToString();
            requestsAndResponses.Add(ApiUris.GetDomainNatRules(accountId, networkDomainId), RequestFileResponseType.AsGoodResponse("ListNatRules.xml"));
            var webApi = GetWebApiClient();
            var NatRule = new NatAccessor(webApi);

            var result = await NatRule.GetNatRules(networkDomainId);

            Assert.AreEqual(2, result.natRule.Count());
            Assert.IsNotNull(result.natRule.First().internalIp);
            Assert.IsNotNull(result.natRule.First().externalIp);
        }

        [TestMethod]
        public async Task GetNatRuleReturnsResponse()
        {
            var natRuleId = Guid.NewGuid().ToString();
            requestsAndResponses.Add(ApiUris.GetNatRule(accountId, natRuleId), RequestFileResponseType.AsGoodResponse("GetNatRule.xml"));
            var webApi = GetWebApiClient();
            var NatRule = new NatAccessor(webApi);

            var result = await NatRule.GetNatRule(natRuleId);

            Assert.IsNotNull(result.internalIp);
            Assert.IsNotNull(result.externalIp);
        }

        [TestMethod]
        public async Task DeleteNatRuleReturnsResponse()
        {
            var natRuleId = Guid.NewGuid().ToString();
            requestsAndResponses.Add(ApiUris.DeleteNatRule(accountId), RequestFileResponseType.AsGoodResponse("DeleteNatRule.xml"));
            var webApi = GetWebApiClient();
            var NatRule = new NatAccessor(webApi);

            var result = await NatRule.DeleteNatRule(natRuleId);

            Assert.AreEqual("DELETE_NAT_RULE", result.operation);
            Assert.AreEqual("OK", result.responseCode);
        }
    }
}
