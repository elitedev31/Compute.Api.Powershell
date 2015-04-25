using System.Collections.Generic;
using System.Xml.Serialization;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
	[XmlRoot(ElementName = "hypervisor")]
	public class Hypervisor
	{
		[XmlElement(ElementName = "diskSpeed")]
		public List<DatacenterWithMaintenanceStatusType.DiskSpeed> DiskSpeed { get; set; }
		[XmlElement(ElementName = "backup")]
		public DatacenterWithMaintenanceStatusType.Backup Backup { get; set; }
		[XmlElement(ElementName = "property")]
		public List<DatacenterWithMaintenanceStatusType.Property> Property { get; set; }
		[XmlAttribute(AttributeName = "maintenanceStatus")]
		public string MaintenanceStatus { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
	}
}