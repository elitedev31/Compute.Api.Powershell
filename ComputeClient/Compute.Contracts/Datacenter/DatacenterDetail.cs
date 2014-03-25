using System.Collections.Generic;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
	/// <summary>
	///		Represents CaaS data centre with disk speed details.
	/// </summary>
	[XmlRoot("DatacenterWithDiskSpeedDetail", Namespace = XmlNamespaceConstants.Datacenter)]
	public class DatacenterDetail
		: DatacenterSummary, IDatacenterDetail
	{
		/// <summary>
		///		Detailed information about disk speeds available at the data centre.
		/// </summary>
		readonly List<DiskSpeedDetail> _diskSpeedDetails = new List<DiskSpeedDetail>();

		/// <summary>
		///		Create a new <see cref="DatacenterDetail"/>.
		/// </summary>
		public DatacenterDetail()
		{
		}

		/// <summary>
		///		Detailed information about disk speeds available at the data centre.
		/// </summary>
		[XmlElement("diskSpeed")]
		public List<DiskSpeedDetail> DiskSpeedDetails
		{
			get
			{
				return _diskSpeedDetails;
			}
		}

		/// <summary>
		///		Detailed information about disk speeds available at the data centre.
		/// </summary>
		IReadOnlyList<IDiskSpeedDetail> IDatacenterDetail.DiskSpeedDetails
		{
			get
			{
				return DiskSpeedDetails;
			}
		}
	}
}
