using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;

namespace DD.CBU.Compute.Api.Client.Interfaces
{
	public interface INetworkDomain
	{
		Task<IEnumerable<NetworkDomainType>> GetNetworkDomains(PageableRequest pagingOptions = null);

		/// <summary>	This function gets list of network domains from Cloud. </summary>
		/// <param name="client">		  	The client. </param>
		/// <param name="networkDomainId">	Network domain id. </param>
		/// <param name="networkName">	  	The network Name. </param>
		/// <param name="pagingOptions">  	Options for controlling the paging. </param>
		/// <returns>	The list of network domains associated with the organization. </returns>
		Task<IEnumerable<NetworkDomainType>> GetNetworkDomain(Guid networkDomainId, string networkName, PageableRequest pagingOptions = null);

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
		Task<ResponseType> DeployNetworkDomain(DeployNetworkDomainType networkDomain);

		/// <summary>	An IComputeApiClient extension method that deletes the network domain. </summary>
		/// <param name="client">	The client. </param>
		/// <param name="id">	 	The identifier of the network domain. </param>
		/// <returns>	A job response from the API; </returns>
		Task<ResponseType> DeleteNetworkDomain(string id);
	}
}
