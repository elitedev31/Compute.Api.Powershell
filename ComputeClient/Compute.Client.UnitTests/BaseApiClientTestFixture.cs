using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Compute.Client.UnitTests
{
	using DD.CBU.Compute.Api.Client;
	using DD.CBU.Compute.Api.Client.Interfaces;
	using Moq;

    /// <summary>	A base API client test fixture. </summary>
    public class BaseApiClientTestFixture
    {
		/// <summary>	Test Identifier for the account. </summary>
		protected Guid accountId = new Guid("A3D9AACC-A273-45A5-919D-0F4C41C0763B");

		/// <summary>	The requests and responses. </summary>
		protected Dictionary<Uri, RequestFileResponseType> requestsAndResponses = new Dictionary<Uri, RequestFileResponseType>();

		/// <summary>	Get a mocked API Client, using the call and response collection in <see cref="requestsAndResponses"/>. </summary>
		/// <returns>	The API client. </returns>
		protected ComputeApiClient GetApiClient()
		{
			var httpClient = CreateFakeHttpClient();
			var client = new ComputeApiClient(httpClient);
			return client;
		}

	    /// <summary>	Gets contents of test file. </summary>
	    /// <param name="filename">	Filename of the file. </param>
	    /// <returns>	The contents of test file. </returns>
	    private string GetContentsOfTestFile(string filename)
	    {
			var sampleFolderLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\SampleOutputs");
			var targetFile = Path.Combine(sampleFolderLocation, filename);
		    return File.ReadAllText(targetFile);
	    }

	    /// <summary>	Creates fake HTTP client. </summary>
	    /// <returns>	The new fake HTTP client. </returns>
	    private IHttpClient CreateFakeHttpClient()
	    {
		    Mock<IHttpClient> fakeClient = new Mock<IHttpClient>();

		    foreach (var item in requestsAndResponses)
		    {
			    var message = new HttpResponseMessage(item.Value.Status)
			    {
				    Content = new StringContent(GetContentsOfTestFile(item.Value.ResponseFile), Encoding.UTF8, "text/xml")
			    };

			    fakeClient.Setup(f => f.GetAsync(item.Key)).ReturnsAsync(message);
				fakeClient.Setup(f => f.PostAsync(item.Key, It.IsAny<HttpContent>())).ReturnsAsync(message);
		    }
            
            return fakeClient.Object;
        }
    }
}