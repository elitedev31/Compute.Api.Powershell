using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client.Interfaces
{
	using Utilities;

	internal class HttpClientAdapter : DisposableObject, IHttpClient
    {
		/// <summary>
		///		The underlying <see cref="HttpClient"/>.
		/// </summary>
        readonly HttpClient _client;

		/// <summary>
		///		Create a new <see cref="HttpClient"/> adaptor.
		/// </summary>
		/// <param name="client">
		///		The <see cref="HttpClient"/> wrapped by the adaptor.
		/// </param>
        public HttpClientAdapter(HttpClient client)
        {
	        if (client == null)
		        throw new ArgumentNullException("client");

            _client = client;
        }

		/// <summary>
		///		Dispose of resources being used by the disposable object.
		/// </summary>
		/// <param name="disposing">
		///		Explicit disposal?
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_client.Dispose();
		}

		/// <summary>
		///		The base address used by the HTTP client.
		/// </summary>
		public Uri BaseAddress
		{
			get
			{
				CheckDisposed();

				return _client.BaseAddress;
			}
		}

		public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
			CheckDisposed();

            return _client.GetAsync(uri);
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri uri)
        {
			CheckDisposed();

            return _client.DeleteAsync(uri);
        }

        public Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content)
        {
			CheckDisposed();

            return _client.PutAsync(uri, content);
        }

        public Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content)
        {
			CheckDisposed();

            return _client.PostAsync(uri, content);
        }
    }
}
