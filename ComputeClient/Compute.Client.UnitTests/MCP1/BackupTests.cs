using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Server20;
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.General;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests.MCP1
{
	/// <summary>	(Unit Test Class) a backup tests. </summary>
	/// <seealso cref="T:Compute.Client.UnitTests.BaseApiClientTestFixture"/>
	[TestClass]
	public class BackupTests : BaseApiClientTestFixture
	{
		/// <summary>	Identifier for the server. </summary>
		private const string ServerId = "d577a691-e116-4913-a440-022d2729fc84";

		/// <summary>	Identifier for the backup client. </summary>
		private const string BackupClientId = "d577a691-e116-4913-a440-022d2729fc99";

		/// <summary>	(Unit Test Method) tests restore backup. </summary>
		/// <returns>	A Task. </returns>
		[TestMethod]
		public async Task RestoreBackupTest()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.RestoreBackup(accountId, ServerId, BackupClientId), RequestFileResponseType.AsGoodResponse("RestoreBackupResponse.xml"));

			var client = GetApiClient();
			await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));
			Status response =
				await client.Backup.InPlaceRestore(ServerId, new BackupClientDetailsType {id = BackupClientId}, DateTime.Now);

			Assert.IsNotNull(response);
			Assert.AreEqual(response.resultCode, "REASON_0");
			Assert.AreEqual(response.IsSuccessful(), true);
		}

		/// <summary>	(Unit Test Method) tests restore backup out of place. </summary>
		/// <returns>	A Task. </returns>
		[TestMethod]
		public async Task RestoreBackupOutOfPlaceTest()
		{
			requestsAndResponses.Add(ApiUris.MyAccount, RequestFileResponseType.AsGoodResponse("GetMyAccountDetails.xml"));
			requestsAndResponses.Add(ApiUris.RestoreBackup(accountId, ServerId, BackupClientId), RequestFileResponseType.AsGoodResponse("RestoreBackupOutOfPlaceResponse.xml"));

			var client = GetApiClient();
			await client.LoginAsync(new NetworkCredential(string.Empty, string.Empty));

			const string targetBackupClientId = "d577a691-e116-4913-a440-022d2729ff99";
			Status response =
				await client.Backup.OutOfPlaceRestore(ServerId, BackupClientId, DateTime.Now, targetBackupClientId);

			Assert.IsNotNull(response);
			Assert.AreEqual(response.resultCode, "REASON_0");
			Assert.AreEqual(response.IsSuccessful(), true);
		}
	}
}
