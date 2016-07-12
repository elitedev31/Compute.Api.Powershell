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
    public class ConsistencyGroupSnapshotAccessor : IConsistencyGroupSnapshotAccessor
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
		public ConsistencyGroupSnapshotAccessor(IWebApi apiClient)
		{
			_apiClient = apiClient;
		}

		/// <summary>
		/// The Get Consistency Group Snapshot method.
		/// </summary>
		/// <param name="filteringOptions">The filtering options.</param>
		/// <returns>List of <see cref="consistencyGroupSnapshots"/></returns>
		public async Task<consistencyGroupSnapshots> GetConsistencyGroupSnapshots(ConsistencyGroupSnapshotListOptions filteringOptions = null)
	    {
			return await _apiClient.GetAsync<consistencyGroupSnapshots>(ApiUris.GetConsistencyGroupSnapshots(_apiClient.OrganizationId), null, filteringOptions);
		}
	}
}