namespace DD.CBU.Compute.Api.Client.Network20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.General;
    using Contracts.Network20;
    using Contracts.Requests;
    using Contracts.Requests.Network20;
    using Interfaces;
    using Interfaces.Network20;

    /// <summary>	An IP address management client. </summary>
    /// <seealso cref="T:DD.CBU.Compute.Api.Client.Interfaces.IIpam"/>
    public class IpAddressAccessor : IIpAddressAccessor
    {
        /// <summary>	The client. </summary>
        private readonly IWebApi _apiClient;

        /// <summary>	Initializes a new instance of the <see cref="IpAddressAccessor"/>.</summary>
        /// <param name="apiClient">	The client. </param>
        public IpAddressAccessor(IWebApi apiClient)
        {
            this._apiClient = apiClient;
        }

        /// <summary>	Adds a public IP block. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <returns>	The job from the API; </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.AddPublicIpBlock(string)"/>
        public async Task<ResponseType> AddPublicIpBlock(Guid networkDomainId)
        {
            return
                await
                    _apiClient.PostAsync<AddPublicIpBlockType, ResponseType>(
                        ApiUris.AddPublicIpBlock(_apiClient.OrganizationId), 
                        new AddPublicIpBlockType
                        {
                            networkDomainId = networkDomainId.ToString()
                        });
        }

        /// <summary>	Gets public IP blocks. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <returns>	The public IP blocks. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.GetPublicIpBlocks(string,IPageableRequest)"/>
        public async Task<IEnumerable<PublicIpBlockType>> GetPublicIpBlocks(Guid networkDomainId)
        {
            var response = await GetPublicIpBlocksPaginated(networkDomainId, null);
            return response.items;
        }

        /// <summary>	Gets public IP blocks. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="pagingOptions">	The paging options, null means default. </param>
        /// <param name="filterOptions">Paging option</param>
        /// <returns>	The public IP blocks. </returns>
        public async Task<PagedResponse<PublicIpBlockType>> GetPublicIpBlocksPaginated(Guid networkDomainId, IPageableRequest pagingOptions = null, PublicIpListOptions filterOptions = null)
        {
            var response = await _apiClient.GetAsync<publicIpBlocks>(ApiUris.GetPublicIpBlocks(_apiClient.OrganizationId, networkDomainId.ToString()), pagingOptions, filterOptions);
            return new PagedResponse<PublicIpBlockType>
            {
                items = response.publicIpBlock, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>	Gets public IP block. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
        /// <returns>	The public IP block. </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.GetPublicIpBlock(string,string)"/>
        public async Task<PublicIpBlockType> GetPublicIpBlock(Guid networkDomainId, Guid publicIpBlockId)
        {
            return
                await
                    _apiClient.GetAsync<PublicIpBlockType>(
                        ApiUris.GetPublicIpBlock(_apiClient.OrganizationId, publicIpBlockId.ToString()));
        }

        /// <summary>	Gets reserved public IP addresses for a network domain. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <returns>	The reserved public addresses. </returns>
        public async Task<IEnumerable<ReservedPublicIpv4AddressType>> GetReservedPublicAddressesForNetworkDomain(Guid networkDomainId)
        {
            return (await GetReservedPublicAddressesForNetworkDomainPaginated(networkDomainId, null)).items;
        }

        /// <summary>	Gets reserved public IP addresses for a network domain. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="pagingOptions">	The paging options, null means default. </param>
        /// <returns>	The reserved public addresses. </returns>
        public async Task<PagedResponse<ReservedPublicIpv4AddressType>> GetReservedPublicAddressesForNetworkDomainPaginated(Guid networkDomainId, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<reservedPublicIpv4Addresses>(
                ApiUris.GetReservedPublicAddresses(_apiClient.OrganizationId, 
                    networkDomainId.ToString()), 
                pagingOptions);

            return new PagedResponse<ReservedPublicIpv4AddressType>
            {
                items = response.ip, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>	Gets reserved public addresses for an MCP 1.0 network. </summary>
        /// <param name="networkId">	Identifier for the network. </param>
        /// <returns>	The reserved public addresses for network. </returns>
        public async Task<IEnumerable<ReservedPublicIpv4AddressType>> GetReservedPublicAddressesForNetwork(Guid networkId)
        {
            var response = await _apiClient.GetAsync<reservedPublicIpv4Addresses>(
                ApiUris.GetReservedPublicAddressesForNetwork(_apiClient.OrganizationId, networkId.ToString()));

            return response.ip;
        }

        /// <summary>The get reserved private ipv 4 addresses.</summary>
        /// <param name="reservedPrivateIpv4ListOptions">The reserved private ipv 4 list options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IEnumerable<ReservedPrivateIpv4AddressType>> GetReservedPrivateIpv4Addresses(ReservedPrivateIpv4ListOptions reservedPrivateIpv4ListOptions = null)
        {
            var response = await _apiClient.GetAsync<reservedPrivateIpv4Addresses>(
                ApiUris.GetReservedPrivateIpv4Addresses(_apiClient.OrganizationId), null, reservedPrivateIpv4ListOptions);

            return response.ipv4;
        }

        /// <summary>	Gets reserved private addresses. </summary>
        /// <param name="vlanId">The VLAN Id.</param>
        /// <returns>	The reserved private addresses. </returns>
        public async Task<IEnumerable<ReservedPrivateIpv4AddressType>> GetReservedPrivateAddressesForVlan(Guid vlanId)
        {
            return (await GetReservedPrivateAddressesForVlanPaginated(vlanId, null)).items;
        }

        /// <summary>The get reserved private ipv 4 addresses paginated.</summary>
        /// <param name="reservedPrivateIpv4ListOptions">The reserved private ipv 4 list options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PagedResponse<ReservedPrivateIpv4AddressType>> GetReservedPrivateIpv4AddressesPaginated(ReservedPrivateIpv4ListOptions reservedPrivateIpv4ListOptions = null, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<reservedPrivateIpv4Addresses>(
                ApiUris.GetReservedPrivateIpv4Addresses(_apiClient.OrganizationId), 
                pagingOptions, 
                reservedPrivateIpv4ListOptions);

            return new PagedResponse<ReservedPrivateIpv4AddressType>
            {
                items = response.ipv4, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>	Gets reserved private addresses. </summary>
        /// <param name="vlanId">The VLAN Id.</param>
        /// <param name="pagingOptions">	The paging options, null means default. </param>
        /// <returns>	The reserved private addresses. </returns>
        public async Task<PagedResponse<ReservedPrivateIpv4AddressType>> GetReservedPrivateAddressesForVlanPaginated(Guid vlanId, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<reservedPrivateIpv4Addresses>(
                ApiUris.GetReservedPrivateAddresses(_apiClient.OrganizationId, vlanId.ToString()), 
                pagingOptions);

            return new PagedResponse<ReservedPrivateIpv4AddressType>
            {
                items = response.ipv4, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>	Deletes the public IP block. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
        /// <returns>	The job from the API; </returns>
        /// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.DeletePublicIpBlock(string,string)"/>
        public async Task<ResponseType> DeletePublicIpBlock(Guid networkDomainId, Guid publicIpBlockId)
        {
            return
                await
                    _apiClient.PostAsync<RemovePublicIpBlockType, ResponseType>(
                        ApiUris.RemovePublicIpv4AddressBlock(
                            _apiClient.OrganizationId), 
                        new RemovePublicIpBlockType
                        {
                            id = publicIpBlockId.ToString()
                        });
        }


        /// <summary>The reserve private ipv 4 address.</summary>
        /// <param name="reservePrivateIpv4Address">The reserve private ipv 4 address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> ReservePrivateIpv4Address(ReservePrivateIpv4AddressType reservePrivateIpv4Address)
        {
            return await _apiClient.PostAsync<ReservePrivateIpv4AddressType, ResponseType>(ApiUris.ReservePrivateIpv4Address(_apiClient.OrganizationId), reservePrivateIpv4Address);
        }

        /// <summary>The unreserve private ipv 4 address.</summary>
        /// <param name="unReservePrivateIpv4Address">The un reserve private ipv 4 address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> UnreservePrivateIpv4Address(UnreservePrivateIpv4AddressType unReservePrivateIpv4Address)
        {
            return await _apiClient.PostAsync<UnreservePrivateIpv4AddressType, ResponseType>(ApiUris.UnreservePrivateIpv4Address(_apiClient.OrganizationId), unReservePrivateIpv4Address);
        }

        /// <summary>The reserve ipv 6 address.</summary>
        /// <param name="reserveIpv6Address">The reserve ipv 6 address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> ReserveIpv6Address(ReserveIpv6AddressType reserveIpv6Address)
        {
            return await _apiClient.PostAsync<ReserveIpv6AddressType, ResponseType>(ApiUris.ReserveIpv6Address(_apiClient.OrganizationId), reserveIpv6Address);
        }

        /// <summary>The unreserve ipv 6 address.</summary>
        /// <param name="unreserveIpv6Address">The unreserve ipv 6 address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> UnreserveIpv6Address(UnreserveIpv6AddressType unreserveIpv6Address)
        {
            return await _apiClient.PostAsync<UnreserveIpv6AddressType, ResponseType>(ApiUris.UnreserveIpv6Address(_apiClient.OrganizationId), unreserveIpv6Address);
        }

        /// <summary>The get reserved ipv 6 addresses.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IEnumerable<ReservedIpv6AddressType>> GetReservedIpv6Addresses()
        {
            return (await GetReservedIpv6AddressesPaginated()).items;
        }

        /// <summary>The get reserved ipv 6 addresses.</summary>
        /// <param name="vlanId">The vlan id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IEnumerable<ReservedIpv6AddressType>> GetReservedIpv6Addresses(Guid vlanId)
        {
            return (await GetReservedIpv6AddressesPaginated(vlanId)).items;
        }

        /// <summary>The get reserved ipv 6 addresses.</summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IEnumerable<ReservedIpv6AddressType>> GetReservedIpv6Addresses(string ipAddress)
        {
            return (await GetReservedIpv6AddressesPaginated(ipAddress)).items;
        }


        /// <summary>The get reserved ipv 6 addresses paginated.</summary>
        /// <param name="reservedIpv6ListOptions">The reserved ipv 6 list options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PagedResponse<ReservedIpv6AddressType>> GetReservedIpv6AddressesPaginated(ReservedIpv6ListOptions reservedIpv6ListOptions = null, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<reservedIpv6Addresses>(
                ApiUris.GetReservedIpv6Addresses(_apiClient.OrganizationId), 
                pagingOptions, 
                reservedIpv6ListOptions);

            return new PagedResponse<ReservedIpv6AddressType>
            {
                items = response.reservedIpv6Address, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>The get reserved ipv 6 addresses paginated.</summary>
        /// <param name="vlanId">The vlan id.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PagedResponse<ReservedIpv6AddressType>> GetReservedIpv6AddressesPaginated(Guid vlanId, IPageableRequest pagingOptions = null)
        {
            var filterOptions = new ReservedIpv6ListOptions
            {
                VlanId = vlanId
            };
            return await GetReservedIpv6AddressesPaginated(filterOptions, pagingOptions);
        }

        /// <summary>The get reserved ipv 6 addresses paginated.</summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PagedResponse<ReservedIpv6AddressType>> GetReservedIpv6AddressesPaginated(string ipAddress, IPageableRequest pagingOptions = null)
        {
            var filterOptions = new ReservedIpv6ListOptions
            {
                IpAddress = ipAddress
            };
            return await GetReservedIpv6AddressesPaginated(filterOptions, pagingOptions);
        }
    }
}