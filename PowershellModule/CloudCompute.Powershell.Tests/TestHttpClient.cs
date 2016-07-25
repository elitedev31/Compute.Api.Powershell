using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Xml.Serialization;
using DD.ApiProxy.ApiProxyHttpClient;
using DD.ApiProxy.Contracts;

namespace DD.CBU.Compute.Powershell.Tests
{
    public class TestHttpClient
    {
        private readonly IList<RequestReceivedEventArgs> _requestsReceived = new List<RequestReceivedEventArgs>();

        private readonly ApiProxyClientHandler _apiProxyClientHandler;

        private readonly ApiProxyConfiguration _apiProxyConfiguration;
        public TestHttpClient(ApiProxyConfiguration configuration, PSCredential credential)
        {            
            Credential = credential;
            _apiProxyConfiguration = configuration;
            var clientHandler = ApiProxy.ApiProxyHttpClient.HttpClientHandlerFactory.GetHttpClientHandler(configuration,
                Credential?.GetNetworkCredential(), ApiRequestReceivEventHandler);
            _apiProxyClientHandler = clientHandler as ApiProxyClientHandler;
            HttpClient = ApiProxy.ApiProxyHttpClient.HttpClientFactory.GetHttpClient(configuration, _apiProxyClientHandler);
        }

        private void ApiRequestReceivEventHandler(object sender, RequestReceivedEventArgs requestReceivedEventArgs)
        {
            _requestsReceived.Add(requestReceivedEventArgs);
        }        

        public HttpClient HttpClient { get; internal set; }

        public PSCredential Credential { get; internal set; }

        public IList<RequestReceivedEventArgs> GetApiCalledRecords(string httpMethod, string requestUri)
        {
            var receivedRequests =  _requestsReceived.Where(
                request =>
                    string.Equals(request.RequestUri.PathAndQuery.TrimEnd('?', '&'), requestUri, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(httpMethod, request.HttpMethod.ToString(), StringComparison.InvariantCultureIgnoreCase)).ToList();           

            return receivedRequests;
        }

        public IList<RequestReceivedEventArgs> GetApiCalledRecords(string httpMethod, string requestUri, string requestContent)
        {
            var receivedRequests = _requestsReceived.Where(
                request =>
                    string.Equals(request.RequestUri.PathAndQuery.TrimEnd('?', '&'), requestUri, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(httpMethod, request.HttpMethod.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(request.RequestContent, httpMethod, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return receivedRequests;
        }

        public IList<RequestReceivedEventArgs> GetAllApiCalledRecords()
        {          
            return _requestsReceived.ToList();
        }

        public void SetupApiMock(string httpMethod, string requestUri, object responseContentObject, int httpStatus = 200)
        {
            string responseContent = responseContentObject as string;         
            if(responseContentObject != null && responseContent == null)
            {
                XmlSerializer x = new XmlSerializer(responseContentObject.GetType());
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                x.Serialize(writer, responseContentObject);
                stream.Flush();
                stream.Position = 0;
                var sr = new StreamReader(stream);
                responseContent = sr.ReadToEnd();
            }

            Uri requestUriObject;
            if (!Uri.TryCreate(requestUri, UriKind.Absolute,  out requestUriObject))
            {
                var baseAddress = new Uri("https://localhost/");
                if (_apiProxyConfiguration.DefaultApiAddress != null)
                    baseAddress = _apiProxyConfiguration.DefaultApiAddress;

                requestUriObject = new Uri(baseAddress, requestUri);
            }
            // Map from int to Text
            HttpStatusCode code = (HttpStatusCode)httpStatus;
            _apiProxyClientHandler.AddMockApiRecord(new ApiRecord { StatusCode = code.ToString(),  Method = httpMethod, Mock = true, Uri = requestUriObject.ToString(), ResponseContent = responseContent, ResponseContentType = "application/xml" });
        }
    }
}
