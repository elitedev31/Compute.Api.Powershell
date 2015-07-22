namespace DD.CBU.Compute.Api.Client.Network20
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Network20;
	using DD.CBU.Compute.Api.Contracts.Network20;
	using DD.CBU.Compute.Api.Contracts.Requests;

	/// <summary>
	/// The network domain.
	/// </summary>
	public class NetworkDomainAccessor : INetworkDomainAccessor
	{
		/// <summary>
		/// The _client.
		/// </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// 	Initializes a new instance of the DD.CBU.Compute.Api.Client.Network20.NetworkDomain
		/// 	class.
		/// </summary>
		/// <param name="apiClient">	The client. </param>
		public NetworkDomainAccessor(IWebApi apiClient)
		{
			_apiClient = apiClient;
		}

		/// <summary>
		/// The get network domains.
		/// </summary>
		/// <param name="pagingOptions">
		/// The paging options.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<NetworkDomainType>> GetNetworkDomains(PageableRequest pagingOptions = null)
		{
			var networks = await _apiClient.GetAsync<networkDomains>(ApiUris.NetworkDomains(_apiClient.OrganizationId), pagingOptions);
			return networks.networkDomain;
		}

		/// <summary>
		/// 	This function gets list of network domains from Cloud. 
		/// </summary>
		/// <param name="networkDomainId">
		/// 	Network domain id. 
		/// </param>
		/// <param name="networkName">
		/// 	  	The network Name. 
		/// </param>
		/// <param name="pagingOptions">
		/// 	Options for controlling the paging. 
		/// </param>
		/// <returns>
		/// 	The list of network domains associated with the organization. 
		/// </returns>
		public async Task<IEnumerable<NetworkDomainType>> GetNetworkDomain(Guid networkDomainId, string networkName, PageableRequest pagingOptions = null)
		{
			var networks = await _apiClient.GetAsync<networkDomains>(ApiUris.NetworkDomain(_apiClient.OrganizationId, networkDomainId, networkName), pagingOptions);
			return networks.networkDomain;
		}

		/// <summary>
		/// This function deploys a new network domains to Cloud
		/// </summary>
		/// <param name="networkDomain">
		/// The network Domain.
		/// </param>
		/// <returns>
		/// Response containing status.
		/// </returns>
		public async Task<ResponseType> DeployNetworkDomain(DeployNetworkDomainType networkDomain)
		{
			var response = await _apiClient.PostAsync<DeployNetworkDomainType, ResponseType>(ApiUris.CreateNetworkDomain(_apiClient.OrganizationId), networkDomain);
			return response;
		}

		/// <summary>
		/// 	An IComputeApiClient extension method that deletes the network domain. 
		/// </summary>
		/// <param name="id">
		/// 	 	The identifier of the network domain. 
		/// </param>
		/// <returns>
		/// 	A job response from the API; 
		/// </returns>
		public async Task<ResponseType> DeleteNetworkDomain(string id)
		{
			ResponseType response = await
				_apiClient.PostAsync<DeleteNetworkDomainType, ResponseType>(
					ApiUris.DeleteNetworkDomain(_apiClient.OrganizationId), new DeleteNetworkDomainType { id = id });
			return response;
		}

	}
}
