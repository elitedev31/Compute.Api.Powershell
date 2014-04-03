using System.Linq;

using DD.CBU.Compute.Api.Contracts.Software;

namespace DD.CBU.Compute.Api.Client
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Utilities;
    using DD.CBU.Compute.Api.Contracts.Datacenter;
    using DD.CBU.Compute.Api.Contracts.Directory;
    using DD.CBU.Compute.Api.Contracts.Server;
    using DD.CBU.Compute.Api.Contracts.General;

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
        readonly MediaTypeFormatterCollection _mediaTypeFormatters = new MediaTypeFormatterCollection();

        /// <summary>
        ///		The <see cref="HttpMessageHandler"/> used to customise communications with the CaaS API.
        /// </summary>
        HttpClientHandler _clientMessageHandler = new HttpClientHandler();

        /// <summary>
        ///		The <see cref="HttpClient"/> used to communicate with the CaaS API.
        /// </summary>
        IHttpClient _httpClient;

        /// <summary>
        ///		The details for the CaaS account associated with the supplied credentials.
        /// </summary>
        IAccount _account;

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
            _httpClient = new HttpClientAdapter(new HttpClient(_clientMessageHandler) { BaseAddress = ApiUris.ComputeBase(targetRegionName) });
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
            _httpClient = new HttpClientAdapter(new HttpClient(_clientMessageHandler) { BaseAddress = baseUri });
        }

        /// <summary>
        /// Creates a new CaaS API client using a base URI.
        /// </summary>
        public ComputeApiClient(IHttpClient client)
        {

            if (client == null)
                throw new ArgumentNullException("client", "Argument cannot be null");

            _mediaTypeFormatters.XmlFormatter.UseXmlSerializer = true;
            _httpClient = client;
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

        public async Task<IEnumerable<SoftwareLabel>> GetListOfSoftwareLabels(Guid orgId)
        {
            var relativeUrl = string.Format("{0}/softwarelabel", orgId);
            var uri = new Uri(relativeUrl, UriKind.Relative);

            var labels = await ApiGetAsync<SoftwareLabels>(uri);

            return labels.Items;
        }

        /// <summary>
        /// Returns a list of the Multi-Geography Regions available for the supplied {org-id
        /// An element is returned for each available Geographic Region.
        /// </summary>
        /// <param name="orgId">The org ID.</param>
        /// <returns>A list of regions associated with the org ID.</returns>
        public async Task<IEnumerable<Region>> GetListOfMultiGeographyRegions(Guid orgId)
        {
            var relativeUrl = string.Format("{0}/multigeo", orgId);
            var uri = new Uri(relativeUrl, UriKind.Relative);

            var regions = await ApiGetAsync<Geos>(uri);

            return regions.Items;
        }

        /// <summary>
        /// Allows the current Primary Administrator user to designate a Sub-Administrator user belonging to the 
        /// same organization <paramref name="orgId"/> to become the Primary Administrator for the organization.
        /// The Sub-Administrator is identified by their <paramref name="username"/>.
        /// </summary>
        /// <param name="orgId">The org ID of the account.</param>
        /// <param name="username">The Sub-Administrator account.</param>
        /// <returns>A <see cref="ApiStatus"/> result that describes whether or not the operation was successful.</returns>
        public Task<ApiStatus> DeleteSubAdministratorAccount(Guid orgId, string username)
        {
            return ExecuteAccountCommand(orgId, username, "{0}/account/{1}?delete");
        }

        /// <summary>
        /// Allows the current Primary Administrator user to designate a Sub-Administrator user belonging to the 
        /// same organization <paramref name="orgId"/> to become the Primary Administrator for the organization.
        /// The Sub-Administrator is identified by their <paramref name="username"/>.
        /// </summary>
        /// <param name="orgId">The org ID of the account.</param>
        /// <param name="username">The Sub-Administrator account.</param>
        /// <returns>A <see cref="ApiStatus"/> result that describes whether or not the operation was successful.</returns>
        public Task<ApiStatus> DesignatePrimaryAdministratorAccount(Guid orgId, string username)
        {
            return ExecuteAccountCommand(orgId, username, "{0}/account/{1}?primary");
        }

        /// <summary>
        /// This function identifies the list of data centers available to the organization of the authenticating user. 
        /// </summary>
        /// <param name="orgId">The organization that is associated with the data centers.</param>
        /// <returns>The list of data centers associated with the organization.</returns>
        public async Task<IEnumerable<DataCenterWithMaintenanceStatus>> GetListOfDataCentersWithMaintenanceStatuses(Guid orgId)
        {
            var url = string.Format("{0}/datacenterWithMaintenanceStatus?", orgId);
            var dataCenters = await ApiGetAsync<DatacentersWithMaintenanceStatus>(new Uri(url, UriKind.Relative));
            return dataCenters.Items;
        }

        /// <summary>
        /// Lists the Accounts belonging to the Organization identified by <paramref name="orgId"/>. The list will include all 
        /// SubAdministrator accounts and the Primary Administrator account. The Primary Administrator is unique and is 
        /// identified by the “primary administrator” role.
        /// </summary>
        /// <param name="orgId">The org ID of the accounts.</param>
        /// <returns>A list of accounts associated with the <paramref name="orgId"/>.</returns>
        public async Task<IEnumerable<Account>> GetAccounts(Guid orgId)
        {
            var relativeUrl = string.Format("{0}/account", orgId);
            var accounts = await ApiGetAsync<Accounts>(new Uri(relativeUrl, UriKind.Relative));
            return accounts.Items;
        }

        /// <summary>
        /// Adds a new Sub-Administrator Account to the organization. 
        /// The account is created with a set of roles defining the level of access to the organization’s Cloud 
        /// resources or the account can be created as “read only”, restricted to just viewing Cloud resources and 
        /// unable to generate Cloud Reports.
        /// </summary>
        /// <param name="orgId">The org ID that will be associated with the account.</param>
        /// <param name="account">The account that will be added to the org.</param>
        /// <returns>A <see cref="Status"/> object instance that shows the results of the operation.</returns>
        public async Task<Status> AddSubAdministratorAccount(Guid orgId, Account account)
        {
            var relativeUrl = string.Format("{0}/account", orgId);
            
			return await ApiPostAsync<Account, Status>(new Uri(relativeUrl, UriKind.Relative), new Account());
        }

        /// <summary>
        /// This function updates an existing Administrator Account.
        /// </summary>
        /// <param name="orgId">The org ID that is associated with the account.</param>
        /// <param name="account">The account to be updated.</param>
        /// <returns>A <see cref="Status"/> object instance that shows the results of the operation.</returns>
        public async Task<Status> UpdateAdministratorAccount(Guid orgId, Account account)
        {
            var parameters = new Dictionary<string, string>();
            parameters["username"] = account.UserName;
            parameters["password"] = account.Password;
            parameters["email"] = account.EmailAddress;
            parameters["fullname"] = account.FullName;
            parameters["firstName"] = account.FirstName;
            parameters["lastName"] = account.LastName;
            parameters["department"] = account.Department;
            parameters["customDefined1"] = account.CustomDefined1;
            parameters["customDefined2"] = account.CustomDefined2;

            var parameterStrings = parameters.Where(kvp=>kvp.Value != null).Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value));
            var parameterText = string.Join("&", parameterStrings);

            var roles = account.MemberOfRoles.Select(role => string.Format("role={0}", role.Name));
            var roleParameters = string.Join("&", roles);

            var postBody = string.Join("&", parameterText, roleParameters);

            var relativeUrl = string.Format("{0}/account/{1}", orgId, account.UserName);
            
			return await ApiPostAsync<string, Status>(new Uri(relativeUrl, UriKind.Relative), postBody);
        }

        private async Task<ApiStatus> ExecuteAccountCommand(Guid orgId, string username, string uriFormat)
        {
            var uriText = string.Format(uriFormat, orgId, username);
            var uri = new Uri(uriText, UriKind.Relative);
           
			return await ApiGetAsync<ApiStatus>(uri);
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
        public async Task<IEnumerable<DeployedImageWithSoftwareLabels>> GetOsServerImagesTask(string networkLocation)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(networkLocation), "Network location must not be empty or null");

            var images = await ApiGetAsync<DeployedImagesWithSoftwareLabels>(ApiUris.OsServerImages(networkLocation));
            return images.Items;
        }

        /// <summary>
        /// Gets the networks with locations
        /// </summary>
        /// <returns>The networks</returns>
        public async Task<IEnumerable<NetworkWithLocationsNetwork>> GetNetworksTask()
        {
            var networks = await this.ApiGetAsync<NetworkWithLocations>(ApiUris.NetworkWithLocations(Account.OrganizationId));
            return networks.Items;
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
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(name), "name argument must not be empty");
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(networkId), "network id must not be empty");
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(imageId), "Image id must not be empty");
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(adminPassword), "administrator password cannot be null or empty");

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

        /// <summary>
        /// Powers on the server.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerPowerOn(string serverId)
	    {
	        return await this.ApiGetAsync<Status>(ApiUris.PowerOnServer(Account.OrganizationId, serverId));
	    }
        
        /// <summary>
        /// Powers off the server
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerPowerOff(string serverId)
        {
            return await this.ApiGetAsync<Status>(ApiUris.PoweroffServer(Account.OrganizationId, serverId));
        }

        /// <summary>
        /// Hard boot of the server.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerRestart(string serverId)
        {
            return await this.ApiGetAsync<Status>(ApiUris.RebootServer(Account.OrganizationId, serverId));
        }

        /// <summary>
        /// "Graceful" shutdown of the server.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerShutdown(string serverId)
        {
            return await this.ApiGetAsync<Status>(ApiUris.ShutdownServer(Account.OrganizationId, serverId));
        }

        /// <summary>
        /// Deletes the server. <remarks>The server must be turned off and with backup disabled</remarks>
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerDelete(string serverId)
        {
            return await this.ApiGetAsync<Status>(ApiUris.DeleteServer(Account.OrganizationId, serverId));
        }

        /// <summary>
        /// Gets all the deployed servers.
        /// </summary>
        /// <returns>A list of deployed servers</returns>
        public async Task<IEnumerable<ServersWithBackupServer>> GetDeployedServers()
        {
            var servers = await this.ApiGetAsync<ServersWithBackup>(ApiUris.DeployedServers(Account.OrganizationId));
            return servers.Items;
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
        public async Task<TResult> ApiGetAsync<TResult>(Uri relativeOperationUri)
        {
            if (relativeOperationUri == null) throw new ArgumentNullException("relativeOperationUri");

            if (relativeOperationUri.IsAbsoluteUri) throw new ArgumentException("The supplied URI is not a relative URI.", "relativeOperationUri");

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
                    case HttpStatusCode.BadRequest:
                        {
                            // Handle specific CaaS Status response when getting a bad request
                            var status = response.Content.ReadAsAsync<Status>(_mediaTypeFormatters).Result;
                            throw ComputeApiException.InvalidRequest(status.operation, status.resultDetail);
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

        /// <summary>
        /// Invoke a CaaS API operation using a HTTP POST request.
        /// </summary>
        /// <typeparam name="TObject">The XML-Serialisable data contract type that the request will be sent.</typeparam>
        /// <typeparam name="TResult">The XML-serialisable data contract type into which the response will be deserialised.</typeparam>
        /// <param name="relativeOperationUri">The operation URI (relative to the CaaS API's base URI).</param>
        /// <param name="content">The content of type <see cref="TObject"/> that will be deserialised and passed in the body of the POST request.</param>
        /// <returns>The operation result.</returns>
        public async Task<TResult> ApiPostAsync<TObject, TResult>(Uri relativeOperationUri, TObject content)
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
                    case HttpStatusCode.BadRequest:
                        {
                            // Handle specific CaaS Status response when posting a bad request
                            var status = response.Content.ReadAsAsync<Status>(_mediaTypeFormatters).Result;
                            throw ComputeApiException.InvalidRequest(status.operation, status.resultDetail);
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
