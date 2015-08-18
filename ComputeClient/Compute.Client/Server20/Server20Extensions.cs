namespace DD.CBU.Compute.Api.Client.Server20
{
	using System;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Contracts.Network20;
	using DD.CBU.Compute.Api.Contracts.Requests;
	using DD.CBU.Compute.Api.Contracts.Requests.Server20;

	/// <summary>	A server 2.0 extensions methods. </summary>
	public static class Server20Extensions
	{
		/// <summary>
		/// 	Gets MCP 2 deployed servers. 
		/// </summary>		
		/// <param name="client">
		/// 	The <see cref="ComputeApiClient"/> object. 
		/// </param>
		/// <param name="options">
		/// The options.
		/// </param>
		/// <param name="pagingOptions">
		/// The paging Options.
		/// </param>
		/// <returns>
		/// 	The MCP 2 deployed servers. 
		/// </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IComputeApiClient.GetMCP2DeployedServers()"/>
		[Obsolete("Use IComputeApiClient.ServerManagement.Server methods")]
		public static async Task<ServersResponseCollection> GetMcp2DeployedServers(
			this IComputeApiClient client,
			ServerListOptions options = null,
			PageableRequest pagingOptions = null)
		{
			return await client.ServerManagement.Server.GetMcp2DeployedServers(options, pagingOptions);
		}

		/// <summary>	Gets MCP 2 deployed servers. </summary>
		/// <remarks>	Anthony, 6/17/2015. </remarks>
		/// <param name="client">  	The <see cref="ComputeApiClient"/> object. </param>
		/// <param name="serverId">	Identifier for the server. </param>
		/// <returns>	The MCP 2 deployed servers. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IComputeApiClient.GetMCP2DeployedServers()"/>
		[Obsolete("Use IComputeApiClient.ServerManagement.Server methods")]
		public static async Task<ServerType> GetMcp2DeployedServer(this IComputeApiClient client, Guid serverId)
		{
			return await client.ServerManagement.Server.GetMcp2DeployedServer(serverId);
		}
	}
}
