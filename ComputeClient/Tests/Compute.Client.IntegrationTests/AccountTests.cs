using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Client.IntegrationTests
{
	using Api.Client;
	using Api.Contracts.Directory;

	/// <summary>
	///		Integration tests for the CaaS  <see cref="ComputeApiClient.LoginAsync">login</see> / <see cref="ComputeApiClient.Logout">logout</see> functionality.
	/// </summary>
	[TestClass]
	public class AccountTests : BaseTestFixture
	{
		/// <summary>
		///		Create a new Account Integration-test set.
		/// </summary>
		public AccountTests()
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
		///		Attempt to log in with valid credentials.
		/// </summary>
		/// <returns>
		///		A <see cref="Task"/> representing the asynchronous unit-test execution.
		/// </returns>
		[TestMethod]
		public async Task LoginWithValidCredentials()
		{
			ICredentials credentials = GetIntegrationTestCredentials();
			using (ComputeApiClient computeApiClient = new ComputeApiClient("au"))
			{
				IAccount account = await
					computeApiClient
						.LoginAsync(credentials);
				Assert.IsNotNull(account);
				Assert.IsNotNull(computeApiClient.Account);

				TestContext.WriteLine("Account organisation Id: '{0}", account.OrganizationId);
				TestContext.WriteLine("Account full name: '{0}'", account.FullName);
				TestContext.WriteLine("Account email address: '{0}'", account.EmailAddress);
			}
		}

		/// <summary>
		///		Attempt to log in with valid credentials.
		/// </summary>
		/// <returns>
		///		A <see cref="Task"/> representing the asynchronous unit-test execution.
		/// </returns>
		[TestMethod]
		public async Task LoginWithInvalidCredentials()
		{
			ICredentials credentials = new NetworkCredential(
				userName: "dd_cbu_obviously_invalid_credentials",
				password: "CaaS Powershell integration test"
			);
			using (ComputeApiClient computeApiClient = new ComputeApiClient("au"))
			{
				try
				{
					await computeApiClient.LoginAsync(credentials);
					
					Assert.Fail("LoginAsync with invalid credentials failed to raise a ComputeApiException.");
				}
				catch (ComputeApiException eInvalidCredentials)
				{
					if (eInvalidCredentials.Error != ComputeApiError.InvalidCredentials)
						throw;
				}
			}
		}
	}
}
