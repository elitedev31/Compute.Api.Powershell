namespace Compute.Client.UnitTests.Utilities
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using DD.CBU.Compute.Api.Contracts.Requests.Server20;
    using DD.CBU.Compute.Api.Client.Utilities;

    [TestClass]
    public class FilterableRequestExtensionsTests
    {
        [TestMethod]
        public void AppendToUriWithNull()
        {
            var uri = new Uri("/resource", UriKind.Relative);
            var result = FilterableRequestExtensions.AppendToUri(null, uri);
            Assert.AreEqual(uri, result);
        }

        [TestMethod]
        public void AppendToUriWithExistingQuery()
        {
            var uri = new Uri("/resource?id=12", UriKind.Relative);
            var options = new ServerListOptions
            {
                Name = "Test",
                DatacenterId = "XY12"
            };

            var result = FilterableRequestExtensions.AppendToUri(options, uri);
            Assert.AreEqual("/resource?id=12&datacenterId=XY12&name=Test", result.ToString());
        }

        [TestMethod]
        public void AppendToUriWithoutExistingQuery()
        {
            var uri = new Uri("/resource", UriKind.Relative);
            var options = new ServerListOptions
            {
                Name = "Test",
                CreateTimeAfter = new DateTime(2010, 10, 10, 10, 10, 10, DateTimeKind.Utc)
            };

            var result = FilterableRequestExtensions.AppendToUri(options, uri);
            Assert.AreEqual("/resource?name=Test&createTime.GT=2010-10-10T10:10:10.0000000+00:00", result.ToString());
        }
    }
}