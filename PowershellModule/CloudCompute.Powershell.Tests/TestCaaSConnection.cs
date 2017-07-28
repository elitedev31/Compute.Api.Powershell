using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using DD.ApiProxy.ApiProxyHttpClient;

namespace DD.CBU.Compute.Powershell.Tests
{
    public class TestCaaSConnection
    {     
        public TestCaaSConnection(TestHttpClient httpClient, ComputeServiceConnection testConnection)
        {
            TestHttpClient = httpClient;
            CaaSConnection = testConnection;
        }

        public TestHttpClient TestHttpClient { get; internal set; }

        public ComputeServiceConnection CaaSConnection { get; internal set; }

        public Guid CaaSClientId => CaaSConnection.User.OrganizationId;

        public IList<RequestReceivedEventArgs> GetApiCalledRecords(string httpMethod, string requestUri)
        {
            return TestHttpClient.GetApiCalledRecords(httpMethod, requestUri);
        }

        public IList<RequestReceivedEventArgs> GetApiCalledRecords(string httpMethod, string requestUri,  string requestContent)
        {
            return TestHttpClient.GetApiCalledRecords(httpMethod, requestUri, requestContent);
        }

        public IList<RequestReceivedEventArgs> GetAllApiCalledRecords()
        {
            return TestHttpClient.GetAllApiCalledRecords();
        }

        public void SetupApiMock(string httpMethod, string requestUri,  object responseContent, int httpStatus = 200)
        {
            TestHttpClient.SetupApiMock(httpMethod, requestUri, responseContent, httpStatus);
        }
    }
}
