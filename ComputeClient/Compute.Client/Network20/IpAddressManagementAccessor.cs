using System;

namespace DD.CBU.Compute.Api.Client.Network20
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	
	using Contracts.Network20;
	using Contracts.Requests;

	using DD.CBU.Compute.Api.Client.Interfaces.Network20;

	using Interfaces;

	/// <summary>	An IP address management client. </summary>
	/// <seealso cref="T:DD.CBU.Compute.Api.Client.Interfaces.IIpam"/>
	public class IpAddressManagementAccessor : IIpamAccessor
	{
		/// <summary>	The client. </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// 	Initializes a new instance of the <see cref="IpAddressManagementAccessor"/>.
		/// </summary>
		/// <param name="apiClient">	The client. </param>
		public IpAddressManagementAccessor(IWebApi apiClient)
		{
			this._apiClient = apiClient;
		}

		/// <summary>	Adds a public IP block. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The job from the API; </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.AddPublicIpBlock(string)"/>
		public async Task<ResponseType> AddPublicIpBlock(string networkDomainId)
		{
			return
				await
					_apiClient.PostAsync<AddPublicIpBlockType, ResponseType>(
						ApiUris.AddPublicIpBlock(_apiClient.OrganizationId), 
						new AddPublicIpBlockType
							{
								networkDomainId = networkDomainId
							});
		}

		/// <summary>	Gets public IP blocks. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <param name="paging">		  	The paging options, null means default. </param>
		/// <returns>	The public IP blocks. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.GetPublicIpBlocks(string,IPageableRequest)"/>
		public async Task<IEnumerable<PublicIpBlockType>> GetPublicIpBlocks(string networkDomainId, IPageableRequest paging = null)
		{
			var response =
				await
					_apiClient.GetAsync<publicIpBlocks>(ApiUris.GetPublicIpBlocks(_apiClient.OrganizationId, networkDomainId));
			return response.publicIpBlock;
		}

		/// <summary>	Gets public IP block. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
		/// <returns>	The public IP block. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.GetPublicIpBlock(string,string)"/>
		public async Task<PublicIpBlockType> GetPublicIpBlock(string networkDomainId, string publicIpBlockId)
		{
			return
				await
					_apiClient.GetAsync<PublicIpBlockType>(
						ApiUris.GetPublicIpBlock(_apiClient.OrganizationId, publicIpBlockId));
		}

		/// <summary>	Deletes the public IP block. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
		/// <returns>	The job from the API; </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.DeletePublicIpBlock(string,string)"/>
		public async Task<ResponseType> DeletePublicIpBlock(string networkDomainId, string publicIpBlockId)
		{
			return
				await
					_apiClient.PostAsync<RemovePublicIpBlockType, ResponseType>(
						ApiUris.RemovePublicIpv4AddressBlock(
							_apiClient.OrganizationId), 
							new RemovePublicIpBlockType
							{
								id = publicIpBlockId
							});
		}

		/// <summary>	Gets reserved public IP addresses for a network domain. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The reserved public addresses. </returns>
		public async Task<reservedPublicIpv4Addresses> GetReservedPublicAddresses(string networkDomainId)
		{
			return await
					_apiClient.GetAsync<reservedPublicIpv4Addresses>(
						ApiUris.GetReservedPublicAddresses(_apiClient.OrganizationId, networkDomainId));
		}

		/// <summary>	Gets reserved public addresses for an MCP 1.0 network. </summary>
		/// <param name="networkId">	Identifier for the network. </param>
		/// <returns>	The reserved public addresses for network. </returns>
		public async Task<reservedPublicIpv4Addresses> GetReservedPublicAddressesForNetwork(string networkId)
		{
			return await
					_apiClient.GetAsync<reservedPublicIpv4Addresses>(
						ApiUris.GetReservedPublicAddressesForNetwork(_apiClient.OrganizationId, networkId));
		}

        /// <summary>	Gets reserved private addresses. </summary>
        /// <param name="vlanId">The VLAN Id.</param>
        /// <returns>	The reserved private addresses. </returns>
        public async Task<reservedPrivateIpv4Addresses> GetReservedPrivateAddresses(Guid vlanId)
		{
			return await
					_apiClient.GetAsync<reservedPrivateIpv4Addresses>(
						ApiUris.GetReservedPrivateAddresses(_apiClient.OrganizationId, vlanId.ToString()));
		}
	}
}
