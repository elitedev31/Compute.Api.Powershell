namespace DD.CBU.Compute.Api.Contracts.Requests.Drs
{
    using System;

    /// <summary>
    /// Filtering options for the Consistency Group Snapshot.
    /// </summary>
    public sealed class ConsistencyGroupSnapshotListOptions : FilterableRequest
    {
		/// <summary>
		/// The "consistencyGroupId" field name.
		/// </summary>
		public const string IdField = "consistencyGroupId";

		/// <summary>
		/// The "createTime.MIN" field name.
		/// </summary>
		public const string CreateTimeField = "createTime";

		/// <summary>
		/// Gets or sets the CreateTimeMax filter.
		/// </summary>
		public DateTimeOffset? CreateTimeMax
		{
			get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.GreaterOrEqual); }
			set { SetFilter(CreateTimeField, FilterOperator.GreaterOrEqual, value); }
		}
	}
}