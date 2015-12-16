using System;
using DD.CBU.Compute.Api.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests
{
    [TestClass]
    public class ApiUriTests
    {
        //private static string orgIdString = "a3d9aacc-a273-45a5-919d-0f4c41c0763b";
        readonly Guid _orgId = Guid.NewGuid();

        [TestMethod]
        public void ReturnsGetDomainNatRulesUri()
        {
            var networkDomainId = Guid.NewGuid();
            var uri = ApiUris.GetDomainNatRules(_orgId, networkDomainId.ToString());
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/network/natRule?networkDomainId="+networkDomainId, uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsGetNatRuleUri()
        {
            var networkId = Guid.NewGuid();
            var uri = ApiUris.GetNatRule(_orgId, networkId.ToString());
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/network/natRule/"+ networkId, uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsCreateNatRuleUri()
        {
            var uri = ApiUris.CreateNatRule(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/network/createNatRule", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsDeleteNatRuleUri()
        {
            var uri = ApiUris.DeleteNatRule(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/network/deleteNatRule", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsCreatePoolUri()
        {
            var uri = ApiUris.CreatePool(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/createPool", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsGetPoolsUri()
        {
            var uri = ApiUris.GetPools(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/pool", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsGetPoolUri()
        {
            var poolId = Guid.NewGuid();
            var uri = ApiUris.GetPool(_orgId, poolId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/pool/"+ poolId, uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsEditPoolUri()
        {
            var uri = ApiUris.EditPool(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/editPool", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsDeletePoolUri()
        {
            var uri = ApiUris.DeletePool(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/deletePool", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsAddPoolMemberUri()
        {
            var uri = ApiUris.AddPoolMember(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/addPoolMember", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsGetPoolMembersUri()
        {
            var uri = ApiUris.GetPoolMembers(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/poolMember", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsGetPoolMemberUri()
        {
            var memberId = Guid.NewGuid();
            var uri = ApiUris.GetPoolMember(_orgId, memberId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/poolMember/"+ memberId, uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsEditPoolMemberUri()
        {
            var uri = ApiUris.EditPoolMember(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/editPoolMember", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsDeletePoolMemberUri()
        {
            var uri = ApiUris.DeletePoolMember(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/removePoolMember", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsAddVipNodeUri()
        {
            var uri = ApiUris.AddVipNode(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/createNode", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsGetVipNodesUri()
        {
            var uri = ApiUris.GetVipNodes(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/node", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsGetVipNodeUri()
        {
            var nodeId = Guid.NewGuid();
            var uri = ApiUris.GetVipNode(_orgId, nodeId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/node/"+ nodeId, uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsEditVipNodeUri()
        {
            var uri = ApiUris.EditVipNode(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/editNode", uri.OriginalString);
        }

        [TestMethod]
        public void ReturnsDeleteVipNodeUri()
        {
            var uri = ApiUris.DeleteVipNode(_orgId);
            Assert.AreEqual(ApiUris.MCP2_1_PREFIX + _orgId + "/networkDomainVip/deleteNode", uri.OriginalString);
        }
    }
}