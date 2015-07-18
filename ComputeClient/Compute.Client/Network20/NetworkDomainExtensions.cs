namespace DD.CBU.Compute.Api.Client.Network20
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Contracts.Network20;
	using DD.CBU.Compute.Api.Contracts.Requests;

	public static class NetworkDomainExtensions
	{
		/// <summary>	This function gets list of network domains from Cloud. </summary>
		/// <param name="client">			The client. </param>
		/// <param name="pagingOptions">	Options for controlling the paging. </param>
		/// <returns>	The list of network domains associated with the organization. </returns>
		public static async Task<IEnumerable<NetworkDomainType>> GetNetworkDomains(this IComputeApiClient client, PageableRequest pagingOptions = null)
		{
			var networks = await client.WebApi.ApiGetAsync<networkDomains>(ApiUris.NetworkDomains(client.Account.OrganizationId), pagingOptions);
			return networks.networkDomain;
		}

		/// <summary>	This function gets list of network domains from Cloud. </summary>
		/// <param name="client">		  	The client. </param>
		/// <param name="networkDomainId">	Network domain id. </param>
		/// <param name="networkName">	  	The network Name. </param>
		/// <param name="pagingOptions">  	Options for controlling the paging. </param>
		/// <returns>	The list of network domains associated with the organization. </returns>
		public static async Task<IEnumerable<NetworkDomainType>> GetNetworkDomain(this IComputeApiClient client, Guid networkDomainId, string networkName, PageableRequest pagingOptions = null)
		{
			var networks = await client.WebApi.ApiGetAsync<networkDomains>(ApiUris.NetworkDomain(client.Account.OrganizationId, networkDomainId, networkName), pagingOptions);
			return networks.networkDomain;
		}

		/// <summary>
		/// This function deploys a new network domains to Cloud
		/// </summary>
		/// <param name="client">
		/// The client.
		/// </param>
		/// <param name="networkDomain">
		/// The network Domain.
		/// </param>
		/// <returns>
		/// Response containing status.
		/// </returns>
		public static async Task<ResponseType> DeployNetworkDomain(this IComputeApiClient client, DeployNetworkDomainType networkDomain)
		{
			var response = await client.WebApi.ApiPostAsync<DeployNetworkDomainType, ResponseType>(ApiUris.CreateNetworkDomain(client.Account.OrganizationId), networkDomain);
			return response;
		}

		/// <summary>	An IComputeApiClient extension method that deletes the network domain. </summary>
		/// <param name="client">	The client. </param>
		/// <param name="id">	 	The identifier of the network domain. </param>
		/// <returns>	A job response from the API; </returns>
		public static async Task<ResponseType> DeleteNetworkDomain(this IComputeApiClient client, string id)
		{
			ResponseType response = await
				client.WebApi.ApiPostAsync<DeleteNetworkDomainType, ResponseType>(
					ApiUris.DeleteNetworkDomain(client.Account.OrganizationId), new DeleteNetworkDomainType { id = id });
			return response;
		}
	}
}
