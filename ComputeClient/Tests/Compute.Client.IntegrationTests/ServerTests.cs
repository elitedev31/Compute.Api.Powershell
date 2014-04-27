using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Client.IntegrationTests
{
	using Api.Client;
	using Api.Contracts.Datacenter;
	using Api.Contracts.Server;

	/// <summary>
	///		Integration tests for the CaaS API client's server-related functionality.
	/// </summary>
	[TestClass]
	public class ServerTests : BaseTestFixture
	{
		/// <summary>
		///		Create a new CaaS API client integration test-set for server-related functionality.
		/// </summary>
		public ServerTests()
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
		///		Get all system-created images in location AU1.
		/// </summary>
		/// <returns>
		///		A <see cref="Task"/> representing the asynchronous test execution.
		/// </returns>
		[TestMethod]
		public async Task GetAllSystemImagesAU1()
		{
			IReadOnlyList<DeployedImageWithSoftwareLabelsType> images;
			using (ComputeApiClient apiClient = new ComputeApiClient("AU"))
			{
				await apiClient.LoginAsync(
					accountCredentials: GetIntegrationTestCredentials()
				);

				images = await apiClient.GetImages("AU1");
			}

			foreach (var image in images)
			{
				TestContext.WriteLine(
					"Image '{0}' (Id = '{1}') - '{2}' ({3})",
					image.name,
					image.id,
					image
						.machineSpecification
						.operatingSystem
						.displayName,
					image
						.machineSpecification
						.operatingSystem
						.type
				);
			}
		}

		/// <summary>
		///		Get all system-created images in all locations.
		/// </summary>
		/// <returns>
		///		A <see cref="Task"/> representing the asynchronous test execution.
		/// </returns>
		[TestMethod]
		public async Task GetAllSystemImagesAllLocations()
		{
			using (ComputeApiClient apiClient = new ComputeApiClient("AU"))
			{
				await apiClient.LoginAsync(
					accountCredentials: GetIntegrationTestCredentials()
				);

				foreach (DatacenterSummary datacenter in await apiClient.GetAvailableDataCenters())
				{
					TestContext.WriteLine("DataCenter '{0}' ({1}):", datacenter.LocationCode, datacenter.DisplayName);

					foreach (var image in await apiClient.GetImages(datacenter.LocationCode))
					{
						TestContext.WriteLine(
							"\tImage '{0}' (Id = '{1}') - '{2}' ({3})",
							image.name,
							image.id,
							image
								.machineSpecification
								.operatingSystem
								.displayName,
							image
								.machineSpecification
								.operatingSystem
								.type
						);
					}
				}
			}
		}
	}
}
