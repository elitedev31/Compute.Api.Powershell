using System;
using System.Net.Http;
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

        /// <summary>
        /// Get asynchronously
        /// </summary>
        /// <param name="uri">The URI</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(Uri uri);
        /// <summary>
        /// Delete asynchronously
        /// </summary>
        /// <param name="uri">The URI</param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteAsync(Uri uri);
        /// <summary>
        /// Put asynchronously
        /// </summary>
        /// <param name="uri">The URI</param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content);
        /// <summary>
        /// Post asynchronously
        /// </summary>
        /// <param name="uri">The URI</param>
        /// <param name="content">The content to post</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content);
    }
}
