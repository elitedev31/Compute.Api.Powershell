namespace DD.CBU.Compute.Api.Client.Interfaces.Server20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.General;
    using Contracts.Network20;
    using Contracts.Requests;
    using Contracts.Requests.Server20;
    using Contracts.Server;
    using ServerType = Contracts.Network20.ServerType;

    /// <summary>
    /// The ServerAccessor interface.
    /// </summary>
    public interface IServerAccessor
    {
        /// <summary>The get mcp 2 deployed servers.</summary>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Obsolete("Inconsistent: Use 'GetServers' or 'GetServersPaginated' instead.")]
        Task<ServersResponseCollection> GetMcp2DeployedServers(ServerListOptions filteringOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>The get mcp 2 deployed servers.</summary>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<IEnumerable<ServerType>> GetServers(ServerListOptions filteringOptions = null);

        /// <summary>The get mcp 2 deployed servers.</summary>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PagedResponse<ServerType>> GetServersPaginated(ServerListOptions filteringOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>The get mcp 2 deployed server.</summary>
        /// <param name="serverId">The server id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Obsolete("Inconsistent: Use 'GetServer' instead.")]
        Task<ServerType> GetMcp2DeployedServer(Guid serverId);

        /// <summary>The get mcp 2 deployed server.</summary>
        /// <param name="serverId">The server id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ServerType> GetServer(Guid serverId);

        /// <summary>	Deletes the server described by serverId. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> DeleteServer(Guid serverId);

        /// <summary>	Starts a server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> StartServer(Guid serverId);

        /// <summary>	Shutdown server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> ShutdownServer(Guid serverId);

        /// <summary>	Reboot server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> RebootServer(Guid serverId);

        /// <summary>	Resets the server described by serverId. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> ResetServer(Guid serverId);

        /// <summary>	Power off server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> PowerOffServer(Guid serverId);

        /// <summary>	Updates the v mware tools described by serverId. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> UpdateVmwareTools(Guid serverId);

        /// <summary>	Updates the vistual hardware for serverId. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> UpgradeVirtualHardware(Guid serverId);

        /// <summary>Deploys a server to MCP1.0 or MCP 2.0 data centers </summary>
        /// <param name="serverDetails">Details of the server to be deployed</param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> DeployServer(DeployServerType serverDetails);

        /// <summary>Cleans a failed server deployment.</summary>
        /// <param name="serverId">The server id.</param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> CleanServer(Guid serverId);

        /// <summary>Adds an additional NIC to a server.</summary>
        /// <param name="serverId">The server id.</param>
        /// <param name="vlanId">The VLAN id</param>
        /// <param name="privateIpv4">The Private IP v4 address</param>
        /// <param name="networkAdapter">The optional network adapter type (E1000 or VMXNET3)</param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> AddNic(Guid serverId, Guid? vlanId, string privateIpv4, string networkAdapter = null);

        /// <summary>Removes an additional NIC from a server.</summary>
        /// <param name="nicId">The NIC id.</param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> RemoveNic(Guid nicId);

        /// <summary>The list nics.</summary>
        /// <param name="vlanId">The vlan id.</param>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PagedResponse<NicWithSecurityGroupType>> ListNics(Guid vlanId, ListNicsOptions filteringOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>Updates the Cloud record to match the value set on the deployed server.</summary>
        /// <param name="notifyNicIpChange">The Notify NIC IP change model.</param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> NotifyNicIpChange(NotifyNicIpChangeType notifyNicIpChange);

        /// <summary>Updates compute resource properties of a Server </summary>
        /// <param name="reconfigureServer">Details of the server to be updated</param>
        /// <returns>	A standard CaaS response </returns>
        Task<ResponseType> ReconfigureServer(ReconfigureServerType reconfigureServer);

        /// <summary>The add disk.</summary>
        /// <param name="addDisk">The add disk.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> AddDisk(AddDiskType addDisk);

        /// <summary>The remove disk.</summary>
        /// <param name="removeDisk">The remove disk.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> RemoveDisk(RemoveDiskType removeDisk);
    }
}