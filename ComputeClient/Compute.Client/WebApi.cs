// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApi.cs" company="">
//   
// </copyright>
// <summary>
//   The web api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.Utilities;
using DD.CBU.Compute.Api.Contracts.Directory;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Api.Client
{
	/// <summary>
	/// The web API.
	/// </summary>
	internal class WebApi : DisposableObject, IWebApi
	{
		/// <summary>
		/// Media type formatters used to serialise and deserialise data contracts when communicating with the CaaS API.
		/// </summary>
		private readonly MediaTypeFormatterCollection _mediaTypeFormatters = new MediaTypeFormatterCollection();

		/// <summary>
		/// The region connected to.
		/// </summary>
		private readonly string _region;

		/// <summary>
		/// The details for the CaaS account associated with the supplied credentials.
		/// </summary>
		private IAccount _account;

		/// <summary>
		/// The <see cref="HttpMessageHandler"/> used to customise communications with the CaaS API.
		/// </summary>
		private HttpClientHandler _clientMessageHandler = new HttpClientHandler();

		/// <summary>
		/// The credentials to connect to the endpoint.
		/// </summary>
		private ICredentials _credentials;


		/// <summary>
		/// The <see cref="HttpClient"/> used to communicate with the CaaS API.
		/// </summary>
		private IHttpClient _httpClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="WebApi"/> class.
		/// </summary>
		public WebApi()
		{
			_mediaTypeFormatters.XmlFormatter.UseXmlSerializer = true;
			_mediaTypeFormatters.Add(new TextMediaTypeFormatter());
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="WebApi"/> class.
		///     Creates a new CaaS API client using a base URI.
		/// </summary>
		/// <param name="baseUri">
		/// The base URI to use for the CaaS API.
		/// </param>
		public WebApi(Uri baseUri)
			: this()
		{
			if (baseUri == null) throw new ArgumentNullException("baseUri", "Argument cannot be null");

			if (!baseUri.IsAbsoluteUri) throw new ArgumentException("Base URI supplied is not an absolute URI", "baseUri");

			_httpClient = new HttpClientAdapter(new HttpClient(_clientMessageHandler) {BaseAddress = baseUri});
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="WebApi"/> class.
		///     Create a new Compute-as-a-Service API client.
		/// </summary>
		/// <param name="targetRegionName">
		/// The name of the region whose CaaS API end-point is targeted by the client.
		/// </param>
		public WebApi(string targetRegionName)
			: this()
		{
			if (string.IsNullOrWhiteSpace(targetRegionName))
				throw new ArgumentException(
					"Argument cannot be null, empty, or composed entirely of whitespace: 'targetRegionName'.", 
					"targetRegionName");

			_httpClient =
				new HttpClientAdapter(
					new HttpClient(_clientMessageHandler)
					{
						BaseAddress = ApiUris.ComputeBase(targetRegionName)
					});
			_region = targetRegionName;
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="WebApi"/> class.
		///     Creates a new CaaS API client using a base URI.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
		public WebApi(IHttpClient client)
			: this()
		{
			_httpClient = client;
		}

		/// <summary>
		/// Read-only information about the CaaS account targeted by the CaaS API client.
		/// </summary>
		/// <remarks>
		/// <c>null</c>, unless logged in.
		/// </remarks>
		/// <seealso cref="LoginAsync"/>
		public IAccount Account
		{
			get
			{
				CheckDisposed();
				return _account;
			}

			private set { _account = value; }
		}

		/// <summary>
		/// Is the API client currently logged in to the CaaS API?
		/// </summary>
		public bool IsLoggedIn
		{
			get
			{
				CheckDisposed();

				return Account != null;
			}
		}

		/// <summary>
		/// Asynchronously log into the CaaS API.
		/// </summary>
		/// <param name="accountCredentials">
		/// The CaaS account credentials used to authenticate against the CaaS API.
		/// </param>
		/// <returns>
		/// An <see cref="IAccount"/> implementation representing the CaaS account that the client is logged into.
		/// </returns>
		public async Task<IAccount> LoginAsync(ICredentials accountCredentials)
		{
			if (accountCredentials == null)
				throw new ArgumentNullException("accountCredentials");

			CheckDisposed();

			if (IsLoggedIn)
				throw ComputeApiClientException.AlreadyLoggedIn();

			_clientMessageHandler.Credentials = accountCredentials;
			_clientMessageHandler.PreAuthenticate = true;
			_credentials = accountCredentials;

			try
			{
				Account = await ApiGetAsync<Account>(ApiUris.MyAccount);
			}
			catch (HttpRequestException eRequestFailure)
			{
				Debug.WriteLine(eRequestFailure.GetBaseException(), "BASE EXCEPTION");

				throw;
			}

			return Account;
		}

		/// <summary>
		/// Gets the credentials of the connection.
		/// </summary>
        public ICredentials Credentials
		{
			get { return _credentials; }
			set
			{
				_credentials = value;
				_clientMessageHandler.Credentials = value;
				_clientMessageHandler.PreAuthenticate = true;
			}
		}

		/// <summary>
		/// Gets the target region.
		/// </summary>
		public string Region
		{
			get { return _region; }
		}

		/// <summary>
		/// Log out of the CaaS API.
		/// </summary>
		public void Logout()
		{
			CheckDisposed();

			if (!IsLoggedIn)
				throw ComputeApiClientException.NotLoggedIn();

			_account = null;
			_clientMessageHandler.Credentials = null;
			_clientMessageHandler.PreAuthenticate = false;
		}

		/// <summary>
		/// 	The API get async. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/24/2015. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">
		/// 	. 
		/// </exception>
		/// <exception cref="ArgumentException">
		/// 		. 
		/// </exception>
		/// <exception cref="HttpRequestException">
		/// 	. 
		/// </exception>
		/// <typeparam name="TResult">
		/// 	. 
		/// </typeparam>
		/// <param name="relativeOperationUri">
		/// 	The relative operation uri. 
		/// </param>
		/// <returns>
		/// 	The typed result from the API. 
		/// </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IWebApi.ApiGetAsync{TResult}(Uri)"/>
		public async Task<TResult> ApiGetAsync<TResult>(Uri relativeOperationUri)
		{
			if (relativeOperationUri == null) throw new ArgumentNullException("relativeOperationUri");

			if (relativeOperationUri.IsAbsoluteUri)
				throw new ArgumentException("The supplied URI is not a relative URI.", "relativeOperationUri");

			using (HttpResponseMessage response = await _httpClient.GetAsync(relativeOperationUri))
			{
				if (response.IsSuccessStatusCode) return await response.Content.ReadAsAsync<TResult>(_mediaTypeFormatters);
				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
					{
						throw ComputeApiException.InvalidCredentials(
							((NetworkCredential) _clientMessageHandler.Credentials).UserName);
					}

					case HttpStatusCode.BadRequest:
					{
						// Handle specific CaaS Status response when getting a bad request
						Status status = await response.Content.ReadAsAsync<Status>(_mediaTypeFormatters);
						throw ComputeApiException.InvalidRequest(status.operation, status.resultDetail, status, relativeOperationUri);
					}

					default:
					{
						throw new HttpRequestException(
							string.Format(
								"CaaS API returned HTTP status code {0} ({1}) when performing HTTP GET on '{2}'.", 
								(int) response.StatusCode, 
								response.StatusCode, 
								response.RequestMessage.RequestUri));
					}
				}
			}
		}

		/// <summary>
		/// 	The api get async. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/24/2015. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">
		/// 	. 
		/// </exception>
		/// <exception cref="ArgumentException">
		/// 		. 
		/// </exception>
		/// <exception cref="HttpRequestException">
		/// 	. 
		/// </exception>
		/// <param name="relativeOperationUri">
		/// 	The relative operation uri. 
		/// </param>
		/// <returns>
		/// 	The <see cref="Task"/>. 
		/// </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IWebApi.ApiGetAsync(Uri)"/>
		public async Task<string> ApiGetAsync(Uri relativeOperationUri)
		{
			if (relativeOperationUri == null) throw new ArgumentNullException("relativeOperationUri");

			if (relativeOperationUri.IsAbsoluteUri)
				throw new ArgumentException("The supplied URI is not a relative URI.", "relativeOperationUri");

			using (HttpResponseMessage response = await _httpClient.GetAsync(relativeOperationUri))
			{
				if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();
				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
					{
						throw ComputeApiException.InvalidCredentials(
							((NetworkCredential) _clientMessageHandler.Credentials).UserName);
					}

					default:
					{
						throw new HttpRequestException(
							string.Format(
								"CaaS API returned HTTP status code {0} ({1}) when performing HTTP GET on '{2}'.", 
								(int) response.StatusCode, 
								response.StatusCode, 
								response.RequestMessage.RequestUri));
					}
				}
			}
		}

		/// <summary>
		/// Invoke a CaaS API operation using a HTTP POST request.
		/// </summary>
		/// <typeparam name="TObject">
		/// The XML-Serialisable data contract type that the request will be sent.
		/// </typeparam>
		/// <typeparam name="TResult">
		/// The XML-serialisable data contract type into which the response will be deserialised.
		/// </typeparam>
		/// <param name="relativeOperationUri">
		/// The operation URI (relative to the CaaS API's base URI).
		/// </param>
		/// <param name="content">
		/// The content that will be deserialised and passed in the body of the POST request.
		/// </param>
		/// <returns>
		/// The operation result.
		/// </returns>
		public async Task<TResult> ApiPostAsync<TObject, TResult>(Uri relativeOperationUri, TObject content)
		{
			var objectContent = new ObjectContent<TObject>(content, _mediaTypeFormatters.XmlFormatter);
			using (
				HttpResponseMessage response =
					await
						_httpClient.PostAsync(relativeOperationUri, objectContent))
			{
				if (response.IsSuccessStatusCode) return await response.Content.ReadAsAsync<TResult>(_mediaTypeFormatters);

				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
					{
						throw ComputeApiException.InvalidCredentials(
							((NetworkCredential) _clientMessageHandler.Credentials).UserName);
					}

					case HttpStatusCode.BadRequest:
					{
						// Handle specific CaaS Status response when posting a bad request
						Status status = await response.Content.ReadAsAsync<Status>(_mediaTypeFormatters);
						throw ComputeApiException.InvalidRequest(status.operation, status.resultDetail, status, relativeOperationUri);
					}

					default:
					{
						throw new HttpRequestException(
							string.Format(
								"CaaS API returned HTTP status code {0} ({1}) when performing HTTP POST on '{2}'.", 
								(int) response.StatusCode, 
								response.StatusCode, 
								response.RequestMessage.RequestUri));
					}
				}
			}
		}


		/// <summary>
		/// Invoke a CaaS API operation using a HTTP POST request.
		/// </summary>
		/// <typeparam name="TResult">
		/// The XML-serialisable data contract type into which the response will be deserialised.
		/// </typeparam>
		/// <param name="relativeOperationUri">
		/// The operation URI (relative to the CaaS API's base URI).
		/// </param>
		/// <param name="content">
		/// The content that will be deserialised and passed in the body of the POST request.
		/// </param>
		/// <returns>
		/// The operation result.
		/// </returns>
		public async Task<TResult> ApiPostAsync<TResult>(Uri relativeOperationUri, string content)
		{
			var textformatter = new TextMediaTypeFormatter();
			var objectContent = new ObjectContent<string>(
				content, 
				textformatter, 
				"application/x-www-form-urlencoded");
			using (
				HttpResponseMessage response =
					await
						_httpClient.PostAsync(relativeOperationUri, objectContent))
			{
				if (response.IsSuccessStatusCode) return await response.Content.ReadAsAsync<TResult>(_mediaTypeFormatters);

				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
					{
						throw ComputeApiException.InvalidCredentials(
							((NetworkCredential) _clientMessageHandler.Credentials).UserName);
					}

					case HttpStatusCode.BadRequest:
					{
						// Handle specific CaaS Status response when posting a bad request
						Status status = await response.Content.ReadAsAsync<Status>(_mediaTypeFormatters);
						throw ComputeApiException.InvalidRequest(status.operation, status.resultDetail, status, relativeOperationUri);
					}

					default:
					{
						throw new HttpRequestException(
							string.Format(
								"CaaS API returned HTTP status code {0} ({1}) when performing HTTP POST on '{2}'.", 
								(int) response.StatusCode, 
								response.StatusCode, 
								response.RequestMessage.RequestUri));
					}
				}
			}
		}


		/// <summary>
		/// Dispose of resources being used by the CaaS API client.
		/// </summary>
		/// <param name="disposing">
		/// Explicit disposal?
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_clientMessageHandler != null)
				{
					_clientMessageHandler.Dispose();
					_clientMessageHandler = null;
				}

				if (_httpClient != null)
				{
					_httpClient.Dispose();
					_httpClient = null;
				}

				Account = null;
			}
		}
	}
}