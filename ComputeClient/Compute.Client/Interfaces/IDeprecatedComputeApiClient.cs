namespace DD.CBU.Compute.Api.Client.Interfaces
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.Datacenter;
	using DD.CBU.Compute.Api.Contracts.Directory;
	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Image;
	using DD.CBU.Compute.Api.Contracts.Server;
    using DD.CBU.Compute.Api.Contracts.Server10;
    using DD.CBU.Compute.Api.Contracts.Software;

    /// <summary>
    /// The interface of the CaaS API Client
    /// </summary>
	public interface IDeprecatedComputeApiClient
    {
	    /// <summary>
	    /// The login async.
	    /// </summary>
	    /// <param name="accountCredentials">
	    /// The account credentials.
	    /// </param>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    [Obsolete("Use Login() instead")]
        Task<IAccount> LoginAsync(ICredentials accountCredentials);

        /// <summary>
        /// Gets a list of software labels.
        /// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<IEnumerable<SoftwareLabel>> GetListOfSoftwareLabels();

        /// <summary>
        /// Gets a list of multi geography regions
        /// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<IEnumerable<Geo>> GetListOfMultiGeographyRegions();

        /// <summary>
        /// Deletes a sub administrator account
        /// </summary>
		/// <param name="username">
		/// The username
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> DeleteSubAdministratorAccount(string username);


        /// <summary>
        /// Get a (sub) administrator account
        /// </summary>
		/// <param name="username">
		/// The username
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<AccountWithPhoneNumber> GetAdministratorAccount(string username);

        /// <summary>
        /// Designate a primary administrator account
        /// </summary>
		/// <param name="username">
		/// The username
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> DesignatePrimaryAdministratorAccount(string username);

        /// <summary>
        /// Gets all the data centres for the organisation.
        /// </summary>
		/// <returns>
		/// The data centres.
		/// </returns>
		[Obsolete]
        Task<IEnumerable<DatacenterWithMaintenanceStatusType>> GetDataCentersWithMaintenanceStatuses();

        /// <summary>
        /// Gets the account of the organisation.
        /// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
		Task<IEnumerable<Contracts.Directory.Account>> GetAccounts();

        /// <summary>
        /// Adds a sub administrator account
        /// </summary>
		/// <param name="account">
		/// The account
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> AddSubAdministratorAccount(AccountWithPhoneNumber account);
        
        /// <summary>
        /// Updates an administrator account
        /// </summary>
		/// <param name="account">
		/// The account
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> UpdateAdministratorAccount(AccountWithPhoneNumber account);


        /// <summary>
        /// Gets available data centres
        /// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
        [Obsolete("Use GetDataCentersWithMaintenanceStatuses instead!")]
        Task<IReadOnlyList<DatacenterWithDiskSpeedDetails>> GetAvailableDataCenters();

        /// <summary>
        /// Gets the OS images at a particular location.
        /// </summary>
		/// <param name="locationName">
		/// The location.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
        [Obsolete]
        Task<IReadOnlyList<DeployedImageWithSoftwareLabelsType>> GetImages(string locationName);


        /// <summary>
        /// Get OS server images
        /// </summary>
		/// <param name="imageId">
		/// The imageId filter
		/// </param>
		/// <param name="name">
		/// The name filter
		/// </param>
		/// <param name="location">
		/// The location filter
		/// </param>
		/// <param name="operatingSystemId">
		/// The OS id
		/// </param>
		/// <param name="operatingSystemFamily">
		/// The OS family
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
        /// </returns>
        [Obsolete]
        Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetImages(
	        string imageId,
			string name,
			string location,
			string operatingSystemId,
			string operatingSystemFamily);

	    /// <summary>
        /// Gets the deployed customer server images.
        /// </summary>
		/// <param name="networkLocation">
		/// The location.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
        [Obsolete]
        Task<IEnumerable<DeployedImageWithSoftwareLabelsType>> GetCustomerServerImages(string networkLocation);


        /// <summary>
        /// Get customer server images
        /// </summary>
		/// <param name="imageId">
		/// The imageId filter
		/// </param>
		/// <param name="name">
		/// The name filter
		/// </param>
		/// <param name="location">
		/// The location filter
		/// </param>
		/// <param name="operatingSystemId">
		/// The OS id
		/// </param>
		/// <param name="operatingSystemFamily">
		/// The OS family
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
        /// </returns>
        Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetCustomerServerImages(
	        string imageId,
			string name,
			string location,
			string operatingSystemId,
			string operatingSystemFamily);

	    /// <summary>
        /// Remove customer images
        /// </summary>
		/// <param name="imageid">
		/// The image id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> RemoveCustomerServerImage(string imageid);

        /// <summary>
        /// Deploy a server using an image in a specified network.
        /// </summary>
		/// <param name="name">
		/// The name of the new server.
		/// </param>
		/// <param name="description">
		/// The description of the new server.
		/// </param>
		/// <param name="networkId">
		/// The network id to deploy the server.
		/// </param>
		/// <param name="imageId">
		/// The image id to deploy the server.
		/// </param>
		/// <param name="adminPassword">
		/// The administrator password.
		/// </param>
		/// <param name="isStarted">
		/// Will the server powers on after deployment?
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>
		[Obsolete("Use DeployServerWithDiskSpeedImageTask")]
        Task<Status> DeployServerImageTask(
            string name,
            string description,
            string networkId,
            string imageId,
            string adminPassword,
            bool isStarted);

        /// <summary>
        /// Deploy a server using an image in a specified network.
        /// </summary>
		/// <param name="name">
		/// The name of the new server.
		/// </param>
		/// <param name="description">
		/// The description of the new server.
		/// </param>
		/// <param name="networkId">
		/// The network id to deploy the server.
		/// </param>
		/// <param name="privateIp">
		/// The privateIp address to deploy the server.
		/// </param>
		/// <param name="imageId">
		/// The image id to deploy the server.
		/// </param>
		/// <param name="adminPassword">
		/// The administrator password.
		/// </param>
		/// <param name="start">
		/// Will the server powers on after deployment?
		/// </param>
		/// <param name="disk">
		/// Array od disk configurations
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>
		[Obsolete]
        Task<Status> DeployServerWithDiskSpeedImageTask(
            string name,
            string description,
            string networkId,
            string privateIp,
            string imageId,
            string adminPassword,
            bool start,
            Disk[] disk
            );


        /// <summary>
        /// Deploy a server using an image in a specified network.
        /// </summary>
		/// <param name="name">
		/// The name of the new server.
		/// </param>
		/// <param name="description">
		/// The description of the new server.
		/// </param>
		/// <param name="networkId">
		/// The network id to deploy the server.
		/// </param>
		/// <param name="privateIp">
		/// The network id or privateIp address to deploy the server.
		/// </param>
		/// <param name="imageId">
		/// The image id to deploy the server.
		/// </param>
		/// <param name="adminPassword">
		/// The administrator password.
		/// </param>
		/// <param name="start">
		/// Will the server powers on after deployment?
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>
		[Obsolete]
        Task<Status> DeployServerWithDiskSpeedImageTask(
            string name,
            string description,
            string networkId,
            string privateIp,
            string imageId,
            string adminPassword,
            bool start
            );


        /// <summary>
		/// The modify server.
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		/// <param name="memory">
		/// The memory.
		/// </param>
		/// <param name="cpucount">
		/// The CPU count.
		/// </param>
		/// <param name="privateIp">
		/// The private IP.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
		Task<Status> ModifyServer(string serverId, string name, string description, int memory, int cpucount, string privateIp);

               
        /// <summary>
        /// Powers on the server.
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> ServerPowerOn(string serverId);

        /// <summary>
        /// Powers off the server.
        /// </summary>
		/// <param name="serverId">
		/// Server Id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> ServerPowerOff(string serverId);

        /// <summary>
        /// Restart the server.
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> ServerRestart(string serverId);

		/// <summary>	Power cycles an existing deployed server. This is the equivalent of pulling and replacing the power cord for
		/// a physical server. Requires your organization ID and the ID of the target server.. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	Returns a status of the HTTP request </returns>
		[Obsolete]
	    Task<Status> ServerReset(string serverId);

        /// <summary>
        /// Shutdown the server.
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> ServerShutdown(string serverId);


        /// <summary>
        /// Modify server disk size.
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="diskId">
		/// The SCSI disk Id.
		/// </param>
		/// <param name="sizeInGb">
		/// Size In GB.
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>
		[Obsolete]
        Task<Status> ChangeServerDiskSize(string serverId, string diskId, string sizeInGb);


        /// <summary>
        /// Modify server disk speed.
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="diskId">
		/// The SCSI disk Id.
		/// </param>
		/// <param name="speedId">
		/// Size in GB.
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>
		[Obsolete]
        Task<Status> ChangeServerDiskSpeed(string serverId, string diskId, string speedId);


        /// <summary>
        /// Add Disk to Server
        /// </summary>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="size">
		/// The size of the new disk
		/// </param>
		/// <param name="speedId">
		/// The speed Id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> AddServerDisk(string serverId, string size, string speedId);


        /// <summary>
        /// Modify server server settings.
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="diskId">
		/// The SCSI disk Id.
		/// </param>
		/// <returns>
		/// The status of the deployment.
		/// </returns>
		[Obsolete]
        Task<Status> RemoveServerDisk(string serverId, string diskId);


        /// <summary>
        /// Triggers an update of the VMWare Tools software running on the guest OS of a virtual server
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> ServerUpdateVMwareTools(string serverId);


        /// <summary>
        /// Delete the server.
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> ServerDelete(string serverId);


        /// <summary>
        /// Initiates a clone of a server to create a Customer Image
        /// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="imageName">
		/// The customer image name.
		/// </param>
		/// <param name="imageDesc">
		/// The customer image description.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
		Task<Status> ServerCloneToCustomerImage(string serverId, string imageName, string imageDesc);

        /// <summary>
        /// Gets the deployed servers.
        /// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<IEnumerable<ServerWithBackupType>> GetDeployedServers();

        /// <summary>
        /// Gets a filtered list of deployed servers.
        /// </summary>
		/// <param name="serverid">
		/// The server Id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="networkId">
		/// The network Id.
		/// </param>
		/// <param name="location">
		/// The location.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
        /// </returns>        
		[Obsolete]
        Task<IEnumerable<ServerWithBackupType>> GetDeployedServers(
	        string serverid,
			string name,
			string networkId,
			string location);

	    /// <summary>
       /// Creates a new Server Anti-Affinity Rule between two servers on the same Cloud network. 
       /// </summary>
		/// <param name="serverId1">
		/// The server Id for the 1'st server
		/// </param>
		/// <param name="serverId2">
		/// The server Id for the 2'nd server
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> CreateServerAntiAffinityRule(string serverId1, string serverId2);

        /// <summary>
        /// List all Server Anti-Affinity Rules 
        /// </summary>
		/// <param name="ruleId">
		/// Filter by rule Id
		/// </param>
		/// <param name="location">
		/// Filter by location
		/// </param>
		/// <param name="networkId">
		/// Filter by network Id
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
        /// </returns>
		[Obsolete]
        Task<IEnumerable<AntiAffinityRuleType>> GetServerAntiAffinityRules(
	        string ruleId,
			string location,
			string networkId);

	    /// <summary>
        /// Remove a server Anti-Affinity Rule between two servers on the same Cloud network. 
        /// </summary>
		/// <param name="ruleId">
		/// The ruleId
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete]
        Task<Status> RemoveServerAntiAffinityRule(string ruleId);

        /// <summary>
		/// Since MultiGeo call is only valid for the home geo, use this method to discover what is your home geo and the
		///     applicable regions for this user.
		///     This is a multithreaded call that uses the underlying ComputeApiClient.GetListOfMultiGeographyRegions()
		///     to discover the home geo and multi geo for this user to all API endpoints known for vendor.
		///     Note: Most of the user vendor is DimensionData. Use this if you have to guess which vendor the user is under.
        /// </summary>
		/// <param name="vendor">
		/// The vendor of the user
		/// </param>
		/// <param name="credential">
		/// Credential of the user
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		[Obsolete("Use static method ComputeApiClient.GetListOfMultiGeographyRegionsFromHomeRegion instead")]
        Task<IEnumerable<Geo>> DiscoverHomeMultiGeo(KnownApiVendor vendor, ICredentials credential);
    }
}