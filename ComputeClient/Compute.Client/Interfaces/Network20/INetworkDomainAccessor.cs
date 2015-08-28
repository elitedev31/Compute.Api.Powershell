namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Network20;

    /// <summary>
    /// The NetworkDomain interface.
    /// </summary>
    public interface INetworkDomainAccessor
	{
        /// <summary>
        /// The get network domains.
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
        Task<IEnumerable<NetworkDomainType>> GetNetworkDomains(NetworkDomainListOptions filteringOptions = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// 	This function gets a network domain from Cloud.
        /// </summary>
        /// <param name="networkDomainId">
        /// 	Network domain id. 
        /// </param>
        /// <returns>
        /// 	The network domain with the supplied id. 
        /// </returns>
        Task<NetworkDomainType> GetNetworkDomain(Guid networkDomainId);

        /// <summary>
        /// 	This function gets a network domain from Cloud.
        /// </summary>
        /// <param name="networkDomainName">
        /// 	The network domain name. 
        /// </param>
        /// <returns>
        /// 	The network domain with the supplid name.
        /// </returns>
        Task<NetworkDomainType> GetNetworkDomain(string networkDomainName);

        /// <summary>
        /// This function deploys a new network domains to Cloud
        /// </summary>
        /// <param name="networkDomain">
        /// The network Domain.
        /// </param>
        /// <returns>
        /// Response containing status.
        /// </returns>
        Task<ResponseType> DeployNetworkDomain(DeployNetworkDomainType networkDomain);

	    /// <summary>
	    /// The modify network domain.
	    /// </summary>
	    /// <param name="networkDomain">
	    /// The network domain.
	    /// </param>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    Task<ResponseType> ModifyNetworkDomain(EditNetworkDomainType networkDomain);

		/// <summary>
		/// 	An IComputeApiClient extension method that deletes the network domain. 
		/// </summary>
		/// <param name="id">
		/// 	 	The identifier of the network domain. 
		/// </param>
		/// <returns>
		/// 	A job response from the API; 
		/// </returns>
		Task<ResponseType> DeleteNetworkDomain(string id);
	}
}
