namespace DD.CBU.Compute.Api.Client.Network20
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Contracts.Network20;
	using DD.CBU.Compute.Api.Contracts.Requests;

    /// <summary>
    /// Extension methods for network domain operations.
    /// </summary>
    public static class NetworkDomainExtensions
	{
		/// <summary>	This function gets list of network domains from Cloud. </summary>
		/// <param name="client">			The client. </param>
		/// <param name="pagingOptions">	Options for controlling the paging. </param>
		/// <returns>	The list of network domains associated with the organization. </returns>
		[Obsolete("Use IComputeApiClient.Networking.NetworkDomain instead")]
		public static async Task<IEnumerable<NetworkDomainType>> GetNetworkDomains(this IComputeApiClient client, PageableRequest pagingOptions = null)
		{
			return (await client.Networking.NetworkDomain.GetNetworkDomainsPaginated(null, pagingOptions)).items;
		}

		/// <summary>	This function gets list of network domains from Cloud. </summary>
		/// <param name="client">		  	The client. </param>
		/// <param name="networkDomainId">	Network domain id. </param>
		/// <returns>	The list of network domains associated with the organization. </returns>
		[Obsolete("Use IComputeApiClient.Networking.NetworkDomain instead")]
		public static async Task<NetworkDomainType> GetNetworkDomain(this IComputeApiClient client, Guid networkDomainId)
		{
			return await client.Networking.NetworkDomain.GetNetworkDomain(networkDomainId);
		}

        /// <summary>	This function gets list of network domains from Cloud. </summary>
        /// <param name="client">		  	The client. </param>
        /// <param name="networkDomainName">The network domain name. </param>
        /// <returns>	The list of network domains associated with the organization. </returns>
        [Obsolete("Use IComputeApiClient.Networking.NetworkDomain instead")]
        public static async Task<NetworkDomainType> GetNetworkDomain(this IComputeApiClient client, string networkDomainName)
        {
            return await client.Networking.NetworkDomain.GetNetworkDomain(networkDomainName);
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
        [Obsolete("Use IComputeApiClient.Networking.NetworkDomain instead")]
		public static async Task<ResponseType> DeployNetworkDomain(this IComputeApiClient client, DeployNetworkDomainType networkDomain)
		{
			return await client.Networking.NetworkDomain.DeployNetworkDomain(networkDomain);
		}

		/// <summary>	An IComputeApiClient extension method that deletes the network domain. </summary>
		/// <param name="client">	The client. </param>
		/// <param name="id">	 	The identifier of the network domain. </param>
		/// <returns>	A job response from the API; </returns>
		[Obsolete("Use IComputeApiClient.Networking.NetworkDomain instead")]
		public static async Task<ResponseType> DeleteNetworkDomain(this IComputeApiClient client, string id)
		{
			return await client.Networking.NetworkDomain.DeleteNetworkDomain(Guid.Parse(id));
		}
	}
}
