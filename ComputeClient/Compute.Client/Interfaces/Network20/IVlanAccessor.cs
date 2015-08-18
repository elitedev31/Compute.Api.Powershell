namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.Network20;
	using DD.CBU.Compute.Api.Contracts.Requests;
	using DD.CBU.Compute.Api.Contracts.Requests.Network20;

	/// <summary>
	/// The VlanAccessor interface.
	/// </summary>
	public interface IVlanAccessor
	{
		/// <summary>
		/// 	Retrieves the list of ACL rules associated with a network. This API requires your
		/// 	organization ID and the ID of the target network.
		/// </summary>		
		/// <param name="options">
		/// 			Options for controlling the operation. 
		/// </param>
		/// <param name="pagingOptions">
		/// 	Options for controlling the paging. 
		/// </param>
		/// <returns>
		/// 	The VLAN collection. 
		/// </returns>
		Task<IEnumerable<VlanType>> GetVlans(VlanListOptions options = null, PageableRequest pagingOptions = null);

		/// <summary>
		/// 	The get VLAN list. 
		/// </summary>		
		/// <param name="id">
		/// 			  	The id. 
		/// </param>
		/// <param name="vlanName">
		/// 		  	The VLAN name. 
		/// </param>
		/// <param name="networkDomainId">
		/// 	The network domain id. 
		/// </param>
		/// <param name="pagingOptions">
		/// The paging Options.
		/// </param>
		/// <returns>
		/// 	The <see cref="Task"/>. 
		/// </returns>
		Task<IEnumerable<VlanType>> GetVlans(Guid id, string vlanName, Guid networkDomainId, PageableRequest pagingOptions = null);

		/// <summary>
		/// 	An IComputeApiClient extension method that gets a VLAN. 
		/// </summary>
		/// <param name="vlanId">
		/// 	The id. 
		/// </param>
		/// <returns>
		/// 	The vlan. 
		/// </returns>
		Task<VlanType> GetVlan(Guid vlanId);

		/// <summary>
		/// Deploys Virtual LAN on a network domain
		/// </summary>
		/// <param name="vlan">
		/// Virtual LAN
		/// </param>
		/// <returns>
		/// Operation status
		/// </returns>
		Task<ResponseType> DeployVlan(DeployVlanType vlan);

		/// <summary>
		/// 	An IComputeApiClient extension method that deletes the vlan. 
		/// </summary>
		/// <param name="id">
		/// 	 	The id of the VLAN. 
		/// </param>
		/// <returns>
		/// 	The job from the API; 
		/// </returns>
		Task<ResponseType> DeleteVlan(string id);
	}
}
