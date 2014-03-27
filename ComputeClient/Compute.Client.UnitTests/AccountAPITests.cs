using System;
using System.IO;
using System.Net;
using System.Net.Http;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.General;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compute.Client.UnitTests
{
    [TestClass]
    public class AccountAPITests : BaseApiClientTestFixture
    {
        [TestMethod]
        public void Should_get_account_details()
        {
            var client = GetApiClient("GetMyAccountDetails.xml", "myaccount");
            var result = client.LoginAsync(new NetworkCredential(string.Empty, string.Empty)).Result;
            Assert.IsTrue(client.IsLoggedIn);
            Assert.AreEqual(result.OrganizationId, new Guid("1831c1a9-9c03-44df-a5a4-f2a4662d6bde"));
        }

        [TestMethod]
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

        private ComputeApiClient GetApiClient(string sampleXmlFileName, string expectedRelativeUrl)
        {
            var httpClient = GetFakeHttpClientFromSampleFile(sampleXmlFileName, expectedRelativeUrl);
            var client = new ComputeApiClient(httpClient);
            return client;
        }
    }
}
