using System;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Api.Client.Interfaces.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Infrastructure;

    /// <summary>
	/// The AccountAccessor interface.
	/// </summary>
	public interface IInfrastructureAccessor
    {
        /// <summary>
        /// The get data centers with maintenance statuses.
        /// </summary>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <param name="filterOptions">
        /// The Filter options
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>        
        Task<IEnumerable<DatacenterType>> GetDataCenters(IPageableRequest pagingOptions = null, DataCenterListOptions filterOptions = null);

        /// <summary>
        /// The get data centers with maintenance statuses.
        /// </summary>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <param name="filterOptions">
        /// The Filter options
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<PagedResponse<DatacenterType>> GetDataCentersPaginated(IPageableRequest pagingOptions = null, DataCenterListOptions filterOptions = null);

        /// <summary>
        /// The get os images for a data center
        /// </summary>
        /// <param name="dataCenterId">
        /// Data center id
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <param name="filterOptions">
        /// The Filter options
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<PagedResponse<OperatingSystemDetailType>> GetOperatingSystems(string dataCenterId, IPageableRequest pagingOptions = null, OperatingSystemListOptions filterOptions = null);
    }
}
