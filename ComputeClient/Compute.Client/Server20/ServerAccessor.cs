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
	}
}
