namespace DD.CBU.Compute.Api.Client.Interfaces.Server20
{
    using System;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Server20;

    /// <summary>
    /// The ServerAccessor interface.
    /// </summary>
    public interface IServerAccessor
    {
        /// <summary>
        /// The get mcp 2 deployed servers.
        /// </summary>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ServersResponseCollection> GetMcp2DeployedServers(ServerListOptions filteringOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>
        /// The get mcp 2 deployed server.
        /// </summary>
        /// <param name="serverId">
        /// The server id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ServerType> GetMcp2DeployedServer(Guid serverId);

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

        /// <summary>
        /// Adds an additional NIC to a server.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <param name="vlanId">The VLAN id</param>
        /// <param name="privateIpv4">The Private IP v4 address</param>
        /// <returns></returns>
        Task<ResponseType> AddNic(Guid serverId, Guid? vlanId, string privateIpv4);

        /// <summary>
        /// Removes an additional NIC from a server.
        /// </summary>
        /// <param name="nicId">The NIC id.</param>
        /// <returns></returns>
        Task<ResponseType> RemoveNic(Guid nicId);

        /// <summary>
        /// Updates the Cloud record to match the value set on the deployed server.
        /// </summary>
        /// <param name="notifyNicIpChange">The Notify NIC IP change model.</param>
        /// <returns>The async type of <see cref="ResponseType"/></returns>
        Task<ResponseType> NotifyNicIpChange(NotifyNicIpChangeType notifyNicIpChange);

        /// <summary>
        /// Deploys a server to MCP1.0 or MCP 2.0 data centers 
        /// </summary>
        /// <param name="serverDetails">Details of the server to be deployed</param>
        /// <returns>Response containing the server id</returns>
        Task<ResponseType> DeployServer(DeployServerType serverDetails);
    }
}
