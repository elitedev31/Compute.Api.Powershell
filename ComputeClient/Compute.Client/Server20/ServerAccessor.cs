namespace DD.CBU.Compute.Api.Client.Server20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.General;
    using Contracts.Network20;
    using Contracts.Requests;
    using Contracts.Requests.Server20;
    using Interfaces;
    using Interfaces.Server20;

    /// <summary>
    /// The server 2.0 accessor.
    /// </summary>
    public class ServerAccessor : IServerAccessor
    {
        /// <summary>
        /// The _api client.
        /// </summary>
        private readonly IWebApi _apiClient;

        /// <summary>Initialises a new instance of the <see cref="ServerAccessor"/> class.</summary>
        /// <param name="apiClient">The api client.</param>
        public ServerAccessor(IWebApi apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>The get mcp 2 deployed servers.</summary>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Obsolete("Inconsistent: Use 'GetServers' or 'GetServersPaginated' instead.")]
        public async Task<ServersResponseCollection> GetMcp2DeployedServers(ServerListOptions filteringOptions = null, IPageableRequest pagingOptions = null)
        {
            ServersResponseCollection servers = await _apiClient.GetAsync<ServersResponseCollection>(
                ApiUris.GetMcp2Servers(_apiClient.OrganizationId), 
                pagingOptions, 
                filteringOptions);
            return servers;
        }

        /// <summary>The get mcp 2 deployed servers.</summary>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IEnumerable<ServerType>> GetServers(ServerListOptions filteringOptions = null)
        {
            var response = await GetServersPaginated(filteringOptions, null);
            return response.items;
        }

        /// <summary>The get mcp 2 deployed servers.</summary>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PagedResponse<ServerType>> GetServersPaginated(ServerListOptions filteringOptions = null, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<ServersResponseCollection>(
                ApiUris.GetMcp2Servers(_apiClient.OrganizationId), 
                pagingOptions, 
                filteringOptions);

            return new PagedResponse<ServerType>
            {
                items = response.Server, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>The get mcp 2 deployed server.</summary>
        /// <param name="serverId">The server id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Obsolete("Inconsistent: Use 'GetServer' instead.")]
        public async Task<ServerType> GetMcp2DeployedServer(Guid serverId)
        {
            return await GetServer(serverId);
        }

        /// <summary>The get mcp 2 deployed server.</summary>
        /// <param name="serverId">The server id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ServerType> GetServer(Guid serverId)
        {
            return await _apiClient.GetAsync<ServerType>(ApiUris.GetMcp2Server(_apiClient.OrganizationId, serverId));
        }

        /// <summary>	Deletes the server described by serverId. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.DeleteServer(Guid)"/>
        public async Task<ResponseType> DeleteServer(Guid serverId)
        {
            return await _apiClient.PostAsync<DeleteServerType, ResponseType>(ApiUris.DeleteServer(_apiClient.OrganizationId), 
                new DeleteServerType {id = serverId.ToString()});
        }

        /// <summary>	Starts a server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.StartServer(Guid)"/>
        public async Task<ResponseType> StartServer(Guid serverId)
        {
            return await _apiClient.PostAsync<StartServerType, ResponseType>(ApiUris.StartServer(_apiClient.OrganizationId), 
                new StartServerType {id = serverId.ToString()});
        }

        /// <summary>	Shutdown server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.ShutdownServer(Guid)"/>
        public async Task<ResponseType> ShutdownServer(Guid serverId)
        {
            return await _apiClient.PostAsync<ShutdownServerType, ResponseType>(ApiUris.ShutdownServer(_apiClient.OrganizationId), 
                new ShutdownServerType {id = serverId.ToString()});
        }

        /// <summary>	Reboot server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.RebootServer(Guid)"/>
        public async Task<ResponseType> RebootServer(Guid serverId)
        {
            return await _apiClient.PostAsync<RebootServerType, ResponseType>(ApiUris.RebootServer(_apiClient.OrganizationId), 
                new RebootServerType {id = serverId.ToString()});
        }

        /// <summary>	Resets the server described by serverId. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.ResetServer(Guid)"/>
        public async Task<ResponseType> ResetServer(Guid serverId)
        {
            return await _apiClient.PostAsync<ResetServerType, ResponseType>(ApiUris.ResetServer(_apiClient.OrganizationId), 
                new ResetServerType {id = serverId.ToString()});
        }

        /// <summary>	Power off server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.PowerOffServer(Guid)"/>
        public async Task<ResponseType> PowerOffServer(Guid serverId)
        {
            return await _apiClient.PostAsync<PowerOffServerType, ResponseType>(ApiUris.PowerOffServer(_apiClient.OrganizationId), 
                new PowerOffServerType {id = serverId.ToString()});
        }

        /// <summary>	Updates the v mware tools described by serverId. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.UpdateVmwareTools(Guid)"/>
        public async Task<ResponseType> UpdateVmwareTools(Guid serverId)
        {
            return await _apiClient.PostAsync<UpdateVmwareToolsServerType, ResponseType>(ApiUris.UpdateVmwareTools(_apiClient.OrganizationId), 
                new UpdateVmwareToolsServerType {id = serverId.ToString()});
        }

        /// <summary>	Upgrade virtual hardware for the server. </summary>
        /// <param name="serverId">	The server id. </param>
        /// <returns>	A standard CaaS response. </returns>
        public async Task<ResponseType> UpgradeVirtualHardware(Guid serverId)
        {
            return await _apiClient.PostAsync<UpgradeVirtualHardware, ResponseType>(ApiUris.UpgradeVirtualHardware(_apiClient.OrganizationId), 
                new UpgradeVirtualHardware {id = serverId.ToString()});
        }

        /// <summary>Deploys a server to MCP1.0 or MCP 2.0 data centers </summary>
        /// <param name="serverDetails">Details of the server to be deployed</param>
        /// <returns>Response containing the server id</returns>
        public async Task<ResponseType> DeployServer(DeployServerType serverDetails)
        {
            return await _apiClient.PostAsync<DeployServerType, ResponseType>(
                ApiUris.DeployMCP20Server(_apiClient.OrganizationId), 
                serverDetails);
        }

        /// <summary>Cleans a failed server deployment.</summary>
        /// <param name="serverId">The server id.</param>
        /// <returns>	A standard CaaS response </returns>
        public async Task<ResponseType> CleanServer(Guid serverId)
        {
            return await _apiClient.PostAsync<CleanServerType, ResponseType>(
                ApiUris.CleanServer(_apiClient.OrganizationId), 
                new CleanServerType {id = serverId.ToString()});
        }

        /// <summary>Adds an additional NIC to a server.</summary>
        /// <param name="serverId">The server id.</param>
        /// <param name="vlanId">The VLAN id</param>
        /// <param name="privateIpv4">The Private IP v4 address</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> AddNic(Guid serverId, Guid? vlanId, string privateIpv4)
        {
            if (vlanId == null && string.IsNullOrEmpty(privateIpv4))
            {
                throw new ArgumentNullException("vlanId");
            }

            AddNicType addNicType = new AddNicType {serverId = serverId.ToString(), nic = new VlanIdOrPrivateIpType()};
            if (!string.IsNullOrEmpty(privateIpv4))
            {
                addNicType.nic.privateIpv4 = privateIpv4;
            }
            else if (vlanId != null)
            {
                addNicType.nic.vlanId = vlanId.ToString();
            }

            return await _apiClient.PostAsync<AddNicType, ResponseType>(ApiUris.AddNic(_apiClient.OrganizationId), addNicType);
        }

        /// <summary>Removes an additional NIC from a server.</summary>
        /// <param name="nicId">The NIC id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> RemoveNic(Guid nicId)
        {
            if (nicId == Guid.Empty)
            {
                throw new ArgumentException("'nicId' cannot be empty.");
            }

            return await _apiClient.PostAsync<RemoveNicType, ResponseType>(
                ApiUris.RemoveNic(_apiClient.OrganizationId), 
                new RemoveNicType {id = nicId.ToString()});
        }

        /// <summary>The list nics.</summary>
        /// <param name="vlanId">The vlan id.</param>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PagedResponse<NicWithSecurityGroupType>> ListNics(Guid vlanId, ListNicsOptions filteringOptions = null, IPageableRequest pagingOptions = null)
        {
            if (vlanId == Guid.Empty)
            {
                throw new ArgumentException("'vlanId' cannot be empty.");
            }

            var response = await _apiClient.GetAsync<nics>(ApiUris.ListNics(_apiClient.OrganizationId, vlanId), pagingOptions, filteringOptions);
            return new PagedResponse<NicWithSecurityGroupType>
            {
                items = response.nic, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>Updates the Cloud record to match the value set on the deployed server.</summary>
        /// <param name="notifyNicIpChange">The Notify NIC IP change model.</param>
        /// <returns>The async type of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> NotifyNicIpChange(NotifyNicIpChangeType notifyNicIpChange)
        {
            return
                await
                    _apiClient.PostAsync<NotifyNicIpChangeType, ResponseType>(
                        ApiUris.NotifyNicIpChange(_apiClient.OrganizationId), notifyNicIpChange);
        }

        /// <summary>Updates compute resource properties of a Server </summary>
        /// <param name="reconfigureServer">Details of the server to be updated</param>
        /// <returns>	A standard CaaS response </returns>
        public async Task<ResponseType> ReconfigureServer(ReconfigureServerType reconfigureServer)
        {
            return await _apiClient.PostAsync<ReconfigureServerType, ResponseType>(
                ApiUris.ReconfigureServer(_apiClient.OrganizationId), 
                reconfigureServer);
        }

        /// <summary>The add disk.</summary>
        /// <param name="addDisk">The add disk.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> AddDisk(AddDiskType addDisk)
        {
            return await _apiClient.PostAsync<AddDiskType, ResponseType>(ApiUris.AddDisk(_apiClient.OrganizationId), addDisk);
        }


        /// <summary>The remove disk.</summary>
        /// <param name="removeDisk">The remove disk.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> RemoveDisk(RemoveDiskType removeDisk)
        {
            return await _apiClient.PostAsync<RemoveDiskType, ResponseType>(ApiUris.RemoveDisk(_apiClient.OrganizationId), removeDisk);
        }
    }
}