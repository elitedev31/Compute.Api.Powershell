using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using DD.ApiProxy.ApiProxyHttpClient;

namespace DD.CBU.Compute.Powershell.Tests
{
    public class TestHttpClient
    {
        private readonly IList<RequestReceivedEventArgs> _requestsReceived = new List<RequestReceivedEventArgs>();

        public TestHttpClient(ApiProxyConfiguration configuration, PSCredential credential)
        {            
            Credential = credential;
            HttpClient = ApiProxy.ApiProxyHttpClient.HttpClientFactory.GetHttpClient(configuration,
                Credential?.GetNetworkCredential(), ApiRequestReceivEventHandler);
        }

        private void ApiRequestReceivEventHandler(object sender, RequestReceivedEventArgs requestReceivedEventArgs)
        {
            _requestsReceived.Add(requestReceivedEventArgs);
        }        

        public HttpClient HttpClient { get; internal set; }

        public PSCredential Credential { get; internal set; }

        public IList<RequestReceivedEventArgs> GetApiCalledRecords(string requestUri, string httpMethod)
        {
            var receivedRequests =  _requestsReceived.Where(
                request =>
                    string.Equals(request.RequestUri.PathAndQuery.TrimEnd('?'), requestUri, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(httpMethod, request.HttpMethod.ToString(), StringComparison.InvariantCultureIgnoreCase)).ToList();           

            return receivedRequests;
        }

        public IList<RequestReceivedEventArgs> GetApiCalledRecords(string requestUri, string httpMethod, string requestContent)
        {
            var receivedRequests = _requestsReceived.Where(
                request =>
                    string.Equals(request.RequestUri.PathAndQuery, requestUri, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(httpMethod, request.HttpMethod.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(request.RequestContent, httpMethod, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return receivedRequests;
        }       
    }
}
