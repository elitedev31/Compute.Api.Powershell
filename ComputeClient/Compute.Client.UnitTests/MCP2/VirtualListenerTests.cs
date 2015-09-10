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
	public class VirtualListenerTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task CreateVirtualListenerReturnsResponse()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.CreateVirtualListener(this.accountId), RequestFileResponseType.AsGoodResponse("CreateVirtualListenerResponse.xml"));

			ComputeApiClient client = GetApiClient();
            await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));
		    ResponseType domainResponse = await client.Networking.VirtualListenerManagement.CreateVirtualListener(new createVirtualListener
		    {
		        networkDomainId = Guid.NewGuid().ToString(),
                name = "NetworkNodeTest",
                description = "Descrioption",
                connectionLimit = "100",
                connectionRateLimit = "100"
		    });

			Assert.IsNotNull(domainResponse);
			Assert.AreEqual("OK", domainResponse.responseCode);
		}
	}
}
