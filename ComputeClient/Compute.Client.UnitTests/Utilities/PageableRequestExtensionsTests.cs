namespace Compute.Client.UnitTests.Utilities
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using DD.CBU.Compute.Api.Client.Utilities;
    using DD.CBU.Compute.Api.Contracts.Requests;

    [TestClass]
    public class PageableRequestExtensionsTests
    {
        [TestMethod]
        public void AppendToUriWithNull()
        {
            var uri = new Uri("/resource", UriKind.Relative);
            var result = PageableRequestExtensions.AppendToUri(null, uri);
            Assert.AreEqual(uri, result);
        }

        [TestMethod]
        public void AppendToUriWithExistingQuery()
        {
            var uri = new Uri("/resource?id=12", UriKind.Relative);
            var options = new PageableRequest
            {
                PageSize = 50,
                PageNumber = 1
            };

            var result = PageableRequestExtensions.AppendToUri(options, uri);
            Assert.AreEqual("/resource?id=12&pageSize=50&pageNumber=1", result.ToString());
        }

        [TestMethod]
        public void AppendToUriWithoutExistingQuery()
        {
            var uri = new Uri("/resource", UriKind.Relative);
            var options = new PageableRequest
            {
                PageSize = 50,
                PageNumber = 1,
                Order = "id"
            };

            var result = PageableRequestExtensions.AppendToUri(options, uri);
            Assert.AreEqual("/resource?pageSize=50&pageNumber=1&orderBy=id", result.ToString());
        }
    }
}