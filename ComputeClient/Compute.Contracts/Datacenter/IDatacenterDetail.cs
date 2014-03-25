using System.Collections.Generic;

namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
	/// <summary>
	///		Provides read-only access to summary information about a CaaS data centre (with disk speed detail).
	/// </summary>
	public interface IDatacenterDetail
		: IDatacenterSummary
	{
		/// <summary>
		///		Detailed information about disk speeds available at the data centre.
		/// </summary>
		IReadOnlyList<IDiskSpeedDetail> DiskSpeedDetails
		{
			get;
		}
	}
}