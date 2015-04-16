namespace DD.CBU.Compute.Api.Client.Network20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Contracts;

    /// <summary>
    /// Extension methods for the Network section of the CaaS API.
    /// </summary>
    public static class ComputeApiClientNetworkExtensions
    {
        /// <summary>
        /// Retrieves the list of ACL rules associated with a network.
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="client">
        /// The <see cref="ComputeApiClient"/> object
        /// </param>
        /// <returns>
        /// The Vlans.
        /// </returns>
        public static async Task<IEnumerable<VlanType>> GetVlans(this IComputeApiClient client)
        {
            var vlans =
                await
                client.Mcp2WebApi.ApiGetAsync<vlans>(
                    ApiUris.GetVlan(client.Account.OrganizationId));

            return vlans.vlan;
        }


        /// <summary>
        /// Deploys Virtual Lan on a network domain
        /// </summary>
        /// <param name="client"> The compute client</param>
        /// <param name="vlan">Virtual Lan</param>
        /// <returns>Operation status</returns>
        public static async Task<Response> DeployVlan(this IComputeApiClient client, DeployVlanType vlan)
        {
            var response =
                await
                client.Mcp2WebApi.ApiPostAsync<DeployVlanType, Response>(
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
        public static async Task<IEnumerable<NetworkDomain>> GetNetworkDomains(this IComputeApiClient client)
        {
            var networks = await client.Mcp2WebApi.ApiGetAsync<networkDomains>(ApiUris.NetworkDomains(client.Account.OrganizationId));
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
        /// <returns>
        /// The list of network domains associated with the organization.
        /// </returns>
        public static async Task<IEnumerable<NetworkDomain>> GetNetworkDomain(this IComputeApiClient client, Guid networkDomainId)
        {
            var networks = await client.Mcp2WebApi.ApiGetAsync<networkDomains>(ApiUris.NetworkDomain(client.Account.OrganizationId, networkDomainId));
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
        /// The list of network domains associated with the organization.
        /// </returns>
        public static async Task<Response> DeployNetworkDomain(this IComputeApiClient client, DeployNetworkDomain networkDomain)
        {
            var response = await client.Mcp2WebApi.ApiPostAsync<DeployNetworkDomain, Response>(ApiUris.CreateNetworkDomain(client.Account.OrganizationId), networkDomain);
            return response;
        }
    }
}
