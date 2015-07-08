using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network;

namespace DD.CBU.Compute.Api.Client.Network20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Interfaces;

    /// <summary>
    /// Extension methods for the Network section of the CaaS API.
    /// </summary>
    public static class ComputeApiClientNetworkExtensions
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

	    /// <summary>	An IComputeApiClient extension method that gets a vlan. </summary>
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

		/// <summary>	This function gets list of network domains from Cloud. </summary>
		/// <param name="client">			The client. </param>
		/// <param name="pagingOptions">	Options for controlling the paging. </param>
		/// <returns>	The list of network domains associated with the organization. </returns>
		public static async Task<IEnumerable<NetworkDomainType>> GetNetworkDomains(this IComputeApiClient client, PageableRequest pagingOptions = null)
        {
            var networks = await client.WebApi.ApiGetAsync<networkDomains>(ApiUris.NetworkDomains(client.Account.OrganizationId), pagingOptions);
            return networks.networkDomain;
        }

		/// <summary>	This function gets list of network domains from Cloud. </summary>
		/// <param name="client">		  	The client. </param>
		/// <param name="networkDomainId">	Network domain id. </param>
		/// <param name="networkName">	  	The network Name. </param>
		/// <param name="pagingOptions">  	Options for controlling the paging. </param>
		/// <returns>	The list of network domains associated with the organization. </returns>
		public static async Task<IEnumerable<NetworkDomainType>> GetNetworkDomain(this IComputeApiClient client, Guid networkDomainId, string networkName, PageableRequest pagingOptions = null)
        {
            var networks = await client.WebApi.ApiGetAsync<networkDomains>(ApiUris.NetworkDomain(client.Account.OrganizationId, networkDomainId, networkName), pagingOptions);
            return networks.networkDomain;
        }

        /// <summary>
        /// This function deploys a new network domains to Cloud
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <param name="networkDomain">
        /// The network Domain.
        /// </param>
        /// <returns>
        /// Response containing status.
        /// </returns>
		public static async Task<ResponseType> DeployNetworkDomain(this IComputeApiClient client, DeployNetworkDomainType networkDomain)
        {
			var response = await client.WebApi.ApiPostAsync<DeployNetworkDomainType, ResponseType>(ApiUris.CreateNetworkDomain(client.Account.OrganizationId), networkDomain);
            return response;
        }

        /// <summary>
        /// This function deploys a new network domains to Cloud
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <param name="server">
        /// The network Domain.
        /// </param>
        /// <returns>
        /// Response containing status.
        /// </returns>
		public static async Task<ResponseType> DeployServerOnNetworkDomain(this IComputeApiClient client, DeployServerType server)
        {
			var response = await client.WebApi.ApiPostAsync<DeployServerType, ResponseType>(ApiUris.DeployServerOnNetworkDomain(client.Account.OrganizationId), server);
            return response;
        }

	    /// <summary>
	    /// 	An IComputeApiClient extension method that adds a NIC to server to 'addNic'.
	    /// </summary>
	    /// <remarks>	Anthony, 4/24/2015. </remarks>
	    /// <param name="client">	The compute client. </param>
	    /// <param name="addNic">	The add NIC. </param>
	    /// <returns>	A standard response. </returns>
	    public static async Task<ResponseType> AddNicToServer(this IComputeApiClient client, AddNicType addNic)
	    {
		    return 
			    await client.WebApi.ApiPostAsync<AddNicType, ResponseType>(ApiUris.AddNic(client.Account.OrganizationId), addNic);
	    }
    }
}
