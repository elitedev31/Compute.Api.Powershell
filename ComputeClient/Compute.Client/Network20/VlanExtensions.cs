using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network;

namespace DD.CBU.Compute.Api.Client.Network20
{
	public static class VlanExtensions
	{
		/// <summary>
		/// 	Retrieves the list of ACL rules associated with a network. This API requires your
		/// 	organization ID and the ID of the target network.
		/// </summary>
		/// <remarks>	Anthony, 4/24/2015. </remarks>
		/// <param name="client">			The <see cref="ComputeApiClient"/> object. </param>
		/// <param name="options">			Options for controlling the operation. </param>
		/// <param name="pagingOptions">	Options for controlling the paging. </param>
		/// <returns>	The VLAN collection. </returns>
		public static async Task<IEnumerable<VlanType>> GetVlans(this IComputeApiClient client, VlanListOptions options = null, PageableRequest pagingOptions = null)
		{
			var vlans =
				await
				client.WebApi.ApiGetAsync<vlans>(
					ApiUris.GetVlanByOrgId(client.Account.OrganizationId), pagingOptions);

			return vlans.vlan;
		}

		/// <summary>	The get VLAN list. </summary>
		/// <remarks>	Anthony, 4/24/2015. </remarks>
		/// <param name="client">		  	The client. </param>
		/// <param name="id">			  	The id. </param>
		/// <param name="vlanName">		  	The VLAN name. </param>
		/// <param name="networkDomainId">	The network domain id. </param>
		/// <returns>	The <see cref="Task"/>. </returns>
		public static async Task<IEnumerable<VlanType>> GetVlans(this IComputeApiClient client, Guid id, string vlanName, Guid networkDomainId, PageableRequest pagingOptions = null)
		{
			var vlans =
				await
				client.WebApi.ApiGetAsync<vlans>(
					ApiUris.GetVlan(client.Account.OrganizationId, id, vlanName, networkDomainId), pagingOptions);

			return vlans.vlan;
		}

		/// <summary>	An IComputeApiClient extension method that gets a VLAN. </summary>
		/// <param name="client">	The <see cref="ComputeApiClient"/> object. </param>
		/// <param name="vlanId">	The id. </param>
		/// <returns>	The vlan. </returns>
		public static async Task<VlanType> GetVlan(this IComputeApiClient client, Guid vlanId)
		{
			return await client.WebApi.ApiGetAsync<VlanType>(
				ApiUris.GetVlan(client.Account.OrganizationId, vlanId));
		}

		/// <summary>
		/// Deploys Virtual LAN on a network domain
		/// </summary>
		/// <param name="client"> The compute client</param>
		/// <param name="vlan">Virtual LAN</param>
		/// <returns>Operation status</returns>
		public static async Task<ResponseType> DeployVlan(this IComputeApiClient client, DeployVlanType vlan)
		{
			var response =
				await
				client.WebApi.ApiPostAsync<DeployVlanType, ResponseType>(
					ApiUris.DeployVlan(client.Account.OrganizationId),
					vlan);

			return response;
		}

		/// <summary>	An IComputeApiClient extension method that deletes the vlan. </summary>
		/// <param name="client">	The compute client. </param>
		/// <param name="id">	 	The id of the VLAN. </param>
		/// <returns>	The job from the API; </returns>
		public static async Task<ResponseType> DeleteVlan(this IComputeApiClient client, string id)
		{
			ResponseType response =
				await
					client.WebApi.ApiPostAsync<DeleteVlanType, ResponseType>(
						ApiUris.DeleteVlan(client.Account.OrganizationId),
						new DeleteVlanType { id = id });
			return response;
		}
	}
}
