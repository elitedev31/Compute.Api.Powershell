using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.MCP2
{
	[TestClass]
	public class NetworkDomainTests : BaseApiClientTestFixture
	{
		[TestMethod]
		public async Task ProvisionNetworkDomainTest ()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.CreateNetworkDomain(this.accountId), RequestFileResponseType.AsGoodResponse("CreateNetworkDomainResponse.xml"));

			ComputeApiClient client = GetApiClient();
			await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));
			ResponseType domainResponse = await client.DeployNetworkDomain(new DeployNetworkDomainType()
			{
				datacenterId = "DC1",
				description = "my description",
				name = "domain1",
				type = "ESSENTIALS"
			});

			Assert.IsNotNull(domainResponse);
			Assert.AreEqual("IN_PROGRESS", domainResponse.responseCode);
		}
	}
}
