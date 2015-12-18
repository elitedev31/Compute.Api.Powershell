namespace DD.CBU.Compute.Api.Client.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DD.CBU.Compute.Api.Client.Interfaces.Infrastructure;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Requests.Infrastructure;

    /// <summary>
	/// The AccountAccessor interface.
	/// </summary>
	public class InfrastructureAccessor : IInfrastructureAccessor
    {
        /// <summary>
		/// The _api client.
		/// </summary>
		private readonly IWebApi _apiClient;

        /// <summary>
        /// Initialises a new instance of the <see cref="InfrastructureAccessor"/> class.
        /// </summary>
        /// <param name="apiClient">
        /// The api client.
        /// </param>
        public InfrastructureAccessor(IWebApi apiClient)
        {
            this._apiClient = apiClient;
        }

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
        public async Task<IEnumerable<DatacenterType>> GetDataCenters(IPageableRequest pagingOptions = null, DataCenterListOptions filterOptions = null)
        {
            datacenters dataCenters = await _apiClient.GetAsync<datacenters>(
                ApiUris.DataCentres(_apiClient.OrganizationId), pagingOptions, filterOptions);
            return dataCenters.datacenter;
        }

        /// <summary>
        /// Get Operating systems supported at the data center level
        /// </summary>
        /// <param name="dataCenterId">Data center id</param>
        /// <param name="pagingOptions">Paging options</param>
        /// <param name="filterOptions">Filtering options</param>
        /// <returns>Operating Systems</returns>
        public async Task<PagedResponse<OperatingSystemType>> GetOperatingSystems(string dataCenterId, IPageableRequest pagingOptions = null, OperatingSystemListOptions filterOptions = null)
        {
            var response = await _apiClient.GetAsync<operatingSystems>(
              ApiUris.GetMcp2OperatingSystems(_apiClient.OrganizationId, dataCenterId),
              pagingOptions,
              filterOptions);

            return new PagedResponse<OperatingSystemType>
            {
                items = response.operatingSystem,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Get Operating systems supported at the data center level
        /// </summary>
        /// <param name="dataCenterId">Data center id</param>
        /// <param name="filterOptions">Filtering options</param>
        /// <returns>Operating Systems</returns>
        public async Task<IEnumerable<OperatingSystemType>> GetOperatingSystems(string dataCenterId, OperatingSystemListOptions filterOptions = null)
        {           
            return (await GetOperatingSystems(dataCenterId, null, filterOptions)).items;
        }
    }
}
