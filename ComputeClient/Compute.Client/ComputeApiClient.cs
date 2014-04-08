using System.Linq;

using DD.CBU.Compute.Api.Contracts.Software;

namespace DD.CBU.Compute.Api.Client
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Net;
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
        ///		Create a new Compute-as-a-Service API client.
        /// </summary>
        /// <param name="targetRegionName">
        ///		The name of the region whose CaaS API end-point is targeted by the client.
        /// </param>
        public ComputeApiClient(string targetRegionName) 
        {
            if (String.IsNullOrWhiteSpace(targetRegionName))
                throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'targetRegionName'.", "targetRegionName");

            WebApi = new WebApi(targetRegionName);
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

            WebApi = new WebApi(baseUri);
        }

        /// <summary>
        /// Creates a new CaaS API client using a base URI.
        /// </summary>
        public ComputeApiClient(IHttpClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client", "Argument cannot be null");

            WebApi = new WebApi(client);
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
                if (WebApi != null)
                {
                    WebApi.Dispose();
                    WebApi = null;
                }
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
        public IAccount Account
        {
            get
            {
                return WebApi.Account;
            }
        }

        /// <summary>
        /// Access to the web API for login/logout and account info
        /// </summary>
        public IWebApi WebApi { get; private set; }

        /// <summary>
        ///	Asynchronously log into the CaaS API.
        /// </summary>
        /// <param name="accountCredentials">
        ///	The CaaS account credentials used to authenticate against the CaaS API.
        /// </param>
        /// <returns>
        ///	An <see cref="IAccount"/> implementation representing the CaaS account that the client is logged into.
        /// </returns>
        public async Task<IAccount> LoginAsync(ICredentials accountCredentials)
        {
            return await WebApi.LoginAsync(accountCredentials);
        }

        /// <summary>
        ///	Log out of the CaaS API.
        /// </summary>
        public void Logout()
        {
            WebApi.Logout();
        }

        public async Task<IEnumerable<SoftwareLabel>> GetListOfSoftwareLabels(Guid orgId)
        {
            var relativeUrl = string.Format("{0}/softwarelabel", orgId);
            var uri = new Uri(relativeUrl, UriKind.Relative);

            var labels = await WebApi.ApiGetAsync<SoftwareLabels>(uri);

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

            var regions = await WebApi.ApiGetAsync<Geos>(uri);

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
            var dataCenters = await WebApi.ApiGetAsync<DatacentersWithMaintenanceStatus>(new Uri(url, UriKind.Relative));
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
            var accounts = await WebApi.ApiGetAsync<Accounts>(new Uri(relativeUrl, UriKind.Relative));
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

            return await WebApi.ApiPostAsync<Account, Status>(new Uri(relativeUrl, UriKind.Relative), new Account());
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
            
			return await WebApi.ApiPostAsync<string, Status>(new Uri(relativeUrl, UriKind.Relative), postBody);
        }

        private async Task<ApiStatus> ExecuteAccountCommand(Guid orgId, string username, string uriFormat)
        {
            var uriText = string.Format(uriFormat, orgId, username);
            var uri = new Uri(uriText, UriKind.Relative);

            return await WebApi.ApiGetAsync<ApiStatus>(uri);
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
                await WebApi.ApiGetAsync<DatacentersWithDiskSpeedDetails>(
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
                await WebApi.ApiGetAsync<ImagesWithSoftwareLabels>(
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

            var images = await WebApi.ApiGetAsync<DeployedImagesWithSoftwareLabels>(ApiUris.OsServerImages(networkLocation));
            return images.Items;
        }

        /// <summary>
        /// Gets the networks with locations
        /// </summary>
        /// <returns>The networks</returns>
        public async Task<IEnumerable<NetworkWithLocationsNetwork>> GetNetworksTask()
        {
            var networks = await this.WebApi.ApiGetAsync<NetworkWithLocations>(ApiUris.NetworkWithLocations(Account.OrganizationId));
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
                this.WebApi.ApiPostAsync<NewServerToDeploy, Status>(
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
	        return await WebApi.ApiGetAsync<Status>(ApiUris.PowerOnServer(Account.OrganizationId, serverId));
	    }
        
        /// <summary>
        /// Powers off the server
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerPowerOff(string serverId)
        {
            return await this.WebApi.ApiGetAsync<Status>(ApiUris.PoweroffServer(Account.OrganizationId, serverId));
        }

        /// <summary>
        /// Hard boot of the server.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerRestart(string serverId)
        {
            return await this.WebApi.ApiGetAsync<Status>(ApiUris.RebootServer(Account.OrganizationId, serverId));
        }

        /// <summary>
        /// "Graceful" shutdown of the server.
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerShutdown(string serverId)
        {
            return await this.WebApi.ApiGetAsync<Status>(ApiUris.ShutdownServer(Account.OrganizationId, serverId));
        }

        /// <summary>
        /// Deletes the server. <remarks>The server must be turned off and with backup disabled</remarks>
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerDelete(string serverId)
        {
            return await this.WebApi.ApiGetAsync<Status>(ApiUris.DeleteServer(Account.OrganizationId, serverId));
        }

        /// <summary>
        /// Gets all the deployed servers.
        /// </summary>
        /// <returns>A list of deployed servers</returns>
        public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServers()
        {
            var servers = await this.WebApi.ApiGetAsync<ServersWithBackup>(ApiUris.DeployedServers(Account.OrganizationId));
            return servers.server;
        }

        #endregion // Public methods
    }
}
