using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Vip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.MCP2
{
	[TestClass]
	public class VipNodeTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task ReturnsResponse ()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.AddVipNode(this.accountId), RequestFileResponseType.AsGoodResponse("CreateVipNodeResponse.xml"));

			ComputeApiClient client = GetApiClient();
            await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));
		    ResponseType domainResponse = await client.Networking.NodeManagement.CreateNode(new CreateNodeType
		    {
		        networkDomainId = Guid.NewGuid().ToString(),
                name = "NetworkNodeTest",
                description = "Descrioption",
                status = "",
                connectionLimit = "100",
                connectionRateLimit = "100",
                healthMonitorId = ""
		    });

			Assert.IsNotNull(domainResponse);
			Assert.AreEqual("OK", domainResponse.responseCode);
		}
	}
}
