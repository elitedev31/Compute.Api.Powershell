namespace DD.CBU.Compute.Api.Client.Interfaces.Server20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Server20;

    /// <summary>
    /// The AntiAffinityRuleAccessor interface.
    /// </summary>
    public interface IAntiAffinityRuleAccessor
    {
        /// <summary>
        /// Gets the available anti affinity rules for a specific server.
        /// </summary>
        /// <param name="serverId">
        /// The server id.
        /// </param>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <returns>
        /// Collection of <see cref="AntiAffinityRuleType"/>.
        /// </returns>
        Task<IEnumerable<AntiAffinityRuleType>> GetAntiAffinityRulesForServer(Guid serverId, AntiAffinityRuleListOptions filteringOptions = null);

        /// <summary>
        /// Gets the available anti affinity rules for a specific server.
        /// </summary>
        /// <param name="serverId">
        /// The server id.
        /// </param>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// Collection of <see cref="AntiAffinityRuleType"/>.
        /// </returns>
        Task<PagedResponse<AntiAffinityRuleType>> GetAntiAffinityRulesForServerPaginated(Guid serverId, AntiAffinityRuleListOptions filteringOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>
        /// Gets the available anti affinity rules for a specific network.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <returns>
        /// Collection of <see cref="AntiAffinityRuleType"/>.
        /// </returns>
        Task<IEnumerable<AntiAffinityRuleType>> GetAntiAffinityRulesForNetwork(Guid networkId, AntiAffinityRuleListOptions filteringOptions = null);

        /// <summary>
        /// Gets the available anti affinity rules for a specific network.
        /// </summary>
        /// <param name="networkId">
        /// The network id.
        /// </param>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// Collection of <see cref="AntiAffinityRuleType"/>.
        /// </returns>
        Task<PagedResponse<AntiAffinityRuleType>> GetAntiAffinityRulesForNetworkPaginated(Guid networkId, AntiAffinityRuleListOptions filteringOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>
        /// Gets the available anti affinity rules for a specific network domain.
        /// </summary>
        /// <param name="networkDomainId">
        /// The network domain id.
        /// </param>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <returns>
        /// Collection of <see cref="AntiAffinityRuleType"/>.
        /// </returns>
        Task<IEnumerable<AntiAffinityRuleType>> GetAntiAffinityRulesForNetworkDomain(Guid networkDomainId, AntiAffinityRuleListOptions filteringOptions = null);

        /// <summary>
        /// Gets the available anti affinity rules for a specific network domain.
        /// </summary>
        /// <param name="networkDomainId">
        /// The network domain id.
        /// </param>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// Collection of <see cref="AntiAffinityRuleType"/>.
        /// </returns>
        Task<PagedResponse<AntiAffinityRuleType>> GetAntiAffinityRulesForNetworkDomainPaginated(Guid networkDomainId, AntiAffinityRuleListOptions filteringOptions = null, IPageableRequest pagingOptions = null);
    }
}
