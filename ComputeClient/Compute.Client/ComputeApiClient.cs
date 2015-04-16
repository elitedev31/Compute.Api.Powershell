

using System.Security;
using DD.CBU.Compute.Api.Contracts.Vendor;

namespace DD.CBU.Compute.Api.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Linq;

    using DD.CBU.Compute.Api.Client.Vendor;
    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Utilities;
    using DD.CBU.Compute.Api.Contracts;
    using DD.CBU.Compute.Api.Contracts.Datacenter;
    using DD.CBU.Compute.Api.Contracts.Directory;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Server;
    using DD.CBU.Compute.Api.Contracts.Image;
    using DD.CBU.Compute.Api.Contracts.Software;
    using System.Collections.Specialized;

    /// <summary>
    ///		A client for the Dimension Data Compute-as-a-Service (CaaS) API.
    /// </summary>
    public sealed class ComputeApiClient
        : DisposableObject, IComputeApiClient
    {  
        #region Instance data

	    private string _ftpHost;


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
        /// <param name="apiHostUri">
        /// The api Host Uri.
        /// </param>
        public ComputeApiClient(string apiHostUri)
        {
            if (String.IsNullOrWhiteSpace(apiHostUri))
                throw new ArgumentNullException("apiHostUri", "Argument cannot be null or empty");
            WebApi = new WebApi(KnownApiUri.Instance.GetMcp1BaseUri(apiHostUri));
            Mcp2WebApi = new WebApi(KnownApiUri.Instance.GetMcp2BaseUri(apiHostUri));
        }

        /// <summary>
        /// Creates a new CaaS API client using a known vendor and region.
        /// </summary>
        /// <param name="vendor">the vendor</param>
        /// <param name="region">the region</param>
        public ComputeApiClient(KnownApiVendor vendor, KnownApiRegion region)
        {
            var baseUri = KnownApiUri.Instance.GetBaseUri(vendor, region);
            _ftpHost = KnownApiUri.Instance.GetFtpHost(vendor, region);

            if (!baseUri.IsAbsoluteUri) throw new ArgumentException("Base URI supplied is not an absolute URI", "vendor");

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
		/// The FTP Host.
		/// </summary>
	    public string FtpHost
	    {
		    get { return _ftpHost; }
	    }

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
        /// Access to the web API for login/logout and account info
        /// </summary>
        public IWebApi Mcp2WebApi { get; private set; }

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
            Mcp2WebApi.Credentials = accountCredentials;
            return await WebApi.LoginAsync(accountCredentials);
        }

        /// <summary>
        ///	Log out of the CaaS API.
        /// </summary>
        public void Logout()
        {
            WebApi.Logout();
        }

        /// <summary>
        /// Gets a list of software labels
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SoftwareLabel>> GetListOfSoftwareLabels()
        {
            var relativeUrl = string.Format("{0}/softwarelabel", Account.OrganizationId);
            var uri = new Uri(relativeUrl, UriKind.Relative);

            var labels = await WebApi.ApiGetAsync<SoftwareLabels>(uri);

            return labels.Items;
        }

        /// <summary>
        /// Returns a list of the Multi-Geography Regions available for the supplied {org-id
        /// An element is returned for each available Geographic Region.
        /// </summary>
        /// <returns>A list of regions associated with the org ID.</returns>
        public async Task<IEnumerable<Geo>> GetListOfMultiGeographyRegions()
        {
            var relativeUrl = string.Format("{0}/multigeo", Account.OrganizationId);
            var uri = new Uri(relativeUrl, UriKind.Relative);

            var regions = await WebApi.ApiGetAsync<Geos>(uri);

            return regions.Items;
        }

        /// <summary>
        /// Allows the current Primary Administrator user to designate a Sub-Administrator user belonging to the 
        /// same organization to become the Primary Administrator for the organization.
        /// The Sub-Administrator is identified by their <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The Sub-Administrator account.</param>
        /// <returns>A <see cref="ApiStatus"/> result that describes whether or not the operation was successful.</returns>
        public async Task<Status> DeleteSubAdministratorAccount(string username)
        {
            return await ExecuteAccountCommand(username, "{0}/account/{1}?delete");
        }

        /// <summary>
        /// Used to retrieve full details of an Administrator account associated with the Organization identified by {orgid}.
        //If Primary Administrator credentials are used this function returns details of any Administrator
        //({username}) associated with the Organization ({ord-id}).
        //However, the function can also be used with Sub-Administrator credentials to retrieve details of their own
        //user account, in which case {username} must match the Sub-Administrator credentials supplied.
        /// The Sub-Administrator is identified by their <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The Administrator or sub-administrator account.</param>
        /// <returns>A <see cref="ApiStatus"/> result that describes whether or not the operation was successful.</returns>
        public async Task<AccountWithPhoneNumber> GetAdministratorAccount(string username)
        {
            var relativeUrl = string.Format("{0}/accountWithPhoneNumber/{1}", Account.OrganizationId,username);
            var uri = new Uri(relativeUrl, UriKind.Relative);

            var account = await WebApi.ApiGetAsync<AccountWithPhoneNumber>(uri);
            return account;

        }


        /// <summary>
        /// Allows the current Primary Administrator user to designate a Sub-Administrator user belonging to the 
        /// same organization to become the Primary Administrator for the organization.
        /// The Sub-Administrator is identified by their <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The Sub-Administrator account.</param>
        /// <returns>A <see cref="ApiStatus"/> result that describes whether or not the operation was successful.</returns>
        public async Task<Status> DesignatePrimaryAdministratorAccount(string username)
        {
            return await ExecuteAccountCommand(username, "{0}/account/{1}?primary");
        }



        /// <summary>
        /// This function identifies the list of data centers available to the organization of the authenticating user. 
        /// </summary>
        /// <returns>The list of data centers associated with the organization.</returns>
        public async Task<IEnumerable<DatacenterWithMaintenanceStatusType>> GetDataCentersWithMaintenanceStatuses()
        {
            var dataCenters = await WebApi.ApiGetAsync<DatacentersWithMaintenanceStatus>(ApiUris.DatacentresWithMaintanence(Account.OrganizationId));
            return dataCenters.datacenter;
        }

        /// <summary>
        /// Lists the Accounts belonging to the Organization identified by the organisation. The list will include all 
        /// SubAdministrator accounts and the Primary Administrator account. The Primary Administrator is unique and is 
        /// identified by the “primary administrator” role.
        /// </summary>
        /// <returns>A list of accounts associated with the organisation.</returns>
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var relativeUrl = string.Format("{0}/account", Account.OrganizationId);
            var accounts = await WebApi.ApiGetAsync<Accounts>(new Uri(relativeUrl, UriKind.Relative));
            return accounts.Items;
        }

        /// <summary>
        /// Adds a new Sub-Administrator Account to the organization. 
        /// The account is created with a set of roles defining the level of access to the organization’s Cloud 
        /// resources or the account can be created as “read only”, restricted to just viewing Cloud resources and 
        /// unable to generate Cloud Reports.
        /// </summary>
        /// <param name="account">The account that will be added to the org.</param>
        /// <returns>A <see cref="Status"/> object instance that shows the results of the operation.</returns>
        public async Task<Status> AddSubAdministratorAccount(AccountWithPhoneNumber account)
        {

            var relativeUrl = string.Format("{0}/accountWithPhoneNumber", Account.OrganizationId);

            return await WebApi.ApiPostAsync<AccountWithPhoneNumber, Status>(new Uri(relativeUrl, UriKind.Relative), account);
        }

        /// <summary>
        /// This function updates an existing Administrator Account.
        /// </summary>
        /// <param name="account">The account to be updated.</param>
        /// <returns>A <see cref="Status"/> object instance that shows the results of the operation.</returns>
        public async Task<Status> UpdateAdministratorAccount(AccountWithPhoneNumber account)
        {

            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(account.password))
                parameters["password"] = account.password;
            if (!string.IsNullOrEmpty(account.emailAddress))
                parameters["emailAddress"] = account.emailAddress;
            if (!string.IsNullOrEmpty(account.fullName))
                parameters["fullName"] = account.fullName;
            if (!string.IsNullOrEmpty(account.firstName))
                parameters["firstName"] = account.firstName;
            if (!string.IsNullOrEmpty(account.lastName))
                parameters["lastName"] = account.lastName;
            if (!string.IsNullOrEmpty(account.department))
                parameters["department"] = account.department;
            if (!string.IsNullOrEmpty(account.customDefined1))
                parameters["customDefined1"] = account.customDefined1;
            if (!string.IsNullOrEmpty(account.customDefined2))
                parameters["customDefined2"] = account.customDefined2;
            if (!string.IsNullOrEmpty(account.phoneCountryCode))
                parameters["phoneCountryCode"] = account.phoneCountryCode;
            if (!string.IsNullOrEmpty(account.phoneNumber))
                parameters["phoneNumber"] = account.phoneNumber;

            var postBody = parameters.ToQueryString();

            if (account.MemberOfRoles.Any())
            {

                var roles = account.MemberOfRoles.Select(role => string.Format("role={0}", role.Name));
                var roleParameters = string.Join("&", roles);

                postBody = string.Join("&", postBody, roleParameters);
            }

            return
                await
                    WebApi.ApiPostAsync<Status>(ApiUris.UpdateAdministrator(Account.OrganizationId, account.userName),
                        postBody);
        }

     

        private async Task<Status> ExecuteAccountCommand(string username, string uriFormat)
        {
            var uriText = string.Format(uriFormat, Account.OrganizationId, username);
            var uri = new Uri(uriText, UriKind.Relative);

            return await WebApi.ApiGetAsync<Status>(uri);
        }

        /// <summary>
        ///		Asynchronously get a list of all CaaS data centres that are available for use by the specified organisation.
        /// </summary>
        /// <returns>
        ///		A read-only list of <see cref="IDatacenterDetail"/>s representing the data centre information.
        /// </returns>
        [Obsolete("This method was replaced by GetListOfDataCentersWithMaintenanceStatuses based on CaaS API!")]
        public async Task<IReadOnlyList<DatacenterWithDiskSpeedDetails>> GetAvailableDataCenters()
        {
            CheckDisposed();

            DatacentersWithDiskSpeedDetails datacentersWithDiskSpeedDetails =
                await WebApi.ApiGetAsync<DatacentersWithDiskSpeedDetails>(
                    ApiUris.DatacentersWithDiskSpeedDetails(
                        Account.OrganizationId
                    )
                );

            return datacentersWithDiskSpeedDetails.datacenter;
        }

        /// <summary>
        ///		Get a list of all system-defined images (with software labels) deployed in the specified data centre.
        /// </summary>
        /// <param name="locationName">
        ///		The short name of the location in which the data centre is located.
        /// </param>
        /// <returns>
        ///		A read-only list <see cref="DeployedImageWithSoftwareLabelsType"/>, sorted by UTC creation date / time, representing the images.
        /// </returns>
        [Obsolete]
        public async Task<IReadOnlyList<DeployedImageWithSoftwareLabelsType>> GetImages(string locationName)
        {
            if (String.IsNullOrWhiteSpace(locationName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'locationName'.",
                    "locationName");

            var imagesWithSoftwareLabels =
                await
                WebApi.ApiGetAsync<DeployedImagesWithSoftwareLabels>(ApiUris.ImagesWithSoftwareLabels(locationName));

            return imagesWithSoftwareLabels.DeployedImageWithSoftwareLabels;
        }

        /// <summary>
        /// Get OS server images, paramenters are just for filtering. Use String.Empty on the parameter where filtering is not required.
        /// </summary>
        /// <param name="imageid">the imageId filter</param>
        /// <param name="name">the name filter</param>
        /// <param name="location">the location filter</param>
        /// <param name="operatingSystemId">the OS id</param>
        /// <param name="operatingSystemFamily">The OS family</param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetImages(string imageId, string name, string location, string operatingSystemId, string operatingSystemFamily)
        {

            var imagesWithDiskSpeed =
              await
              WebApi.ApiGetAsync<ImagesWithDiskSpeed>(ApiUris.ImagesWithDiskSpeed(Account.OrganizationId,ServerImageType.OS,imageId,name,location,operatingSystemId,operatingSystemFamily));

            if (imagesWithDiskSpeed.image == null)
                return null;
            
            return imagesWithDiskSpeed.image;
        }




        /// <summary>
        /// This function lists the available Customer Images at a particular Location for the provided org-id.
        /// The response adds to the deprecated List Deployed Customer Images in Location function with 
        /// the addition of zero to many, optional softwareLabel elements, listing the Priced Software packages installed on the Customer Image.
        /// </summary>
        /// <param name="networkLocation">The network location</param>
        /// <returns>A list of deployed customer images with software labels in location</returns>
        [Obsolete]
        public async Task<IEnumerable<DeployedImageWithSoftwareLabelsType>> GetCustomerServerImages(string networkLocation)
        {
            //Contract.Requires(!string.IsNullOrWhiteSpace(networkLocation), "Network location must not be empty or null");

            var images = await WebApi.ApiGetAsync<DeployedImagesWithSoftwareLabels>(ApiUris.CustomerImagesWithSoftwareLabels(Account.OrganizationId, networkLocation));
            return images.DeployedImageWithSoftwareLabels;
        }


        /// <summary>
        /// Get customer server images
        /// </summary>
        /// <param name="imageid">the imageId filter</param>
        /// <param name="name">the name filter</param>
        /// <param name="location">the location filter</param>
        /// <param name="operatingSystemId">the OS id</param>
        /// <param name="operatingSystemFamily">The OS family</param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetCustomerServerImages(string imageId, string name, string location, string operatingSystemId, string operatingSystemFamily)
        {

            var imagesWithDiskSpeed =
              await
              WebApi.ApiGetAsync<ImagesWithDiskSpeed>(ApiUris.ImagesWithDiskSpeed(Account.OrganizationId, ServerImageType.CUSTOMER, imageId, name, location, operatingSystemId, operatingSystemFamily));

            if (imagesWithDiskSpeed.image == null)
                return null;

            return imagesWithDiskSpeed.image;
        }


        /// <summary>
        ///  Remove customer server images
        /// </summary>
        /// <param name="imageId">The ImageId</param>
        /// <returns></returns>
        public async Task<Status> RemoveCustomerServerImage(string imageId)
        {
            return await WebApi.ApiGetAsync<Status>(ApiUris.RemoveCustomerServerImage(Account.OrganizationId, imageId));
        
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
        [Obsolete("This method is deprecated, please use DeployServerWithDiskSpeedImageTask instead.")]
	    public async Task<Status> DeployServerImageTask(string name, string description, string networkId, string imageId, string adminPassword, bool isStarted)
	    {
            //Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(name), "name argument must not be empty");
            //Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(networkId), "network id must not be empty");
            //Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(imageId), "Image id must not be empty");
            //Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(adminPassword), "administrator password cannot be null or empty");

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
                            isStarted = isStarted
                        });
	    }


        /// <summary>
        /// Deploys a server using an image into a specified network.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="networkId"></param>
        /// <param name="imageId"></param>
        /// <param name="adminPassword"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public async Task<Status> DeployServerWithDiskSpeedImageTask(string name, string description, string networkId, string privateIp, string imageId, string adminPassword, bool start)
        {
          
                return
             await
             this.WebApi.ApiPostAsync<NewServerToDeployWithDiskSpeed, Status>(
                 ApiUris.DeployServerWithDiskSpeed(Account.OrganizationId),
                 new NewServerToDeployWithDiskSpeed
                 {
                     name = name,
                     description = description,
                     imageId = imageId,
                     networkId = networkId,
                     privateIp = privateIp,
                     administratorPassword = adminPassword,
                     start = start
                 });
            
          
         
        }

        public async Task<Status> DeployServerWithDiskSpeedImageTask(string name, string description, string networkId, string privateIp, string imageId, string adminPassword, bool start, Disk[] disk)
        {

            return 
                await
                    this.WebApi.ApiPostAsync<NewServerToDeployWithDiskSpeed, Status>(
                        ApiUris.DeployServerWithDiskSpeed(Account.OrganizationId),
                        new NewServerToDeployWithDiskSpeed
                        {
                            name = name,
                            description = description,
                            imageId = imageId,
                            networkId = networkId,
                            privateIp = privateIp,
                            administratorPassword = adminPassword,
                            start = start,
                            disk = disk
                        });



        }



        /// <summary>
        /// Modify server server settings.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <param name="name">The server new name on CaaS. This paramenter does not change the machine/host name.</param>
        /// <param name="description">The new description for the server.</param>
        /// <param name="memory">Memory (in MB). Value must be represent a GB integer (e.g. 1024,. 2048, 3072, 4096, etc.)</param>
        /// <param name="cpucount">Number of virtual CPU’s (e.g. 1, 2, 4 etc.)</param>        
        /// <param name="privateIp">The new privateIp of the server.</param>
        /// <returns></returns>
        public async Task<Status> ModifyServer(string serverId, string name, string description, int memory, int cpucount, string privateIp)
        {
                                  
            //build que query string paramenters
            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(name))
                parameters.Add("name", name);
            if (!string.IsNullOrEmpty(description))
                parameters.Add("description", description);
            if (memory>0)
                parameters.Add("memory", memory.ToString());
            if (cpucount > 0)
                parameters.Add("cpuCount", cpucount.ToString());
            if (!string.IsNullOrEmpty(privateIp))
                parameters.Add("privateIp", privateIp);
           
            // build the query string
            string poststring = parameters.ToQueryString();

            return await WebApi.ApiPostAsync<Status>(ApiUris.ModifyServer(Account.OrganizationId,serverId),poststring);
        
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
        /// Triggers an update of the VMware Tools software running on the guest OS of a virtual server
        /// </summary>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> ServerUpdateVMwareTools(string serverId)
        {
            return await this.WebApi.ApiGetAsync<Status>(ApiUris.UpdateServerVMwareTools(Account.OrganizationId, serverId));
        }


        /// <summary>
        /// Initiates a clone of a server to create a Customer Image
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <param name="imageName">the customer image name.</param>
        /// <param name="imageDesc">the customer image description.</param>
        /// <returns></returns>
        public async Task<Status> ServerCloneToCustomerImage(string serverId, string imageName, string imageDesc)
        {

            return await this.WebApi.ApiGetAsync<Status>(ApiUris.CloneServerToCustomerImage(Account.OrganizationId, serverId,imageName,imageDesc));
        
        }

        /// <summary>
        /// Change server disk size
        /// </summary>
        /// <param name="serverId">the server id</param>
        /// <param name="diskId">ths disk id</param>
        /// <param name="sizeInGb">new size of the disk</param>
        /// <returns></returns>
        public async Task<Status> ChangeServerDiskSize(string serverId, string diskId, string sizeInGb)
        {
            return await 
                this.WebApi.ApiPostAsync<ChangeDiskSize,Status>(
                ApiUris.ChangeServerDiskSize(Account.OrganizationId, serverId,diskId),
                new ChangeDiskSize 
                { 
                 newSizeGb=sizeInGb
                }
                );
        }



        /// <summary>
        /// Change server disk speed
        /// </summary>
        /// <param name="serverId">the server id</param>
        /// <param name="diskId">ths disk id</param>
        /// <param name="speedId">new size of the disk</param>
        /// <returns></returns>
        public async Task<Status> ChangeServerDiskSpeed(string serverId, string diskId, string speedId)
        {
            return await
                this.WebApi.ApiPostAsync<ChangeDiskSpeed, Status>(
                ApiUris.ChangeServerDiskSpeed(Account.OrganizationId, serverId, diskId),
                new ChangeDiskSpeed
                {
                    speed = speedId
                }
                );
        }

        /// <summary>
        /// Add disk to existing server
        /// </summary>
        /// <param name="serverId">the server id</param>
        /// <param name="size">size in GB</param>
        /// <param name="speedId">the speed id</param>
        /// <returns>Returns a status of the HTTP request</returns>
        public async Task<Status> AddServerDisk(string serverId, string size, string speedId)
        {
            return await
                this.WebApi.ApiGetAsync<Status>(
                ApiUris.AddServerDisk(Account.OrganizationId, serverId, size, speedId));
        }

        /// <summary>
        /// Remove disk from existing server
        /// </summary>
        /// <param name="serverId">the server id</param>
        /// <param name="diskId">the disk id</param>
        /// <returns></returns>
        public async Task<Status> RemoveServerDisk(string serverId, string diskId)
        {
            return await
                this.WebApi.ApiGetAsync<Status>(
                ApiUris.RemoveServerDisk(Account.OrganizationId, serverId, diskId));
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
            var servers = await this.WebApi.ApiGetAsync<ServersWithBackup>(ApiUris.DeployedServers(Account.OrganizationId,null,null,null,null));
            return servers.server;
        }

        /// <summary>
        /// Gets filtered list of the deployed servers.
        /// </summary>
        /// <returns>A list of deployed servers</returns>
        public async Task<IEnumerable<ServerWithBackupType>> GetDeployedServers(string serverId, string name,string networkId, string location)
        {
            var servers = await this.WebApi.ApiGetAsync<ServersWithBackup>(ApiUris.DeployedServers(Account.OrganizationId,serverId,name,networkId,location));
            return servers.server;
        }


        /// <summary>
        /// Creates a new Server Anti-Affinity Rule between two servers on the same Cloud network. 
        /// </summary>
        /// <param name="serverId1">the serverId for the 1st server</param>
        /// <param name="serverId2">the serverId for the 2nd server</param>
        /// <returns></returns>
        public async Task<Status> CreateServerAntiAffinityRule(string serverId1, string serverId2)
        {

            return await
               this.WebApi.ApiPostAsync<NewAntiAffinityRule, Status>(
               ApiUris.CreateAntiAffinityRule(Account.OrganizationId),
               new NewAntiAffinityRule
               {
                   serverId = new string[2] { serverId1,serverId2}
               }
               );

        }


        /// <summary>
        /// List all Server Anti-Affinity Rules 
        /// </summary>
        /// <param name="ruleId">filter by ruleId</param>
        /// <param name="location">filter by location</param>
        /// <param name="networkId">filter by networkid</param>
        /// <returns></returns>
        public async Task<IEnumerable<AntiAffinityRuleType>> GetServerAntiAffinityRules(string ruleId, string location,
            string networkId)
        {

            var rules = await 
                this.WebApi.ApiGetAsync<AntiAffinityRules>(ApiUris.GetAntiAffinityRule(Account.OrganizationId, ruleId,
                    location, networkId));
            return rules.antiAffinityRule;



        }

        /// <summary>
        /// Remove a server Anti-Affinity Rule between two servers on the same Cloud network. 
        /// </summary>
        /// <param name="ruleId">the ruleId</param>
        /// <returns></returns>
        public async Task<Status> RemoveServerAntiAffinityRule(string ruleId)
        {

            return await this.WebApi.ApiGetAsync<Status>(ApiUris.RemoveAntiAffinityRule(Account.OrganizationId, ruleId));

        }

        /// <summary>
        /// Since MultiGeo call is only valid for the home geo, use this method to discover what is your home geo and the applicable regions for this user.
        /// This is a multithreaded call that uses the underlying ComputeApiClient.GetListOfMultiGeographyRegions() 
        /// to discover the home geo and multi geo for this user to all API endpoints known for vendor.
        /// Note: Most of the user vendor is DimensionData. Use this if you have to guess which vendor the user is under.
        /// </summary>
        /// <param name="vendor">The vendor of the user</param>
        /// <param name="credential">credential of the user</param>
        /// <returns></returns>
        public async Task<IEnumerable<Geo>> DiscoverHomeMultiGeo(KnownApiVendor vendor, ICredentials credential)
        {
            var regionList = KnownApiUri.Instance.GetKnownRegionList(vendor);

            var computeClients = regionList.Select(region => new ComputeApiClient(vendor, region)).ToArray();
            if (computeClients.Length == 0)
            {
                throw new Exception("No known end points for this vendor");
            }
            
            var loginTasks = computeClients.Select(client => client.LoginAsync(credential)).ToArray();

            // try login to all known regions simultaneoulsy. Note, not all regions may be enabled for this particular client.
            try
            {
                await Task.WhenAll(loginTasks);
            }
            catch (Exception aex)
            {
                //ignore (there might be region that this user is not enabled)
            }

            computeClients = computeClients.Where(client => client.WebApi.IsLoggedIn).ToArray();
            if (computeClients.Length == 0)
            {
                throw new Exception("Invalid login or user doesn't exists");
            }

            var multiGeoTasks = computeClients.Select(client => client.GetListOfMultiGeographyRegions()).ToArray();

            // multiGeo only works in the home geo.
            try
            {
                await Task.WhenAll(multiGeoTasks);
            }
            catch (Exception aex)
            {
                //ignore (only one task will return with valid result)
            }

            var validMultiGeo = multiGeoTasks.Single(task => task.Status == TaskStatus.RanToCompletion && task.Result != null).Result;
            return  validMultiGeo;
        }

        #endregion // Public methods
    }
}
