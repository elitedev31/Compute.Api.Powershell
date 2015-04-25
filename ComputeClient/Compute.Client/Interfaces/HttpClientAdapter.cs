// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpClientAdapter.cs" company="">
//   
// </copyright>
// <summary>
//   The http client adapter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Net.Http;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Utilities;

namespace DD.CBU.Compute.Api.Client.Interfaces
{
	/// <summary>
	/// The http client adapter.
	/// </summary>
	internal class HttpClientAdapter : DisposableObject, IHttpClient
	{
		/// <summary>
		/// The underlying <see cref="HttpClient"/>.
		/// </summary>
		private readonly HttpClient _client;

		/// <summary>
		/// Initialises a new instance of the <see cref="HttpClientAdapter"/> class. 
		/// Create a new <see cref="HttpClient"/> adaptor.
		/// </summary>
		/// <param name="client">
		/// The <see cref="HttpClient"/> wrapped by the adaptor.
		/// </param>
		public HttpClientAdapter(HttpClient client)
		{
			if (client == null)
				throw new ArgumentNullException("client");

			_client = client;
		}

		/// <summary>
		/// The base address used by the HTTP client.
		/// </summary>
		public Uri BaseAddress
		{
			get
			{
				CheckDisposed();

				return _client.BaseAddress;
			}
		}

		/// <summary>
		/// The get async.
		/// </summary>
		/// <param name="uri">
		/// The uri.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public Task<HttpResponseMessage> GetAsync(Uri uri)
		{
			CheckDisposed();

			return _client.GetAsync(uri);
		}

		/// <summary>
		/// The delete async.
		/// </summary>
		/// <param name="uri">
		/// The uri.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public Task<HttpResponseMessage> DeleteAsync(Uri uri)
		{
			CheckDisposed();

			return _client.DeleteAsync(uri);
		}

		/// <summary>
		/// The put async.
		/// </summary>
		/// <param name="uri">
		/// The uri.
		/// </param>
		/// <param name="content">
		/// The content.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content)
		{
			CheckDisposed();

			return _client.PutAsync(uri, content);
		}

		/// <summary>
		/// The post async.
		/// </summary>
		/// <param name="uri">
		/// The uri.
		/// </param>
		/// <param name="content">
		/// The content.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content)
		{
			CheckDisposed();

			return _client.PostAsync(uri, content);
		}

		/// <summary>
		/// Dispose of resources being used by the disposable object.
		/// </summary>
		/// <param name="disposing">
		/// Explicit disposal?
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_client.Dispose();
		}
	}
}