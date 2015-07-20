using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network;

namespace DD.CBU.Compute.Api.Client.Network20
{
	/// <summary>	Access methods for VLAN Operations </summary>
	/// <seealso cref="T:DD.CBU.Compute.Api.Client.Interfaces.IVlan"/>
	public class Vlan : IVlan
	{
		private IComputeApiClient _client;

		public Vlan(IComputeApiClient client)
		{
			_client = client;
		}

		/// <summary>
		/// 	Retrieves the list of ACL rules associated with a network. This API requires your
		/// 	organization ID and the ID of the target network.
		/// </summary>
		/// <remarks>	Anthony, 4/24/2015. </remarks>
		/// <param name="client">			The <see cref="ComputeApiClient"/> object. </param>
		/// <param name="options">			Options for controlling the operation. </param>
		/// <param name="pagingOptions">	Options for controlling the paging. </param>
		/// <returns>	The VLAN collection. </returns>
		public async Task<IEnumerable<VlanType>> GetVlans(VlanListOptions options = null, PageableRequest pagingOptions = null)
		{
			var vlans =
				await
				_client.WebApi.ApiGetAsync<vlans>(
					ApiUris.GetVlanByOrgId(_client.Account.OrganizationId), pagingOptions);

			return vlans.vlan;
		}

		/// <summary>	The get VLAN list. </summary>
		/// <remarks>	Anthony, 4/24/2015. </remarks>
		/// <param name="client">		  	The client. </param>
		/// <param name="id">			  	The id. </param>
		/// <param name="vlanName">		  	The VLAN name. </param>
		/// <param name="networkDomainId">	The network domain id. </param>
		/// <returns>	The <see cref="Task"/>. </returns>
		public async Task<IEnumerable<VlanType>> GetVlans(Guid id, string vlanName, Guid networkDomainId, PageableRequest pagingOptions = null)
		{
			var vlans =
				await
				_client.WebApi.ApiGetAsync<vlans>(
					ApiUris.GetVlan(_client.Account.OrganizationId, id, vlanName, networkDomainId), pagingOptions);

			return vlans.vlan;
		}

		/// <summary>	An IComputeApiClient extension method that gets a VLAN. </summary>
		/// <param name="client">	The <see cref="ComputeApiClient"/> object. </param>
		/// <param name="vlanId">	The id. </param>
		/// <returns>	The vlan. </returns>
		public async Task<VlanType> GetVlan(Guid vlanId)
		{
			return await _client.WebApi.ApiGetAsync<VlanType>(
				ApiUris.GetVlan(_client.Account.OrganizationId, vlanId));
		}

		/// <summary>
		/// Deploys Virtual LAN on a network domain
		/// </summary>
		/// <param name="client"> The compute client</param>
		/// <param name="vlan">Virtual LAN</param>
		/// <returns>Operation status</returns>
		public async Task<ResponseType> DeployVlan(DeployVlanType vlan)
		{
			return
				await
				_client.WebApi.ApiPostAsync<DeployVlanType, ResponseType>(
					ApiUris.DeployVlan(_client.Account.OrganizationId),
					vlan);
		}

		/// <summary>	An IComputeApiClient extension method that deletes the vlan. </summary>
		/// <param name="client">	The compute client. </param>
		/// <param name="id">	 	The id of the VLAN. </param>
		/// <returns>	The job from the API; </returns>
		public async Task<ResponseType> DeleteVlan(string id)
		{
			return 
				await
					_client.WebApi.ApiPostAsync<DeleteVlanType, ResponseType>(
						ApiUris.DeleteVlan(_client.Account.OrganizationId),
						new DeleteVlanType { id = id });
		}
	}
}
