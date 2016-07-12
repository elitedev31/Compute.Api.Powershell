namespace DD.CBU.Compute.Api.Client.Interfaces.Drs
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.Drs;
    using Contracts.General;
    using Contracts.Network20;
    using Contracts.Requests;
    using Contracts.Requests.Drs;

    /// <summary>
    /// The Consistency Group Snapshot Interface.
    /// </summary>
    public interface IConsistencyGroupSnapshotAccessor
	{
        /// <summary>
        /// The Get Consistency Group Snapshots method.
        /// </summary>
        /// <returns>List of <see cref="ConsistencyGroupType"/></returns>
        Task<consistencyGroupSnapshots> GetConsistencyGroupSnapshots(ConsistencyGroupSnapshotListOptions filteringOptions = null);
    }
}