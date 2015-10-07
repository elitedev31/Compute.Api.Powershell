using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
    /// <summary>
    /// The VIP support interface.
    /// </summary>
    public interface IVipSupportAccessor
    {
        /// <summary>
        /// Retrieves default health monitors.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="DefaultHealthMonitorType"/></returns>
        Task<IEnumerable<DefaultHealthMonitorType>> GetDefaultHealthMonitors(Guid networkDomainId, DefaultHealthMonitorListOptions options = null);

        /// <summary>
        /// Retrieves default health monitors.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions">The paging options</param>
        /// <returns>The async task of <see cref="PagedResponse{DefaultHealthMonitorType}"/></returns>
        Task<PagedResponse<DefaultHealthMonitorType>> GetDefaultHealthMonitorsPaginated(Guid networkDomainId, DefaultHealthMonitorListOptions options = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// Retrieves default persistence profiles.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="DefaultPersistenceProfileType"/></returns>
        Task<IEnumerable<DefaultPersistenceProfileType>> GetDefaultPersistenceProfiles(Guid networkDomainId, DefaultPersistenceProfileListOptions options = null);

        /// <summary>
        /// Retrieves default persistence profiles.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions">The paging options</param>
        /// <returns>The async task of <see cref="PagedResponse{DefaultPersistenceProfileType}"/></returns>
        Task<PagedResponse<DefaultPersistenceProfileType>> GetDefaultPersistenceProfilesPaginated(Guid networkDomainId, DefaultPersistenceProfileListOptions options = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// Retrieves default iRules.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="DefaultIruleType"/></returns>
        Task<IEnumerable<DefaultIruleType>> GetDefaultIrules(Guid networkDomainId, DefaultIruleListOptions options = null);

        /// <summary>
        /// Retrieves default iRules.
        /// </summary>
        /// <param name="networkDomainId">The network domain id</param>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions">The paging options</param>
        /// <returns>The async task of <see cref="PagedResponse{DefaultIruleType}"/></returns>
        Task<PagedResponse<DefaultIruleType>> GetDefaultIrulesPaginated(Guid networkDomainId, DefaultIruleListOptions options = null, PageableRequest pagingOptions = null);
    }
}