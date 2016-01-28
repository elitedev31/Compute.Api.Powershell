using System;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;

    /// <summary>	IP Address Management functions. </summary>
    public interface IIpAddressAccessor
	{
		/// <summary>	Adds a public IP block. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The job from the API; </returns>
		Task<ResponseType> AddPublicIpBlock(Guid networkDomainId);

		/// <summary>	Gets public IP blocks. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The public IP blocks. </returns>
		Task<IEnumerable<PublicIpBlockType>> GetPublicIpBlocks(Guid networkDomainId);

        /// <summary>	Gets public IP blocks. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="pagingOptions">	The paging options, null means default. </param>
        /// <param name="options">Filtering options</param>
        /// <returns>	The public IP blocks. </returns>
        Task<PagedResponse<PublicIpBlockType>> GetPublicIpBlocksPaginated(Guid networkDomainId, IPageableRequest pagingOptions = null, PublicIpListOptions options = null);

        /// <summary>	Gets public IP block. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
        /// <returns>	The public IP block. </returns>
        Task<PublicIpBlockType> GetPublicIpBlock(Guid networkDomainId, Guid publicIpBlockId);

		/// <summary>	Gets reserved public addresses. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The reserved public addresses. </returns>
		Task<IEnumerable<ReservedPublicIpv4AddressType>> GetReservedPublicAddressesForNetworkDomain(Guid networkDomainId);

		/// <summary>	Gets reserved public addresses for network. </summary>
		/// <param name="networkId">	Identifier for the network. </param>
		/// <returns>	The reserved public addresses for network. </returns>
		Task<IEnumerable<ReservedPublicIpv4AddressType>> GetReservedPublicAddressesForNetwork(Guid networkId);

        /// <summary>	Gets reserved public IP addresses for a network domain. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="pagingOptions">	The paging options, null means default. </param>
        /// <returns>	The reserved public addresses. </returns>
        Task<PagedResponse<ReservedPublicIpv4AddressType>> GetReservedPublicAddressesForNetworkDomainPaginated(Guid networkDomainId, IPageableRequest pagingOptions = null);

        /// <summary>	Gets reserved private addresses. </summary>
        /// <param name="vlanId">The VLAN Id.</param>
        /// <returns>	The reserved private addresses. </returns>
        Task<IEnumerable<ReservedPrivateIpv4AddressType>> GetReservedPrivateAddressesForVlan(Guid vlanId);

        /// <summary>	Gets reserved private addresses. </summary>
        /// <param name="vlanId">The VLAN Id.</param>
        /// <param name="pagingOptions">	The paging options, null means default. </param>
        /// <returns>	The reserved private addresses. </returns>
        Task<PagedResponse<ReservedPrivateIpv4AddressType>> GetReservedPrivateAddressesForVlanPaginated(Guid vlanId, IPageableRequest pagingOptions = null);

        /// <summary>	Deletes the public IP block. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
        /// <returns>	The job from the API; </returns>
        Task<ResponseType> DeletePublicIpBlock(Guid networkDomainId, Guid publicIpBlockId);
    }
}
