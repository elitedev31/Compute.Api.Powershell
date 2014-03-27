using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
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
            var message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StringContent(xmlResponse, Encoding.UTF8, "text/xml");

            var fakeClient = A.Fake<IHttpClient>();
            A.CallTo(() => fakeClient.GetAsync(expectedUri)).Returns(message);

            ConfigureFakeHttpClient(fakeClient);

            return fakeClient;
        }

        protected virtual void ConfigureFakeHttpClient(IHttpClient client)
        {            
        }
    }
}