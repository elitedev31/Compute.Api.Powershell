using System;
using System.Linq;
using System.Net;

using DD.CBU.Compute.Api.Contracts.General;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests
{
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.Directory;

    [TestClass]
    public class AccountAPITests : BaseApiClientTestFixture
    {
        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_get_account_details()
        {
            var client = GetApiClient("GetMyAccountDetails.xml", "myaccount");
            var result = client.LoginAsync(new NetworkCredential(string.Empty, string.Empty)).Result;
            Assert.IsTrue(client.Account != null);
            Assert.AreEqual(result.OrganizationId, new Guid("1831c1a9-9c03-44df-a5a4-f2a4662d6bde"));
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public async Task Should_be_able_to_delete_sub_administrator_account()
        {
            var username = "Joe Smith";
            var someOrgId = Guid.NewGuid();
            var expectedRelativeUrl = string.Format("{0}/account/{1}?delete", someOrgId, username);
            var client = GetApiClient("DeleteSubAdministratorAccount.xml", expectedRelativeUrl);
            var result = client.DeleteSubAdministratorAccountAsync(username).Result;

            // Assert.AreEqual("SUCCESS", result.Result);
            // Assert.AreEqual("Delete Account", result.Operation);
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_be_able_to_designate_primary_administrator_account()
        {
            var username = "Joe Smith";
            var someOrgId = Guid.NewGuid();

            var expectedRelativeUrl = string.Format("{0}/account/{1}?primary", someOrgId, username);
            var client = GetApiClient("DesignatePrimaryAdministratorAccount.xml", expectedRelativeUrl);

            ApiStatus result = client.DesignatePrimaryAdministratorAccountAsync(username).Result;
            Assert.AreEqual("SUCCESS", result.Result);
            Assert.AreEqual("Designate Primary Admin Account", result.Operation);
        }

        [TestMethod]
        public void Should_be_able_to_list_data_centers_with_maintenance_statuses()
        {
            var someOrgId = Guid.NewGuid();
            var expectedRelativeUrl = string.Format("{0}/datacenterWithMaintenanceStatus?", someOrgId);
            var client = GetApiClient("ListDataCentersWithMaintenanceStatus.xml", expectedRelativeUrl);
            
            var dataCenters = client.GetDataCentersWithMaintenanceStatuses().Result.ToArray();

            Assert.AreEqual(1, dataCenters.Count());

            var firstResult = dataCenters.First();
            Assert.AreEqual("US - East 2", firstResult.displayName);
        }

        [TestMethod]
        public void ShouldListMultiGeographyRegionsWithKey()
        {
            var someOrgId = Guid.NewGuid();
            var expectedRelativeUrl = string.Format("{0}/multigeo", someOrgId);
            
            var client = GetApiClient("ListMultiGeographyRegionsWithKey.xml", expectedRelativeUrl);
            //var regions = client.GetListOfMultiGeographyRegions(someOrgId).Result;

            Assert.Inconclusive("TODO: Finish this test");
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_be_able_to_list_accounts()
        {
            var someOrgid = Guid.NewGuid();
            var expectedUrl = string.Format("{0}/account", someOrgid);
            var client = GetApiClient("ListAccounts.xml", expectedUrl);

            var accounts = client.GetAccounts().Result;
            Assert.AreEqual(2, accounts.Count());
        }
    }
}
