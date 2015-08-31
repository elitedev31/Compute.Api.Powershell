namespace DD.CBU.Compute.Api.Client.Server20
{
	using System;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Server20;
	using DD.CBU.Compute.Api.Contracts.Network20;
	using DD.CBU.Compute.Api.Contracts.Requests;
	using DD.CBU.Compute.Api.Contracts.Requests.Server20;

	/// <summary>
	/// The server 2.0 accessor.
	/// </summary>
	public class ServerAccessor : IServerAccessor
	{
		/// <summary>
		/// The _api client.
		/// </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="ServerAccessor"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public ServerAccessor(IWebApi apiClient)
		{
			_apiClient = apiClient;
		}

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
        public async Task<ServersResponseCollection> GetMcp2DeployedServers(ServerListOptions filteringOptions = null, IPageableRequest pagingOptions = null)
		{
			ServersResponseCollection servers = await _apiClient.GetAsync<ServersResponseCollection>(
                ApiUris.GetMcp2Servers(_apiClient.OrganizationId),
                pagingOptions,
                filteringOptions);
			return servers;
		}

		/// <summary>
		/// The get mcp 2 deployed server.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<ServerType> GetMcp2DeployedServer(Guid serverId)
		{
			ServerType server =
				await _apiClient.GetAsync<ServerType>(ApiUris.GetMcp2Server(_apiClient.OrganizationId, serverId));
			return server;
		}

		/// <summary>	Deletes the server described by serverId. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	A standard CaaS response. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.DeleteServer(Guid)"/>
		public Task<ResponseType> DeleteServer(Guid serverId)
		{
			return _apiClient.PostAsync<DeleteServerType, ResponseType>(ApiUris.DeleteServer(_apiClient.OrganizationId),
				new DeleteServerType { serverId = serverId.ToString() });
		}

		/// <summary>	Starts a server. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	A standard CaaS response. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.StartServer(Guid)"/>
		public Task<ResponseType> StartServer(Guid serverId)
		{
			return _apiClient.PostAsync<StartServerType, ResponseType>(ApiUris.StartServer(_apiClient.OrganizationId),
				new StartServerType { serverId = serverId.ToString() });
		}

		/// <summary>	Shutdown server. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	A standard CaaS response. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.ShutdownServer(Guid)"/>
		public Task<ResponseType> ShutdownServer(Guid serverId)
		{
			return _apiClient.PostAsync<ShutdownServerType, ResponseType>(ApiUris.ShutdownServer(_apiClient.OrganizationId),
				new ShutdownServerType { serverId = serverId.ToString() });
		}

		/// <summary>	Reboot server. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	A standard CaaS response. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.RebootServer(Guid)"/>
		public Task<ResponseType> RebootServer(Guid serverId)
		{
			return _apiClient.PostAsync<RebootServerType, ResponseType>(ApiUris.RebootServer(_apiClient.OrganizationId),
				new RebootServerType { serverId = serverId.ToString() });
		}

		/// <summary>	Resets the server described by serverId. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	A standard CaaS response. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.ResetServer(Guid)"/>
		public Task<ResponseType> ResetServer(Guid serverId)
		{
			return _apiClient.PostAsync<ResetServerType, ResponseType>(ApiUris.ResetServer(_apiClient.OrganizationId),
				new ResetServerType { serverId = serverId.ToString() });
		}

		/// <summary>	Power off server. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	A standard CaaS response. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.PowerOffServer(Guid)"/>
		public Task<ResponseType> PowerOffServer(Guid serverId)
		{
			return _apiClient.PostAsync<PowerOffServerType, ResponseType>(ApiUris.PowerOffServer(_apiClient.OrganizationId),
				new PowerOffServerType { serverId = serverId.ToString() });
		}

		/// <summary>	Updates the v mware tools described by serverId. </summary>
		/// <param name="serverId">	The server id. </param>
		/// <returns>	A standard CaaS response. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Server20.IServerAccessor.UpdateVmwareTools(Guid)"/>
		public Task<ResponseType> UpdateVmwareTools(Guid serverId)
		{
			return _apiClient.PostAsync<UpdateVmwareToolsServerType, ResponseType>(ApiUris.UpdateVmwareTools(_apiClient.OrganizationId),
				new UpdateVmwareToolsServerType { serverId = serverId.ToString() });
		}
	}
}
