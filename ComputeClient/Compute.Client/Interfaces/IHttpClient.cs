using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client.Interfaces
{
    /// <summary>
    /// Represents a type that can make HttpClient calls.
    /// </summary>
    public interface IHttpClient : IDisposable
    {
		/// <summary>
		///		The base address used by the HTTP client.
		/// </summary>
		Uri BaseAddress
		{
			get;
		}

        Task<HttpResponseMessage> GetAsync(Uri uri);
        Task<HttpResponseMessage> DeleteAsync(Uri uri);
        Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content);
        Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content);
    }
}
