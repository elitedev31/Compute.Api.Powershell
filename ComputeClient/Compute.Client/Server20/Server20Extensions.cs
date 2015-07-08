using System;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Server;

namespace DD.CBU.Compute.Api.Client.Server20
{
	/// <summary>	A server 2.0 extensions methods. </summary>
	public static class Server20Extensions
	{
		/// <summary>	Gets MCP 2 deployed servers. </summary>
		/// <remarks>	Anthony, 6/17/2015. </remarks>
		/// <param name="client">	The <see cref="ComputeApiClient"/> object. </param>
		/// <returns>	The MCP 2 deployed servers. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IComputeApiClient.GetMCP2DeployedServers()"/>
		public static async Task<ServersResponseCollection> GetMcp2DeployedServers(this IComputeApiClient client, ServerListOptions options = null, PageableRequest pagingOptions = null)
		{
			ServersResponseCollection servers =
				await client.WebApi.ApiGetAsync<ServersResponseCollection>(ApiUris.GetMcp2Servers(client.Account.OrganizationId), pagingOptions);
			return servers;
		}

		/// <summary>	Gets MCP 2 deployed servers. </summary>
		/// <remarks>	Anthony, 6/17/2015. </remarks>
		/// <param name="client">  	The <see cref="ComputeApiClient"/> object. </param>
		/// <param name="serverId">	Identifier for the server. </param>
		/// <returns>	The MCP 2 deployed servers. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IComputeApiClient.GetMCP2DeployedServers()"/>
		public static async Task<ServerType> GetMcp2DeployedServer(this IComputeApiClient client, Guid serverId)
		{
			ServerType servers =
				await client.WebApi.ApiGetAsync<ServerType>(ApiUris.GetMcp2Server(client.Account.OrganizationId, serverId));
			return servers;
		}
	}
}
