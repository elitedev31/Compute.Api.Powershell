using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client
{
    using System.Diagnostics.Contracts;
    using System.Net.Http.Headers;

    using Contracts.Datacenter;
	using Contracts.Directory;
	using Contracts.Server;
	using Utilities;

	/// <summary>
	///		A client for the Dimension Data Compute-as-a-Service (CaaS) API.
	/// </summary>
    public sealed class ComputeApiClient
		: DisposableObject
	{
		#region Instance data

		/// <summary>
		///		Media type formatters used to serialise and deserialise data contracts when communicating with the CaaS API.
		/// </summary>
		readonly MediaTypeFormatterCollection	_mediaTypeFormatters = new MediaTypeFormatterCollection();

		/// <summary>
		///		The <see cref="HttpMessageHandler"/> used to customise communications with the CaaS API.
		/// </summary>
		HttpClientHandler						_clientMessageHandler = new HttpClientHandler();

		/// <summary>
		///		The <see cref="HttpClient"/> used to communicate with the CaaS API.
		/// </summary>
		HttpClient								_httpClient;

		/// <summary>
		///		The details for the CaaS account associated with the supplied credentials.
		/// </summary>
		Account									_account;

		#endregion // Instance data
		
		#region Construction / disposal

		/// <summary>
		///		Create a new Compute-as-a-Service API client.
		/// </summary>
		/// <param name="targetRegionName">
		///		The name of the region whose CaaS API end-point is targeted by the client.
		/// </param>
		public ComputeApiClient(string targetRegionName)
		{
			if (String.IsNullOrWhiteSpace(targetRegionName))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'targetRegionName'.", "targetRegionName");

			_mediaTypeFormatters.XmlFormatter.UseXmlSerializer = true;
		    _httpClient = new HttpClient(_clientMessageHandler) { BaseAddress = ApiUris.ComputeBase(targetRegionName) };
		}

        /// <summary>
        /// Creates a new CaaS API client using a base URI.
        /// </summary>
        /// <param name="baseUri">The base URI to use for the CaaS API.</param>
	    public ComputeApiClient(Uri baseUri)
	    {
	        if (baseUri == null)
                throw new ArgumentNullException("baseUri", "Argument cannot be null");
            if (!baseUri.IsAbsoluteUri)
                throw new ArgumentException("Base URI supplied is not an absolute URI", "baseUri");

            _mediaTypeFormatters.XmlFormatter.UseXmlSerializer = true;
	        _httpClient = new HttpClient(_clientMessageHandler) { BaseAddress = baseUri };
	    }

		/// <summary>
		///		Dispose of resources being used by the CaaS API client.
		/// </summary>
		/// <param name="disposing">
		///		Explicit disposal?
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

				_account = null;
			}
		}

		#endregion // Construction / disposal

		#region Public properties

		/// <summary>
		///		Read-only information about the CaaS account targeted by the CaaS API client.
		/// </summary>
		/// <remarks>
		///		<c>null</c>, unless logged in.
		/// </remarks>
		/// <seealso cref="LoginAsync"/>
		public IAccount Account
		{
			get
			{
				CheckDisposed();

				return _account;
			}
		}

		/// <summary>
		///		Is the API client currently logged in to the CaaS API?
		/// </summary>
		public bool IsLoggedIn
		{
			get
			{
				CheckDisposed();

				return _account != null;
			}
		}

		#endregion // Public properties

		#region Public methods

		/// <summary>
		///		Asynchronously log into the CaaS API.
		/// </summary>
		/// <param name="accountCredentials">
		///		The CaaS account credentials used to authenticate against the CaaS API.
		/// </param>
		/// <returns>
		///		An <see cref="IAccount"/> implementation representing the CaaS account that the client is logged into.
		/// </returns>
		public async Task<IAccount> LoginAsync(ICredentials accountCredentials)
		{
			if (accountCredentials == null)
				throw new ArgumentNullException("accountCredentials");

			CheckDisposed();

			if (_account != null)
				throw ComputeApiClientException.AlreadyLoggedIn();

			_clientMessageHandler.Credentials = accountCredentials;
			_clientMessageHandler.PreAuthenticate = true;

			try
			{
				_account = await ApiGetAsync<Account>(ApiUris.MyAccount);
			}
			catch (HttpRequestException eRequestFailure)
			{
				Debug.WriteLine(eRequestFailure.GetBaseException(), "BASE EXCEPTION");

				throw;
			}
			Debug.Assert(_account != null, "_account != null");

			return _account;
		}

		/// <summary>
		///		Log out of the CaaS API.
		/// </summary>
		public void Logout()
		{
			CheckDisposed();

			if (_account == null)
				throw ComputeApiClientException.NotLoggedIn();

			_account = null;
			_clientMessageHandler.Credentials = null;
			_clientMessageHandler.PreAuthenticate = false;
		}

		/// <summary>
		///		Asynchronously get a list of all CaaS data centres that are available for use by the specified organisation.
		/// </summary>
		/// <param name="organizationId">
		///		The organisation Id.
		/// </param>
		/// <returns>
		///		A read-only list of <see cref="IDatacenterDetail"/>s representing the data centre information.
		/// </returns>
		public async Task<IReadOnlyList<IDatacenterDetail>> GetAvailableDataCenters(Guid organizationId)
		{
			CheckDisposed();

			DatacentersWithDiskSpeedDetails datacentersWithDiskSpeedDetails =
				await ApiGetAsync<DatacentersWithDiskSpeedDetails>(
					ApiUris.DatacentersWithDiskSpeedDetails(
						organizationId
					)
				);

			return datacentersWithDiskSpeedDetails.Datacenters;
		}

		/// <summary>
		///		Get a list of all system-defined images (with software labels) deployed in the specified data centre.
		/// </summary>
		/// <param name="locationName">
		///		The short name of the location in which the data centre is located.
		/// </param>
		/// <returns>
		///		A read-only list <see cref="ImageDetail"/>, sorted by UTC creation date / time, representing the images.
		/// </returns>
		public async Task<IReadOnlyList<IImageDetail>> GetImages(string locationName)
		{
			if (String.IsNullOrWhiteSpace(locationName))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'locationName'.", "locationName");

			ImagesWithSoftwareLabels imagesWithSoftwareLabels =
				await ApiGetAsync<ImagesWithSoftwareLabels>(
					ApiUris.ImagesWithSoftwareLabels(locationName)
				);

			return imagesWithSoftwareLabels.Images;
		}

        /// <summary>
        /// Gets a list of OS Images
        /// </summary>
        /// <param name="networkLocation"></param>
        /// <returns></returns>
        public async Task<DeployedImagesWithSoftwareLabels> GetOsServerImagesTask(string networkLocation)
	    {
            return await ApiGetAsync<DeployedImagesWithSoftwareLabels>(ApiUris.OsServerImages(networkLocation));
	    }

        /// <summary>
        /// Gets the networks with locations
        /// </summary>
        /// <returns>The networks</returns>
	    public async Task<NetworkWithLocations> GetNetworksTask()
	    {
	        return await this.ApiGetAsync<NetworkWithLocations>(ApiUris.NetworkWithLocations(Account.OrganizationId));
	    }

        /// <summary>
        /// Deploys a server using an image into a specified network.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="networkId"></param>
        /// <param name="imageId"></param>
        /// <param name="adminPassword"></param>
        /// <param name="isStarted"></param>
        /// <returns></returns>
	    public async Task<Status> DeployServerImageTask(string name, string description, string networkId, string imageId, string adminPassword, bool isStarted)
	    {
            Contract.Requires(!string.IsNullOrEmpty(name), "name argument must not be empty");
            Contract.Requires(!string.IsNullOrWhiteSpace(networkId), "network id must not be empty");
            Contract.Requires(!string.IsNullOrWhiteSpace(imageId), "Image id must not be empty");
            Contract.Requires(!string.IsNullOrWhiteSpace(adminPassword), "administrator password cannot be null or empty");

            return
                await
                this.ApiPostAsync<NewServerToDeploy, Status>(
                    ApiUris.DeployServer(Account.OrganizationId),
                    new NewServerToDeploy
                        {
                            name = name,
                            description = description,
                            vlanResourcePath =
                                string.Format("/oec/{0}/network/{1}", Account.OrganizationId, networkId),
                            imageResourcePath = string.Format("/oec/base/image/{0}", imageId),
                            administratorPassword = adminPassword,
                            isStarted = isStarted.ToString()
                        });
	    }

	    public async Task<Status> ServerPowerOn(string serverId)
	    {
	        return await this.ApiGetAsync<Status>(ApiUris.PowerOnServer(Account.OrganizationId, serverId));
	    }
        
        public async Task<Status> ServerPowerOff(string serverId)
        {
            return await this.ApiGetAsync<Status>(ApiUris.PoweroffServer(Account.OrganizationId, serverId));
        }

        public async Task<Status> ServerRestart(string serverId)
        {
            return await this.ApiGetAsync<Status>(ApiUris.RestartServer(Account.OrganizationId, serverId));
        }

        public async Task<Status> ServerShutdown(string serverId)
        {
            return await this.ApiGetAsync<Status>(ApiUris.ShutdownServer(Account.OrganizationId, serverId));
        }

        public async Task<Status> ServerDelete(string serverId)
        {
            return await this.ApiGetAsync<Status>(ApiUris.DeleteServer(Account.OrganizationId, serverId));
        }

	    public async Task<ServersWithBackup> GetDeployedServers()
	    {
	        return await this.ApiGetAsync<ServersWithBackup>(ApiUris.DeployedServers(Account.OrganizationId));
	    }

		#endregion // Public methods

		#region WebAPI invocation

	    /// <summary>
	    ///		Invoke a CaaS API operation using a HTTP GET request.
	    /// </summary>
	    /// <typeparam name="TResult">
	    ///		The XML-serialisable data contract type into which the response will be deserialised.
	    /// </typeparam>
	    /// <param name="relativeOperationUri">
	    ///		The operation URI (relative to the CaaS API's base URI).
	    /// </param>
	    /// <returns>
	    ///		The operation result.
	    /// </returns>
	    private async Task<TResult> ApiGetAsync<TResult>(Uri relativeOperationUri)
	    {
	        if (relativeOperationUri == null) throw new ArgumentNullException("relativeOperationUri");

	        if (relativeOperationUri.IsAbsoluteUri) throw new ArgumentException("The supplied URI is not a relative URI.", "relativeOperationUri");

	        CheckDisposed();

	        using (var response = await _httpClient.GetAsync(relativeOperationUri))
	        {
	            if (response.IsSuccessStatusCode) return await response.Content.ReadAsAsync<TResult>(_mediaTypeFormatters);

	            switch (response.StatusCode)
	            {
	                case HttpStatusCode.Unauthorized:
	                    {
	                        throw ComputeApiException.InvalidCredentials(
	                            ((NetworkCredential)_clientMessageHandler.Credentials).UserName);
	                    }
	                default:
	                    {
	                        throw new HttpRequestException(
	                            String.Format(
	                                "CaaS API returned HTTP status code {0} ({1}) when performing HTTP GET on '{2}'.",
	                                (int)response.StatusCode,
	                                response.StatusCode,
	                                response.RequestMessage.RequestUri));
	                    }
	            }
	        }
	    }

	    async Task<TResult> ApiPostAsync<TObject, TResult>(Uri relativeOperationUri, TObject content)
	    {
	        var objectContent = new ObjectContent<TObject>(content, _mediaTypeFormatters.XmlFormatter);
	        using (
	            var response =
	                await
	                _httpClient.PostAsync(relativeOperationUri, objectContent))
	        {
	            if (response.IsSuccessStatusCode) return await response.Content.ReadAsAsync<TResult>(_mediaTypeFormatters);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        {
                            throw ComputeApiException.InvalidCredentials(
                                ((NetworkCredential)_clientMessageHandler.Credentials).UserName);
                        }
                    default:
                        {
                            throw new HttpRequestException(
                                String.Format(
                                    "CaaS API returned HTTP status code {0} ({1}) when performing HTTP POST on '{2}'.",
                                    (int)response.StatusCode,
                                    response.StatusCode,
                                    response.RequestMessage.RequestUri));
                        }
                }
	        }
	    }

	    #endregion // WebAPI invocation
    }
}