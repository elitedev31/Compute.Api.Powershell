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
	public class DatacenterTests
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

				IReadOnlyList<IDatacenterDetail> dataCenters =
					await computeApiClient
						.GetAvailableDataCenters(organizationId);

				Assert.AreNotEqual(0, dataCenters.Count);
				foreach (IDatacenterDetail dataCenter in dataCenters)
					TestContext.WriteLine("{0}:{1} ({2})", dataCenter.LocationCode, dataCenter.DisplayName, dataCenter.Country);
			}
		}

		/// <summary>
		///		Get CaaS account credentials for use during integration tests.
		/// </summary>
		/// <returns>
		///		An <see cref="ICredentials"/> implementation representing the credentials to use when authenticating to the API.
		/// </returns>
		/// <remarks>
		///		Since this is an open-source project, I can't really supply valid credentials as part of the source code (so we just get them from the registry).
		/// </remarks>
		static ICredentials GetIntegrationTestCredentials()
		{
			const string credentialsKeyName = @"Software\Dimension Data\Cloud\API Client\Credentials\Test1";
			using (RegistryKey credentialsKey = Registry.CurrentUser.OpenSubKey(credentialsKeyName))
			{
				if (credentialsKey == null)
				{
					throw new InvalidOperationException(
						String.Format(
							"Cannot find credentials under registry key HKCU\\{0}.",
							credentialsKeyName
						)
					);
				}

				string userName = (string)credentialsKey.GetValue("Login");
				if (String.IsNullOrWhiteSpace(userName))
					throw new InvalidOperationException(
						String.Format(
							"Cannot find 'Login' value under registry key HKCU\\{0}.",
							credentialsKeyName
						)
					);
				
				string password = (string)credentialsKey.GetValue("Password");
				if (String.IsNullOrWhiteSpace(password))
					throw new InvalidOperationException(
						String.Format(
							"Cannot find 'Password' value under registry key HKCU\\{0}.",
							credentialsKeyName
						)
					);

				return new NetworkCredential(userName, password);
			}
		}
	}
}
