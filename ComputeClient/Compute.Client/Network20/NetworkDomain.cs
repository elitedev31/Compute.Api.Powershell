using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;

namespace DD.CBU.Compute.Api.Client.Network20
{
	public class NetworkDomain : INetworkDomain
	{
		private IWebApi _client;

		/// <summary>
		/// 	Initializes a new instance of the DD.CBU.Compute.Api.Client.Network20.NetworkDomain
		/// 	class.
		/// </summary>
		/// <param name="client">	The client. </param>
		public NetworkDomain(IWebApi client)
		{
			_client = client;
		}

		public async Task<IEnumerable<NetworkDomainType>> GetNetworkDomains(PageableRequest pagingOptions = null)
		{
			var networks = await _client.GetAsync<networkDomains>(ApiUris.NetworkDomains(_client.OrganizationId), pagingOptions);
			return networks.networkDomain;
		}

		/// <summary>	This function gets list of network domains from Cloud. </summary>
		/// <param name="client">		  	The client. </param>
		/// <param name="networkDomainId">	Network domain id. </param>
		/// <param name="networkName">	  	The network Name. </param>
		/// <param name="pagingOptions">  	Options for controlling the paging. </param>
		/// <returns>	The list of network domains associated with the organization. </returns>
		public async Task<IEnumerable<NetworkDomainType>> GetNetworkDomain(Guid networkDomainId, string networkName, PageableRequest pagingOptions = null)
		{
			var networks = await _client.GetAsync<networkDomains>(ApiUris.NetworkDomain(_client.OrganizationId, networkDomainId, networkName), pagingOptions);
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
		public async Task<ResponseType> DeployNetworkDomain(DeployNetworkDomainType networkDomain)
		{
			var response = await _client.PostAsync<DeployNetworkDomainType, ResponseType>(ApiUris.CreateNetworkDomain(_client.OrganizationId), networkDomain);
			return response;
		}

		/// <summary>	An IComputeApiClient extension method that deletes the network domain. </summary>
		/// <param name="client">	The client. </param>
		/// <param name="id">	 	The identifier of the network domain. </param>
		/// <returns>	A job response from the API; </returns>
		public async Task<ResponseType> DeleteNetworkDomain(string id)
		{
			ResponseType response = await
				_client.PostAsync<DeleteNetworkDomainType, ResponseType>(
					ApiUris.DeleteNetworkDomain(_client.OrganizationId), new DeleteNetworkDomainType { id = id });
			return response;
		}

	}
}
