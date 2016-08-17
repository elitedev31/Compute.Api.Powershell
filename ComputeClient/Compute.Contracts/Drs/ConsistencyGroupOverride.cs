namespace DD.CBU.Compute.Api.Contracts.Drs
{
    using System;

    public partial class ConsistencyGroupSnapshotType
    {
        /// <remarks/>
        public DateTimeOffset createTimeOffset {
            get { return DateTimeOffset.Parse(createTime); }
        }
    }
}