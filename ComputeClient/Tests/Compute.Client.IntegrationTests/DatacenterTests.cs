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

	/// <summary>
	///		Integration tests for the CaaS API client's functionality relating to data centres.
	/// </summary>
	[TestClass]
	public class DatacenterTests : BaseTestFixture
	{
		/// <summary>
		///		Create a new API client data centre Integration-test set.
		/// </summary>
		public DatacenterTests()
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
		///		Get all data centres.
		/// </summary>
		/// <returns>
		///		A <see cref="Task"/> representing the asynchronous unit-test execution.
		/// </returns>
		[TestMethod]
		public async Task GetAvailableDatacenters()
		{
			ICredentials credentials = GetIntegrationTestCredentials();
			using (ComputeApiClient computeApiClient = new ComputeApiClient("au"))
			{
				IAccount account = await
					computeApiClient
						.LoginAsync(credentials);
				Assert.IsNotNull(account);

				Guid organizationId = account.OrganizationId;
				Assert.AreNotEqual(Guid.Empty, organizationId);

			    IEnumerable<DatacenterWithMaintenanceStatusType> dataCenters =
			        await computeApiClient
			            .GetDataCentersWithMaintenanceStatuses();

				Assert.AreNotEqual(0, dataCenters.Count());
                foreach (DatacenterWithMaintenanceStatusType dataCenter in dataCenters)
					TestContext.WriteLine("{0}:{1} ({2})", dataCenter.location, dataCenter.displayName, dataCenter.country);
			}
		}

	    [TestMethod]
	    public async Task TestListMultiGeoDataCentersWithKey()
	    {
            ICredentials credentials = GetIntegrationTestCredentials();
            using (ComputeApiClient computeApiClient = new ComputeApiClient("au"))
            {
                IAccount account = await
                    computeApiClient
                        .LoginAsync(credentials);
                Assert.IsNotNull(account);

                Guid organizationId = account.OrganizationId;
                Assert.AreNotEqual(Guid.Empty, organizationId);

                await computeApiClient.ListMultiGeoDataCentersWithKey(organizationId);
            }
        }
	}
}
