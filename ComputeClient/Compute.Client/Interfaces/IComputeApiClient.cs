namespace DD.CBU.Compute.Api.Client.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.Datacenter;
    using DD.CBU.Compute.Api.Contracts.Directory;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Software;

    /// <summary>
    /// The interface of the CaaS API Client
    /// </summary>
    public interface IComputeApiClient : IDisposable
    {
        /// <summary>
        /// The account of the organisation.
        /// </summary>
        IAccount Account { get; }

        /// <summary>
        /// The web API that requests directly from the REST API.
        /// </summary>
        IWebApi WebApi { get; }
        
        /// <summary>
        /// Login into the organisation account using credentials.
        /// </summary>
        /// <param name="accountCredentials">The account credentials.</param>
        /// <returns>The account associated with the organisation.</returns>
        Task<IAccount> LoginAsync(ICredentials accountCredentials);
        
        /// <summary>
        /// Gets a list of software labels.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SoftwareLabel>> GetListOfSoftwareLabels();

        Task<IEnumerable<Region>> GetListOfMultiGeographyRegions();

        Task<ApiStatus> DeleteSubAdministratorAccount(string username);

        Task<ApiStatus> DesignatePrimaryAdministratorAccount(string username);

        /// <summary>
        /// Gets all the data centres for the organisation.
        /// </summary>
        /// <returns>The data centres.</returns>
        Task<IEnumerable<DatacenterWithMaintenanceStatusType>> GetDataCentersWithMaintenanceStatuses();

        /// <summary>
        /// Gets the account of the organisation.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Account>> GetAccounts();

        Task<Status> AddSubAdministratorAccount(Account account);

        Task<Status> UpdateAdministratorAccount(Account account);

        [Obsolete("Use GetDataCentersWithMaintenanceStatuses instead!")]
        Task<IReadOnlyList<IDatacenterDetail>> GetAvailableDataCenters();

        /// <summary>
        /// Gets the OS images at a particular location.
        /// </summary>
        /// <param name="locationName">The location.</param>
        /// <returns></returns>
        Task<IReadOnlyList<DeployedImageWithSoftwareLabelsType>> GetImages(string locationName);

        /// <summary>
        /// Gets the deployed customer server images.
        /// </summary>
        /// <param name="networkLocation">The location.</param>
        /// <returns></returns>
        Task<IEnumerable<DeployedImageWithSoftwareLabelsType>> GetCustomerServerImages(string networkLocation);

        /// <summary>
        /// Deploy a server using an image in a specified network.
        /// </summary>
        /// <param name="name">The name of the new server.</param>
        /// <param name="description">The description of the new server.</param>
        /// <param name="networkId">The network id to deploy the server.</param>
        /// <param name="imageId">The image id to deploy the server.</param>
        /// <param name="adminPassword">The administrator password.</param>
        /// <param name="isStarted">Will the server powers on after deployment?</param>
        /// <returns>The status of the deployment.</returns>
        Task<Status> DeployServerImageTask(
            string name,
            string description,
            string networkId,
            string imageId,
            string adminPassword,
            bool isStarted);

        /// <summary>
        /// Powers on the server.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <returns></returns>
        Task<Status> ServerPowerOn(string serverId);

        /// <summary>
        /// Powers off the server.
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        Task<Status> ServerPowerOff(string serverId);

        /// <summary>
        /// Restart the server.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <returns></returns>
        Task<Status> ServerRestart(string serverId);

        /// <summary>
        /// Shutdown the server.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <returns></returns>
        Task<Status> ServerShutdown(string serverId);

        /// <summary>
        /// Delete the server.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <returns></returns>
        Task<Status> ServerDelete(string serverId);

        /// <summary>
        /// Gets the deployed servers.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ServerWithBackupType>> GetDeployedServers();
    }
}