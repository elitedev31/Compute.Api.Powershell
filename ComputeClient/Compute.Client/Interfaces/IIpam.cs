namespace DD.CBU.Compute.Api.Client.Interfaces
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Contracts.Network20;
	using Contracts.Requests;

	/// <summary>	IP Address Management functions. </summary>
	public interface IIpam
	{
		/// <summary>	Adds a public IP block. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The job from the API; </returns>
		Task<ResponseType> AddPublicIpBlock(string networkDomainId);

		/// <summary>	Gets public IP blocks. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <param name="paging">		  	The paging options, null means default. </param>
		/// <returns>	The public IP blocks. </returns>
		Task<IEnumerable<PublicIpBlockType>> GetPublicIpBlocks(string networkDomainId, IPageableRequest paging = null);

		/// <summary>	Gets public IP block. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
		/// <returns>	The public IP block. </returns>
		Task<PublicIpBlockType> GetPublicIpBlock(string networkDomainId, string publicIpBlockId);

		/// <summary>	Deletes the public IP block. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <param name="publicIpBlockId">	Identifier for the public IP block. </param>
		/// <returns>	The job from the API; </returns>
		Task<ResponseType> DeletePublicIpBlock(string networkDomainId, string publicIpBlockId);

		/// <summary>	Gets reserved public addresses. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The reserved public addresses. </returns>
		Task<reservedPublicIpv4Addresses> GetReservedPublicAddresses(string networkDomainId);

		/// <summary>	Gets reserved public addresses for network. </summary>
		/// <param name="networkId">	Identifier for the network. </param>
		/// <returns>	The reserved public addresses for network. </returns>
		Task<reservedPublicIpv4Addresses> GetReservedPublicAddressesForNetwork(string networkId);

		/// <summary>	Gets reserved private addresses. </summary>
		/// <param name="networkDomainId">	Identifier for the network domain. </param>
		/// <returns>	The reserved private addresses. </returns>
		Task<reservedPrivateIpv4Addresses> GetReservedPrivateAddresses(string networkDomainId);
	}
}
