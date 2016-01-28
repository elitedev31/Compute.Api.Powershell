using System;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Api.Client.Network20
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces.Network20;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Network20;
	using DD.CBU.Compute.Api.Contracts.Requests;

	using Interfaces;

	/// <summary>	An IP address management client. </summary>
	/// <seealso cref="T:DD.CBU.Compute.Api.Client.Interfaces.IIpam"/>
	public class IpAddressAccessor : IIpAddressAccessor
	{
		/// <summary>	The client. </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// 	Initializes a new instance of the <see cref="IpAddressAccessor"/>.
		/// </summary>
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
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
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
			return await GetReservedPublicAddressesForNetworkDomainPaginated(networkDomainId, null);
        }

        /// <summary>	Gets reserved public IP addresses for a network domain. </summary>
        /// <param name="networkDomainId">	Identifier for the network domain. </param>
        /// <param name="pagingOptions">	The paging options, null means default. </param>
        /// <returns>	The reserved public addresses. </returns>
        public async Task<IEnumerable<ReservedPublicIpv4AddressType>> GetReservedPublicAddressesForNetworkDomainPaginated(Guid networkDomainId, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<reservedPublicIpv4Addresses>(
                ApiUris.GetReservedPublicAddresses(_apiClient.OrganizationId,
                networkDomainId.ToString()),
                pagingOptions);

            return response.ip;
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

        /// <summary>	Gets reserved private addresses. </summary>
        /// <param name="vlanId">The VLAN Id.</param>
        /// <returns>	The reserved private addresses. </returns>
        public async Task<IEnumerable<ReservedPrivateIpv4AddressType>> GetReservedPrivateAddressesForVlan(Guid vlanId)
		{
            return await GetReservedPrivateAddressesForVlanPaginated(vlanId, null);
        }

        /// <summary>	Gets reserved private addresses. </summary>
        /// <param name="vlanId">The VLAN Id.</param>
        /// <param name="pagingOptions">	The paging options, null means default. </param>
        /// <returns>	The reserved private addresses. </returns>
        public async Task<IEnumerable<ReservedPrivateIpv4AddressType>> GetReservedPrivateAddressesForVlanPaginated(Guid vlanId, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<reservedPrivateIpv4Addresses>(
                ApiUris.GetReservedPrivateAddresses(_apiClient.OrganizationId, vlanId.ToString()),
                pagingOptions);

            return response.ipv4;
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
    }
}
