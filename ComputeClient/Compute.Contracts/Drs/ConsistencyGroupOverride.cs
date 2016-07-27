using System;

namespace DD.CBU.Compute.Api.Contracts.Drs
{
	public partial class ConsistencyGroupSnapshotType
	{
		/// <remarks/>
		public DateTimeOffset createTimeOffset => DateTimeOffset.Parse(this.createTime);
	}
}
