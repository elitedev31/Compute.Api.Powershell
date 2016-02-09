namespace DD.CBU.Compute.Api.Client.Server20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Interfaces.Server20;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Server20;

    /// <summary>
    /// The server 2.0 accessor.
    /// </summary>
    public class AntiAffinityRuleAccessor : IAntiAffinityRuleAccessor
    {
        /// <summary>
        /// The _api client.
        /// </summary>
        private readonly IWebApi _apiClient;

        /// <summary>
        /// Initialises a new instance of the <see cref="AntiAffinityRuleAccessor"/> class.
        /// </summary>
        /// <param name="apiClient">
        /// The api client.
        /// </param>
        public AntiAffinityRuleAccessor(IWebApi apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Gets the available anti affinity rules.
        /// </summary>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// Collection of <see cref="AntiAffinityRuleType"/>.
        /// </returns>
        public async Task<PagedResponse<AntiAffinityRuleType>> GetAntiAffinityRulesForServerPaginated(AntiAffinityRuleListOptions filteringOptions, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<antiAffinityRules>(
                ApiUris.GetMcp2GetAntiAffinityRules(_apiClient.OrganizationId),
                pagingOptions,
                filteringOptions);

            return new PagedResponse<AntiAffinityRuleType>
            {
                items = response.antiAffinityRule,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

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
        public async Task<IEnumerable<AntiAffinityRuleType>> GetAntiAffinityRulesForServer(Guid serverId, AntiAffinityRuleListOptions filteringOptions = null)
        {
            var response = await GetAntiAffinityRulesForServerPaginated(serverId, filteringOptions, null);
            return response.items;
        }

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
        public async Task<PagedResponse<AntiAffinityRuleType>> GetAntiAffinityRulesForServerPaginated(Guid serverId, AntiAffinityRuleListOptions filteringOptions = null, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<antiAffinityRules>(
                ApiUris.GetMcp2GetAntiAffinityRulesForServer(_apiClient.OrganizationId, serverId),
                pagingOptions,
                filteringOptions);

            return new PagedResponse<AntiAffinityRuleType>
            {
                items = response.antiAffinityRule,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

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
        public async Task<IEnumerable<AntiAffinityRuleType>> GetAntiAffinityRulesForNetwork(Guid networkId, AntiAffinityRuleListOptions filteringOptions = null)
        {
            var response = await GetAntiAffinityRulesForNetworkPaginated(networkId, filteringOptions, null);
            return response.items;
        }

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
        public async Task<PagedResponse<AntiAffinityRuleType>> GetAntiAffinityRulesForNetworkPaginated(Guid networkId, AntiAffinityRuleListOptions filteringOptions = null, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<antiAffinityRules>(
                ApiUris.GetMcp2GetAntiAffinityRulesForNetwork(_apiClient.OrganizationId, networkId),
                pagingOptions,
                filteringOptions);

            return new PagedResponse<AntiAffinityRuleType>
            {
                items = response.antiAffinityRule,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

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
        public async Task<IEnumerable<AntiAffinityRuleType>> GetAntiAffinityRulesForNetworkDomain(Guid networkDomainId, AntiAffinityRuleListOptions filteringOptions = null)
        {
            var response = await GetAntiAffinityRulesForNetworkDomainPaginated(networkDomainId, filteringOptions, null);
            return response.items;
        }

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
        public async Task<PagedResponse<AntiAffinityRuleType>> GetAntiAffinityRulesForNetworkDomainPaginated(Guid networkDomainId, AntiAffinityRuleListOptions filteringOptions = null, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<antiAffinityRules>(
                ApiUris.GetMcp2GetAntiAffinityRulesForNetworkDomain(_apiClient.OrganizationId, networkDomainId),
                pagingOptions,
                filteringOptions);

            return new PagedResponse<AntiAffinityRuleType>
            {
                items = response.antiAffinityRule,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }
    }
}
