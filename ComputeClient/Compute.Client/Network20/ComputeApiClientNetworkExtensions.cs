using DD.CBU.Compute.Api.Contracts.Network20;

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
        /// <summary> Retrieves the list of ACL rules associated with a network. This API requires your
        /// 	organization ID and the ID of the target network. </summary>
        /// <remarks>	Anthony, 4/24/2015. </remarks>
        /// <param name="client">	The <see cref="ComputeApiClient"/> object. </param>
        /// <returns>	The VLAN collection. </returns>
        public static async Task<IEnumerable<VlanType>> GetVlans(this IComputeApiClient client)
        {
            var vlans =
                await
                client.WebApi.ApiGetAsync<vlans>(
                    ApiUris.GetVlanByOrgId(client.Account.OrganizationId));

            return vlans.vlan;
        }

        /// <summary>	The get VLAN list. </summary>
        /// <remarks>	Anthony, 4/24/2015. </remarks>
        /// <param name="client">		  	The client. </param>
        /// <param name="id">			  	The id. </param>
        /// <param name="vlanName">		  	The VLAN name. </param>
        /// <param name="networkDomainId">	The network domain id. </param>
        /// <returns>	The <see cref="Task"/>. </returns>
        public static async Task<IEnumerable<VlanType>> GetVlans(this IComputeApiClient client, Guid id, string vlanName, Guid networkDomainId)
        {
            var vlans =
                await
                client.WebApi.ApiGetAsync<vlans>(
                    ApiUris.GetVlan(client.Account.OrganizationId, id, vlanName, networkDomainId));

            return vlans.vlan;
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

        /// <summary>
        /// This function gets list of network domains from Cloud
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <returns>
        /// The list of network domains associated with the organization.
        /// </returns>
		public static async Task<IEnumerable<NetworkDomainType>> GetNetworkDomains(this IComputeApiClient client)
        {
            var networks = await client.WebApi.ApiGetAsync<networkDomains>(ApiUris.NetworkDomains(client.Account.OrganizationId));
            return networks.networkDomain;
        }

        /// <summary>
        /// This function gets list of network domains from Cloud
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <param name="networkDomainId">
        /// Network domain id
        /// </param>
        /// <param name="networkName">
        /// The network Name.
        /// </param>
        /// <returns>
        /// The list of network domains associated with the organization.
        /// </returns>
		public static async Task<IEnumerable<NetworkDomainType>> GetNetworkDomain(this IComputeApiClient client, Guid networkDomainId, string networkName)
        {
            var networks = await client.WebApi.ApiGetAsync<networkDomains>(ApiUris.NetworkDomain(client.Account.OrganizationId, networkDomainId, networkName));
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
