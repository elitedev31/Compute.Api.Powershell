namespace DD.CBU.Compute.Api.Client.Network20
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	
	using Contracts.Network20;
	using Contracts.Requests;
	using Interfaces;

	/// <summary>	An IP address management client. </summary>
	/// <seealso cref="T:DD.CBU.Compute.Api.Client.Interfaces.IIpam"/>
	public class IpAddressManagement : IIpam
	{
		/// <summary>	The client. </summary>
		private IComputeApiClient client;

		/// <summary>
		/// 	Initializes a new instance of the <see cref="IpAddressManagement"/>.
		/// </summary>
		/// <param name="client">	The client. </param>
		public IpAddressManagement(IComputeApiClient client)
		{
			this.client = client;
		}

		/// <summary>	Adds a public IP block. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The job from the API; </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.IIpam.AddPublicIpBlock(string)"/>
		public async Task<ResponseType> AddPublicIpBlock(string networkDomainId)
		{
			return
				await
					client.WebApi.ApiPostAsync<AddPublicIpBlockType, ResponseType>(
						ApiUris.AddPublicIpBlock(client.Account.OrganizationId), 
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
					client.WebApi.ApiGetAsync<publicIpBlocks>(ApiUris.GetPublicIpBlocks(client.Account.OrganizationId));
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
					client.WebApi.ApiGetAsync<PublicIpBlockType>(
						ApiUris.GetPublicIpBlock(client.Account.OrganizationId, publicIpBlockId));
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
					client.WebApi.ApiPostAsync<RemovePublicIpBlockType, ResponseType>(
						ApiUris.AddPublicIpBlock(
							client.Account.OrganizationId), 
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
					client.WebApi.ApiGetAsync<reservedPublicIpv4Addresses>(
						ApiUris.GetReservedPublicAddresses(client.Account.OrganizationId, networkDomainId));
		}

		/// <summary>	Gets reserved public addresses for an MCP 1.0 network. </summary>
		/// <param name="networkId">	Identifier for the network. </param>
		/// <returns>	The reserved public addresses for network. </returns>
		public async Task<reservedPublicIpv4Addresses> GetReservedPublicAddressesForNetwork(string networkId)
		{
			return await
					client.WebApi.ApiGetAsync<reservedPublicIpv4Addresses>(
						ApiUris.GetReservedPublicAddressesForNetwork(client.Account.OrganizationId, networkId));
		}

		/// <summary>	Gets reserved private addresses. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The reserved private addresses. </returns>
		public async Task<reservedPrivateIpv4Addresses> GetReservedPrivateAddresses(string networkDomainId)
		{
			return await
					client.WebApi.ApiGetAsync<reservedPrivateIpv4Addresses>(
						ApiUris.GetReservedPrivateAddresses(client.Account.OrganizationId, networkDomainId));
		}
	}
}
