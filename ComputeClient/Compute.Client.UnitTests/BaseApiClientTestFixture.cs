using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Interfaces;
using FakeItEasy;

namespace Compute.Client.UnitTests
{
    public class BaseApiClientTestFixture
    {
        protected IHttpClient GetFakeHttpClientFromRelativeUrl(string xmlResponse, string expectedRelativeUrl)
        {
            return GetFakeHttpClient(xmlResponse, new Uri(expectedRelativeUrl, UriKind.Relative));
        }

        protected IHttpClient GetFakeHttpClientFromSampleFile(string sampleFilename, string expectedRelativeUrl)
        {
            var sampleFolderLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\SampleOutputs");
            var targetFile = Path.Combine(sampleFolderLocation, sampleFilename);
            return GetFakeHttpClientFromRelativeUrl(File.ReadAllText(targetFile), expectedRelativeUrl);

        }

        protected IHttpClient GetFakeHttpClient(string xmlResponse, Uri expectedUri)
        {
            Action<IHttpClient, string> configureClient = (fakeClient, xml) => A.CallTo(() => fakeClient.GetAsync(expectedUri)).Returns(CreateMessage(xml));
            return GetFakeHttpClient(xmlResponse, expectedUri, configureClient);
        }

        protected IHttpClient GetFakeHttpClient(string xmlResponse, Uri expectedUri, Action<IHttpClient, string> configureFakeClient)
        {
            var fakeClient = A.Fake<IHttpClient>();

            if (configureFakeClient != null)
                configureFakeClient(fakeClient, xmlResponse);

            return fakeClient;
        }

        protected HttpResponseMessage CreateMessage(string xmlResponse, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var message = new HttpResponseMessage(httpStatusCode);
            message.Content = new StringContent(xmlResponse, Encoding.UTF8, "text/xml");
            return message;
        }

        protected ComputeApiClient GetApiClient(string sampleXmlFileName, string expectedRelativeUrl, Action<IHttpClient, string> configureFakeClient)
        {
            var xmlResponse = File.ReadAllText(sampleXmlFileName);
            var httpClient = GetFakeHttpClient(xmlResponse, new Uri(expectedRelativeUrl, UriKind.Relative), configureFakeClient);
            var client = new ComputeApiClient(httpClient);
            return client;
        }

        protected ComputeApiClient GetApiClient(string sampleXmlFileName, string expectedRelativeUrl)
        {
            var httpClient = GetFakeHttpClientFromSampleFile(sampleXmlFileName, expectedRelativeUrl);
            var client = new ComputeApiClient(httpClient);
            return client;
        }
    }
}