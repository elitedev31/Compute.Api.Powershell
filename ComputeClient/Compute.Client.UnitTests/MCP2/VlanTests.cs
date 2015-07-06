using System;
using System.Net;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.MCP2
{
	[TestClass]
	public class VlanTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task GetVlanTests()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, "GetMyAccountDetails.xml");
			requestsAndResponses.Add(ApiUris.GetVlanByOrgId(accountId), "GetVlansResponse.xml");

			var client = GetApiClient();
			await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));
			var servers = await client.GetVlans();
			Assert.IsNotNull(servers);
		}
	}
}
