namespace DD.CBU.Compute.Api.Client.Network20
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Contracts;
    using DD.CBU.Compute.Api.Contracts.Directory;
    using DD.CBU.Compute.Api.Contracts.Network;

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
            var networks = await client.Mcp2WebApi.ApiGetAsync<NetworkDomains>(ApiUris.NetworkDomains(client.Account.OrganizationId));
            return networks.NetworkDomain;
        }
    }
}
