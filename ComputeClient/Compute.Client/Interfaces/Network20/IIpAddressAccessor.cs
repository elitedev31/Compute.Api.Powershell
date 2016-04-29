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
		/// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
		/// <returns>	The public IP block. </returns>
		Task<PublicIpBlockType> GetPublicIpBlock(Guid publicIpBlockId);

        /// <summary>	Gets public IP block. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
        /// <returns>	The public IP block. </returns>
		[Obsolete("Use overload without unnecessary networkDomainId argument.")]
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

        /// <summary>The get reserved private ipv 4 addresses.</summary>
        /// <param name="reservedPrivateIpv4ListOptions">The reserved private ipv 4 list options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<IEnumerable<ReservedPrivateIpv4AddressType>> GetReservedPrivateIpv4Addresses(ReservedPrivateIpv4ListOptions reservedPrivateIpv4ListOptions = null);

        /// <summary>The get reserved private ipv 4 addresses paginated.</summary>
        /// <param name="reservedPrivateIpv4ListOptions">The reserved private ipv 4 list options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PagedResponse<ReservedPrivateIpv4AddressType>> GetReservedPrivateIpv4AddressesPaginated(ReservedPrivateIpv4ListOptions reservedPrivateIpv4ListOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>The reserve private ipv 4 address.</summary>
        /// <param name="reservePrivateIpv4Address">The reserve private ipv 4 address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> ReservePrivateIpv4Address(ReservePrivateIpv4AddressType reservePrivateIpv4Address);

        /// <summary>The unreserve private ipv 4 address.</summary>
        /// <param name="unReservePrivateIpv4Address">The un reserve private ipv 4 address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> UnreservePrivateIpv4Address(UnreservePrivateIpv4AddressType unReservePrivateIpv4Address);

        /// <summary>The reserve ipv 6 address.</summary>
        /// <param name="reserveIpv6Address">The reserve ipv 6 address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> ReserveIpv6Address(ReserveIpv6AddressType reserveIpv6Address);

        /// <summary>The unreserve ipv 6 address.</summary>
        /// <param name="unreserveIpv6Address">The unreserve ipv 6 address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> UnreserveIpv6Address(UnreserveIpv6AddressType unreserveIpv6Address);

        /// <summary>The get reserved ipv 6 addresses.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<IEnumerable<ReservedIpv6AddressType>> GetReservedIpv6Addresses();

        /// <summary>The get reserved ipv 6 addresses.</summary>
        /// <param name="vlanId">The vlan id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<IEnumerable<ReservedIpv6AddressType>> GetReservedIpv6Addresses(Guid vlanId);

        /// <summary>The get reserved ipv 6 addresses.</summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<IEnumerable<ReservedIpv6AddressType>> GetReservedIpv6Addresses(string ipAddress);

        /// <summary>The get reserved ipv 6 addresses paginated.</summary>
        /// <param name="reservedIpv6ListOptions">The reserved ipv 6 list options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PagedResponse<ReservedIpv6AddressType>> GetReservedIpv6AddressesPaginated(ReservedIpv6ListOptions reservedIpv6ListOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>The get reserved ipv 6 addresses paginated.</summary>
        /// <param name="vlanId">The vlan id.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PagedResponse<ReservedIpv6AddressType>> GetReservedIpv6AddressesPaginated(Guid vlanId, IPageableRequest pagingOptions = null);

        /// <summary>The get reserved ipv 6 addresses paginated.</summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PagedResponse<ReservedIpv6AddressType>> GetReservedIpv6AddressesPaginated(string ipAddress, IPageableRequest pagingOptions = null);
	}
}
