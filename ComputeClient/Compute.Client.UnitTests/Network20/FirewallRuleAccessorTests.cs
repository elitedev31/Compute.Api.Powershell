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
	public class FirewallRuleAccessorTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task CreateFirewallRule_ReturnsResponse()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.CreateFirewallRule(this.accountId), RequestFileResponseType.AsGoodResponse("CreateFirewallRuleResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new FirewallRuleAccessor(client);

            var response = await accessor.CreateFirewallRule(new CreateFirewallRuleType()
			{
                name = "My Firewall Rule"
			});

			Assert.IsNotNull(response);
            Assert.AreEqual("CREATE_FIREWALL_RULE", response.operation);
            Assert.AreEqual("OK", response.responseCode);
            Assert.AreEqual("d0a20f59-77b9-4f28-a63b-e58496b73a6c", response.info[0].value);
        }

        [TestMethod]
        public async Task GetFirewallRule_ReturnsResponse()
        {
            var firewallRuleId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetFirewallRule(this.accountId, firewallRuleId), RequestFileResponseType.AsGoodResponse("GetFirewallRuleResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new FirewallRuleAccessor(client);

            var response = await accessor.GetFirewallRule(firewallRuleId);

            Assert.IsNotNull(response);
            Assert.AreEqual("NORMAL", response.state);
            Assert.AreEqual("CCDEFAULT.BlockOutboundMailIPv4", response.name);
            Assert.AreEqual("412f0e28-20f5-44ce-beb7-385fb758a82c", response.id);
        }

        [TestMethod]
        public async Task GetFirewallRules_ReturnsResponse()
        {
            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.GetFirewallRules(this.accountId), RequestFileResponseType.AsGoodResponse("ListFirewallRulesResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new FirewallRuleAccessor(client);

            var response = await accessor.GetFirewallRules();

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Count());
        }

        [TestMethod]
        public async Task EditFirewallRule_ReturnsResponse()
        {
            var firewallRuleId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.EditFirewallRule(this.accountId), RequestFileResponseType.AsGoodResponse("EditFirewallRuleResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new FirewallRuleAccessor(client);

            var response = await accessor.EditFirewallRule(new EditFirewallRuleType
            {
                id = firewallRuleId.ToString()
            });

            Assert.IsNotNull(response);
            Assert.AreEqual("EDIT_FIREWALL_RULE", response.operation);
        }

        [TestMethod]
        public async Task DeleteFirewallRule_ReturnsResponse()
        {
            var firewallRuleId = Guid.NewGuid();

            requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
            requestsAndResponses.Add(ApiUris.DeleteFirewallRule(this.accountId), RequestFileResponseType.AsGoodResponse("DeleteFirewallRuleResponse.xml"));

            var client = GetWebApiClient();
            var accessor = new FirewallRuleAccessor(client);

            var response = await accessor.DeleteFirewallRule(firewallRuleId);

            Assert.IsNotNull(response);
            Assert.AreEqual("DELETE_FIREWALL_RULE", response.operation);
        }
    }
}
