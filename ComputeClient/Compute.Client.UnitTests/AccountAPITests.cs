using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Datacenter;
using DD.CBU.Compute.Api.Contracts.Directory;
using DD.CBU.Compute.Api.Contracts.General;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests
{
    [TestClass]
    public class AccountAPITests : BaseApiClientTestFixture
    {
        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_get_account_details()
        {
            var client = GetApiClient("GetMyAccountDetails.xml", "myaccount");
            var result = client.LoginAsync(new NetworkCredential(string.Empty, string.Empty)).Result;
            Assert.IsTrue(client.IsLoggedIn);
            Assert.AreEqual(result.OrganizationId, new Guid("1831c1a9-9c03-44df-a5a4-f2a4662d6bde"));
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_be_able_to_delete_sub_administrator_account()
        {
            var username = "Joe Smith";
            var someOrgId = Guid.NewGuid();
            var expectedRelativeUrl = string.Format("{0}/account/{1}?delete", someOrgId, username);
            var client = GetApiClient("DeleteSubAdministratorAccount.xml", expectedRelativeUrl);
            ApiStatus result = client.DeleteSubAdministratorAccount(someOrgId, username).Result;

            Assert.AreEqual("SUCCESS", result.Result);
            Assert.AreEqual("Delete Account", result.Operation);
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_be_able_to_designate_primary_administrator_account()
        {
            var username = "Joe Smith";
            var someOrgId = Guid.NewGuid();

            var expectedRelativeUrl = string.Format("{0}/account/{1}?primary", someOrgId, username);
            var client = GetApiClient("DesignatePrimaryAdministratorAccount.xml", expectedRelativeUrl);

            ApiStatus result = client.DesignatePrimaryAdministratorAccount(someOrgId, username).Result;
            Assert.AreEqual("SUCCESS", result.Result);
            Assert.AreEqual("Designate Primary Admin Account", result.Operation);
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_be_able_to_list_data_centers_with_maintenance_statuses()
        {
            var someOrgId = Guid.NewGuid();
            var expectedRelativeUrl = string.Format("{0}/datacenterWithMaintenanceStatus?", someOrgId);
            var client = GetApiClient("ListDataCentersWithMaintenanceStatus.xml", expectedRelativeUrl);

            var dataCenters = client.GetListOfDataCentersWithMaintenanceStatuses(someOrgId).Result.ToArray();

            Assert.AreEqual(1, dataCenters.Count());

            var firstResult = dataCenters.First();
            Assert.AreEqual("US - East 2", firstResult.displayName);
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_list_multi_geography_regions_with_key()
        {
            var someOrgId = Guid.NewGuid();
            var expectedRelativeUrl = string.Format("{0}/multigeo", someOrgId);

            var client = GetApiClient("ListMultiGeographyRegionsWithKey.xml", expectedRelativeUrl);
            var regions = client.GetListOfMultiGeographyRegions(someOrgId).Result.ToArray();

            Assert.AreEqual(2, regions.Count());
            Assert.AreEqual("lk76kf30-2cb3-1791-5476-231567-09gt87", regions[0].id);
            Assert.AreEqual("bf43kf30-2c83-11e1-9963-001517-45hj54", regions[1].id);
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_list_software_labels()
        {
            var someOrgId = Guid.NewGuid();
            var expectedRelativeUrl = string.Format("{0}/softwarelabel", someOrgId);
            var client = GetApiClient("ListSoftwareLabels.xml", expectedRelativeUrl);

            var result = client.GetListOfSoftwareLabels(someOrgId).Result;
            var labels = result.ToArray();
            Assert.AreEqual(5, labels.Count());
            Assert.AreEqual("MSSQL2008R2E", labels[1].id);
            Assert.AreEqual("MSSQL2012R2S", labels[4].id);
        }

        [TestMethod]
        [TestCategory("Http POST Methods")]
        public void Should_add_sub_administrator_account()
        {
            var someOrgId = Guid.NewGuid();
            var relativeUrl = string.Format("{0}/account", someOrgId);
            var sampleFile = "AddSubAdministratorAccount.xml";

            var apiClient = GetComputeApiClientWithMockedPostCalls(sampleFile, relativeUrl);

            var status = apiClient.AddSubAdministratorAccount(someOrgId, new Account()).Result;

            Assert.AreEqual(status.result, "SUCCESS");
        }

        [TestMethod]
        [TestCategory("Http POST Methods")]
        public void Should_update_administrator_account()
        {
            var someOrgId = Guid.NewGuid();
            var username = "SomeUser123";

            var relativeUrl = string.Format("{0}/account/{1}", someOrgId, username);
            var sampleFile = "UpdateAdministratorAccount.xml";

            var account = new Account()
            {
                UserName = "User123",
                FullName = "John Smith",
            };

            account.MemberOfRoles.Add(new Role() { Name = "Administrator1" });
            account.MemberOfRoles.Add(new Role() { Name = "Administrator2" });

            var apiClient = GetComputeApiClientWithMockedPostCalls(sampleFile, relativeUrl);
            var status = apiClient.UpdateAdministratorAccount(someOrgId, account).Result;

            Assert.AreEqual(status.result, "SUCCESS");
        }

        [TestMethod]
        [TestCategory("Http GET Methods")]
        public void Should_be_able_to_list_accounts()
        {
            var someOrgid = Guid.NewGuid();
            var expectedUrl = string.Format("{0}/account", someOrgid);
            var client = GetApiClient("ListAccounts.xml", expectedUrl);

            var accounts = client.GetAccounts(someOrgid).Result;
            Assert.AreEqual(2, accounts.Count());
        }

        private ComputeApiClient GetComputeApiClientWithMockedPostCalls(string sampleFile, string relativeUrl)
        {
            Action<IHttpClient, string> configureFakeHttpClient =
                (client, xml) =>
                    A.CallTo(() => client.PostAsync(A<Uri>.Ignored, A<HttpContent>.Ignored)).Returns(CreateMessage(xml));
            var sampleFolderLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\SampleOutputs");
            var sampleFileLocation = Path.Combine(sampleFolderLocation, sampleFile);

            var apiClient = GetApiClient(sampleFileLocation, relativeUrl, configureFakeHttpClient);
            return apiClient;
        }
    }
}
