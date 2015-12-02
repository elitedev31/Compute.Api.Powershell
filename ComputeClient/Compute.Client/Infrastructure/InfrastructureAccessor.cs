using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Requests.Infrastructure;

namespace DD.CBU.Compute.Api.Client.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DD.CBU.Compute.Api.Client.Interfaces.Infrastructure;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;

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
    }
}
