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
        Task<ServersResponseCollection> GetMcp2DeployedServers(
			ServerListOptions filteringOptions = null,
            IPageableRequest pagingOptions = null);

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
	}
}
