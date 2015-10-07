using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.Interfaces.Network20;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Api.Client.Network20
{
    /// <summary>
    /// The VIP Management type.
    /// </summary>
    public class VipAccessor : IVipAccessor
    {
        /// <summary>
        /// The Web Api.
        /// </summary>
        private readonly IWebApi _api;

        /// <summary>
        /// Initializes a new instance of <see cref="VipAccessor"/>
        /// </summary>
        /// <param name="api">The Web Api</param>
        public VipAccessor(IWebApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Retrieves default health monitors.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="DefaultHealthMonitorType"/></returns>
        public async Task<IEnumerable<DefaultHealthMonitorType>> GetDefaultHealthMonitors(Guid networkDomainId, DefaultHealthMonitorListOptions options = null)
        {
            var response = await GetDefaultHealthMonitorsPaginated(networkDomainId, options, null);
            return response.items;
        }

        /// <summary>
        /// Retrieves default health monitors.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions">The paging options</param>
        /// <returns>The async task of <see cref="PagedResponse{DefaultHealthMonitorType}"/></returns>
        public async Task<PagedResponse<DefaultHealthMonitorType>> GetDefaultHealthMonitorsPaginated(Guid networkDomainId, DefaultHealthMonitorListOptions options = null, PageableRequest pagingOptions = null)
        {
            var response = await _api.GetAsync<defaultHealthMonitors>( ApiUris.GetDefaultHealthMonitors(_api.OrganizationId, networkDomainId), pagingOptions, options);
            return new PagedResponse<DefaultHealthMonitorType>
            {
                items = response.defaultHealthMonitor,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Retrieves default persistence profiles.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="DefaultPersistenceProfileType"/></returns>
        public async Task<IEnumerable<DefaultPersistenceProfileType>> GetDefaultPersistenceProfiles(Guid networkDomainId, DefaultPersistenceProfileListOptions options = null)
        {
            var response = await GetDefaultPersistenceProfilesPaginated(networkDomainId, options, null);
            return response.items;
        }

        /// <summary>
        /// Retrieves default persistence profiles.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions">The paging options</param>
        /// <returns>The async task of <see cref="PagedResponse{DefaultPersistenceProfileType}"/></returns>
        public async Task<PagedResponse<DefaultPersistenceProfileType>> GetDefaultPersistenceProfilesPaginated(Guid networkDomainId, DefaultPersistenceProfileListOptions options = null, PageableRequest pagingOptions = null)
        {
            var response = await _api.GetAsync<defaultPersistenceProfiles>(ApiUris.GetDefaultPersistenceProfile(_api.OrganizationId, networkDomainId), pagingOptions, options);
            return new PagedResponse<DefaultPersistenceProfileType>
            {
                items = response.defaultPersistenceProfile,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Retrieves default iRules.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="DefaultIruleType"/></returns>
        public async Task<IEnumerable<DefaultIruleType>> GetDefaultIrules(Guid networkDomainId, DefaultIruleListOptions options = null)
        {
            var response = await GetDefaultIrulesPaginated(networkDomainId, options, null);
            return response.items;
        }

        /// <summary>
        /// Retrieves default iRules.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions">The paging options</param>
        /// <returns>The async task of <see cref="PagedResponse{DefaultIruleType}"/></returns>
        public async Task<PagedResponse<DefaultIruleType>> GetDefaultIrulesPaginated(Guid networkDomainId, DefaultIruleListOptions options = null, PageableRequest pagingOptions = null)
        {
            var response = await _api.GetAsync<defaultIrules>(ApiUris.GetDefaultIrule(_api.OrganizationId, networkDomainId), pagingOptions, options);
            return new PagedResponse<DefaultIruleType>
            {
                items = response.defaultIrule,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }
    }
}