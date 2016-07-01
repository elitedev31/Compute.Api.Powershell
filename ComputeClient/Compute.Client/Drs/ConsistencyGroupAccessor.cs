namespace DD.CBU.Compute.Api.Client.Drs
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.Drs;
    using Contracts.General;
    using Contracts.Network20;
    using Contracts.Requests;
    using Contracts.Requests.Drs;
    using Interfaces;
    using Interfaces.Drs;

    /// <summary>
    /// The Consistency Group Accessor type.
    /// </summary>
    public class ConsistencyGroupAccessor: IConsistencyGroupAccessor
    {
        /// <summary>
		/// The _client.
		/// </summary>
		private readonly IWebApi _apiClient;

        /// <summary>
        /// 	Initializes a new instance of the DD.CBU.Compute.Api.Client.Network20.NetworkDomain
        /// 	class.
        /// </summary>
        /// <param name="apiClient">	The client. </param>
        public ConsistencyGroupAccessor(IWebApi apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// The Get Consistency Group method.
        /// </summary>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <returns>List of <see cref="ConsistencyGroupType"/></returns>
        public async Task<IEnumerable<ConsistencyGroupType>> GetConsistencyGroups(ConsistencyGroupListOptions filteringOptions = null)
        {
            var response = await GetConsistencyGroupsPaginated(filteringOptions, null);
            return response.items;
        }

        /// <summary>
        /// The Get Consistency Group menthod.
        /// </summary>
        /// <param name="filteringOptions">The filtering options.</param>
        /// <param name="pagingOptions">The pagination options.</param>
        /// <returns>Paginated result of <see cref="ConsistencyGroupType"/></returns>
        public async Task<PagedResponse<ConsistencyGroupType>> GetConsistencyGroupsPaginated(ConsistencyGroupListOptions filteringOptions = null, PageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<consistencyGroups>(ApiUris.GetConsistencyGroups(_apiClient.OrganizationId), pagingOptions, filteringOptions);
            return new PagedResponse<ConsistencyGroupType>
            {
                items = response.consistencyGroup,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// The Create Consistency Group
        /// </summary>
        /// <param name="createConsistencyGroup">The create consistency group type.</param>
        /// <returns>The <see cref="ResponseType"/></returns>
        public async Task<ResponseType> CreateConsistencyGroup(CreateConsistencyGroupType createConsistencyGroup)
        {
            return await _apiClient.PostAsync<CreateConsistencyGroupType, ResponseType>(ApiUris.CreateConsistencyGroups(_apiClient.OrganizationId), createConsistencyGroup);
        }
    }
}