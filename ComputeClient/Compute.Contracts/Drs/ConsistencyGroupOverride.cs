namespace DD.CBU.Compute.Api.Contracts.Drs
{
    using System;

    public partial class ConsistencyGroupSnapshotType
    {
        /// <remarks/>
        public DateTimeOffset createTimeOffset => DateTimeOffset.Parse(createTime);
    }
}