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

        public IList<RequestReceivedEventArgs> GetApiCalledRecords(string requestUri, string httpMethod)
        {
            return TestHttpClient.GetApiCalledRecords(requestUri, httpMethod);
        }

        public IList<RequestReceivedEventArgs> GetApiCalledRecords(string requestUri, string httpMethod, string requestContent)
        {
            return TestHttpClient.GetApiCalledRecords(requestUri, httpMethod, requestContent);
        }       
    }
}
