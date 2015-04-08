using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Client.IntegrationTests
{
	using Api.Client;
	using Api.Contracts.Datacenter;
	using Api.Contracts.Directory;

	using DD.CBU.Compute.Api.Client.Network;
	using DD.CBU.Compute.Api.Client.Network20;
	using DD.CBU.Compute.Api.Contracts;

	/// <summary>
	///		Integration tests for the CaaS API client's functionality relating to data centres.
	/// </summary>
	[TestClass]
	public class NetworkDomainTests : BaseTestFixture
	{
		/// <summary>
		///		Create a new API client data centre Integration-test set.
		/// </summary>
		public NetworkDomainTests()
		{
		}

		/// <summary>
		///		The Integration-test execution context.
		/// </summary>
		public TestContext TestContext
		{
			get;
			set;
		}

		/// <summary>
		///		Get all network domains.
		/// </summary>
		/// <returns>
		///		A <see cref="Task"/> representing the asynchronous unit-test execution.
		/// </returns>
		[TestMethod]
		public async Task GetAvailableNetworkDomains()
		{
			ICredentials credentials = GetIntegrationTestCredentials();

			using (ComputeApiClient computeApiClient = new ComputeApiClient("apinashpcs01.opsourcecloud.net"))
			{
				IAccount account = await
					computeApiClient
						.LoginAsync(credentials);
				Assert.IsNotNull(account);

				Guid organizationId = account.OrganizationId;
				Assert.AreNotEqual(Guid.Empty, organizationId);

				var networkDomains = (await computeApiClient.GetNetworkDomains()).ToList();

				Assert.AreNotEqual(0, networkDomains.Count);

				TestContext.WriteLine("Domains List \n");

				foreach (NetworkDomain domain in networkDomains)
				{
					TestContext.WriteLine("Name & Type : {0} - {1}", domain.name, domain.type);
					TestContext.WriteLine("Description: {0}", domain.description);
				}
			}
		}

		/// <summary>
		///		Create network domain.
		/// </summary>
		/// <returns>
		///		A <see cref="Task"/> representing the asynchronous unit-test execution.
		/// </returns>
		[TestMethod]
		public async Task CreateNetworkDomain()
		{
			ICredentials credentials = GetIntegrationTestCredentials();

			using (ComputeApiClient computeApiClient = new ComputeApiClient("apinashpcs01.opsourcecloud.net"))
			{
				IAccount account = await computeApiClient.LoginAsync(credentials);
				Assert.IsNotNull(account);

				Guid organizationId = account.OrganizationId;
				Assert.AreNotEqual(Guid.Empty, organizationId);

				var newDomain = new DeployNetworkDomain { location = "NASH_PCS01_N2_VMWARE_1", name = "Test Network Domain", description = "This is test Network Domain created using Network 2.0 API", type = "ESSENTIALS" };

				var result = await computeApiClient.CreateNetworkDomain(account.OrganizationId, newDomain);

				Assert.AreEqual("OK", result.responseCode);
				Assert.IsTrue(result.info.Length > 0);
				Assert.IsNotNull(result.info[0].ToString());
			}
		}
	}
}
