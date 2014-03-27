using System;
using System.IO;
using System.Net;
using System.Net.Http;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Interfaces;
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
            var httpClient = GetFakeHttpClientFromSampleFile("GetMyAccountDetails.xml", "myaccount");
            var client = new ComputeApiClient(httpClient);
            var result = client.LoginAsync(new NetworkCredential(string.Empty, string.Empty)).Result;
            Assert.IsTrue(client.IsLoggedIn);

            Assert.AreEqual(result.OrganizationId, new Guid("1831c1a9-9c03-44df-a5a4-f2a4662d6bde"));
        }
    }
}
