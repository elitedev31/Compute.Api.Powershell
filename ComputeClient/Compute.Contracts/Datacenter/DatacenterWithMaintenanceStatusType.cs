using System;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
	/// <summary>	A datacenter with maintenance status type. </summary>
	/// <remarks>	Anthony, 4/24/2015. </remarks>
	[XmlRoot(ElementName = "DatacentersWithMaintenanceStatus")]
	public class DatacenterWithMaintenanceStatusType
	{
		/// <summary>	Gets or sets the datacenter. </summary>
		/// <value>	The datacenter. </value>
		[XmlElement(ElementName = "datacenter")]
		public DatacenterType Datacenter { get; set; }

		/// <summary>	Gets or sets the ns 7. </summary>
		/// <value>	The ns 7. </value>
		[XmlAttribute(AttributeName = "ns7", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns7 { get; set; }

		/// <summary>	A property. </summary>
		/// <remarks>	Anthony, 4/24/2015. </remarks>
		[XmlRoot(ElementName = "property")]
		public class Property
		{
			/// <summary>	Gets or sets the value. </summary>
			/// <value>	The value. </value>
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }

			/// <summary>	Gets or sets the name. </summary>
			/// <value>	The name. </value>
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		/// <summary>	Gets the type of the networking. </summary>
		/// <value>	The type of the networking. </value>
		public int NetworkingType
		{
			get
			{
				return Int32.Parse(Networking.Type);
			}
		}

		/// <summary>	Gets or sets the networking. </summary>
		/// <value>	The networking. </value>
		[XmlElement(ElementName = "networking")]
		public DatacenterNetworkingType Networking { get; set; }

		/// <summary>	A datacenter networking type. </summary>
		/// <remarks>	Anthony, 4/24/2015. </remarks>
		public class DatacenterNetworkingType
		{
			/// <summary>	Gets or sets the property. </summary>
			/// <value>	The property. </value>
			[XmlElement(ElementName = "property")]
			public Property Property { get; set; }

			/// <summary>	Gets or sets the type. </summary>
			/// <value>	The type. </value>
			[XmlAttribute(AttributeName = "type")]
			public string Type { get; set; }

			/// <summary>	Gets or sets the maintenance status. </summary>
			/// <value>	The maintenance status. </value>
			[XmlAttribute(AttributeName = "maintenanceStatus")]
			public string MaintenanceStatus { get; set; }
		}

		[XmlRoot(ElementName = "diskSpeed")]
		public class DiskSpeed
		{
			[XmlElement(ElementName = "displayName")]
			public string DisplayName { get; set; }
			[XmlElement(ElementName = "abbreviation")]
			public string Abbreviation { get; set; }
			[XmlElement(ElementName = "description")]
			public string Description { get; set; }
			[XmlAttribute(AttributeName = "available")]
			public string Available { get; set; }
			[XmlAttribute(AttributeName = "default")]
			public string Default { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
		}

		[XmlRoot(ElementName = "backup")]
		public class Backup
		{
			[XmlAttribute(AttributeName = "type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "maintenanceStatus")]
			public string MaintenanceStatus { get; set; }
		}
	}

}