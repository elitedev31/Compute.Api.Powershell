namespace DD.CBU.Compute.Api.Client.WebApi
{
	using System;
	using System.Net;
	using System.Net.Http;
	using System.Net.Http.Formatting;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Exceptions;
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Utilities;
	using DD.CBU.Compute.Api.Contracts.Directory;
	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Requests;

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
		/// The <see cref="HttpClient"/> used to communicate with the CaaS API.
		/// </summary>
		private IHttpClient _httpClient;

		/// <summary>
		/// The _organization id.
		/// </summary>
		Guid _organizationId;

		/// <summary>
		/// Initialises a new instance of the <see cref="WebApi"/> class.
		/// </summary>
		private WebApi()
		{
			_mediaTypeFormatters.XmlFormatter.UseXmlSerializer = true;
			_mediaTypeFormatters.Add(new TextMediaTypeFormatter());
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="WebApi"/> class.
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
		/// <param name="organizationId">
		/// The organization Id.
		/// </param>
		public WebApi(IHttpClient client, Guid organizationId = default(Guid))
			: this()
		{
			_httpClient = client;
			_organizationId = organizationId;
		}

		/// <summary>
		/// Gets the CaaS client organization id.
		/// </summary>
		public Guid OrganizationId
		{
			get
			{
				if (_organizationId == Guid.Empty)
				{
					throw new CaaSOrganizationNotSetException();
				}
				return _organizationId;
			}
		}

		/// <summary>
		/// Asynchronously log into the CaaS API.
		/// </summary>
		/// <returns>
		/// An <see cref="IAccount"/> implementation representing the CaaS account that the client is logged into.
		/// </returns>
		public async Task<IAccount> LoginAsync()
		{
			Account account = await GetAsync<Account>(ApiUris.MyAccount);
			_organizationId = account.OrganizationId;
			return account;
		}

        /// <summary>
        /// The get async.
        /// </summary>
        /// <param name="relativeOperationUri">
        /// The relative operation uri.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
		/// <param name="filteringOptions">
		/// The filtering options.
		/// </param>
        /// <typeparam name="TResult">
        /// Result from the Get call
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <exception cref="ComputeApiException">
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// </exception>
        public async Task<TResult> GetAsync<TResult>(Uri relativeOperationUri, IPageableRequest pagingOptions = null, IFilterableRequest filteringOptions = null)
		{
			if (relativeOperationUri == null)
				throw new ArgumentNullException("relativeOperationUri");

			if (relativeOperationUri.IsAbsoluteUri)
				throw new ArgumentException("The supplied URI is not a relative URI.", "relativeOperationUri");

            if (filteringOptions != null)
            {
                relativeOperationUri = filteringOptions.AppendToUri(relativeOperationUri);
            }

            if (pagingOptions != null)
            {
                relativeOperationUri = pagingOptions.AppendToUri(relativeOperationUri);
            }

            using (HttpResponseMessage response = await _httpClient.GetAsync(relativeOperationUri))
			{
				if (!response.IsSuccessStatusCode)
				{
					await HandleApiRequestErrors(response, relativeOperationUri);		
				}				
				return await response.Content.ReadAsAsync<TResult>(_mediaTypeFormatters);
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
		public async Task<TResult> PostAsync<TObject, TResult>(Uri relativeOperationUri, TObject content)
		{
			ObjectContent<TObject> objectContent = new ObjectContent<TObject>(content, _mediaTypeFormatters.XmlFormatter);
			using (
				HttpResponseMessage response =
					await
						_httpClient.PostAsync(relativeOperationUri, objectContent))
			{				
				if (!response.IsSuccessStatusCode)
				{
					await HandleApiRequestErrors(response, relativeOperationUri);
				}
				
				return await response.Content.ReadAsAsync<TResult>(_mediaTypeFormatters);
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
		public async Task<TResult> PostAsync<TResult>(Uri relativeOperationUri, string content)
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
				if (!response.IsSuccessStatusCode)
					await HandleApiRequestErrors(response, relativeOperationUri);
				
				return await response.Content.ReadAsAsync<TResult>(_mediaTypeFormatters);
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
				if (_httpClient != null)
				{
					_httpClient.Dispose();
					_httpClient = null;
				}
			}
		}

		/// <summary>
		/// The handle api request errors.
		/// </summary>
		/// <param name="response">
		/// The response.
		/// </param>
		/// <param name="uri">
		/// The uri.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		/// <exception cref="InvalidCredentialsException">
		/// </exception>
		/// <exception cref="ComputeApiException">
		/// </exception>
		/// <exception cref="HttpRequestException">
		/// </exception>
		private async Task HandleApiRequestErrors(HttpResponseMessage response, Uri uri)
		{
			switch (response.StatusCode)
			{
				case HttpStatusCode.Unauthorized:
					{
						throw new InvalidCredentialsException(uri);
					}

				case HttpStatusCode.BadRequest:
					{
						// Handle specific CaaS Status response when posting a bad request
						if (uri.ToString().StartsWith(ApiUris.MCP1_0_PREFIX))
						{
							Status status = await response.Content.ReadAsAsync<Status>(_mediaTypeFormatters);
							throw new BadRequestException(status, uri);
						}
						Response responseMessage = await response.Content.ReadAsAsync<Response>(_mediaTypeFormatters);
						throw new BadRequestException(responseMessage, uri);
					}

				default:
					{
						throw new HttpRequestException(
							string.Format(
								"CaaS API returned HTTP status code {0} ({1}) when performing HTTP POST on '{2}'.",
								(int)response.StatusCode,
								response.StatusCode,
								response.RequestMessage.RequestUri));
					}
			}
		}
	}
}