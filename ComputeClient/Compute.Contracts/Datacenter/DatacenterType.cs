using System;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
		/// <summary>	A datacenter type. </summary>
		/// <remarks>	Anthony, 4/24/2015. </remarks>
 		[XmlRoot(ElementName = "datacenter")]
		public class DatacenterType
		{
			/// <summary>	Gets or sets the name of the display. </summary>
			/// <value>	The name of the display. </value>
			[XmlElement(ElementName = "displayName")]
			public string DisplayName { get; set; }

			/// <summary>	Gets or sets the city. </summary>
			/// <value>	The city. </value>
			[XmlElement(ElementName = "city")]
			public string City { get; set; }

			/// <summary>	Gets or sets the state. </summary>
			/// <value>	The state. </value>
			[XmlElement(ElementName = "state")]
			public string State { get; set; }

			/// <summary>	Gets or sets the country. </summary>
			/// <value>	The country. </value>
			[XmlElement(ElementName = "country")]
			public string Country { get; set; }

			/// <summary>	Gets or sets URL of the VPN. </summary>
			/// <value>	The VPN URL. </value>
			[XmlElement(ElementName = "vpnUrl")]
			public string VpnUrl { get; set; }

			/// <summary>	Gets or sets the networking. </summary>
			/// <value>	The networking. </value>
			[XmlElement(ElementName = "networking")]
			public DatacenterWithMaintenanceStatusType.DatacenterNetworkingType Networking { get; set; }

 			/// <summary>	Gets the type of the networking. </summary>
 			/// <value>	The type of the networking. </value>
 			public int NetworkingType
 			{
 				get
 				{
 					return Int32.Parse(Networking.Type);
 				}
 			}

			/// <summary>	Gets or sets the hypervisor. </summary>
			/// <value>	The hypervisor. </value>
			[XmlElement(ElementName = "hypervisor")]
			public Hypervisor Hypervisor { get; set; }

			/// <summary>	Gets or sets the location. </summary>
			/// <value>	The location. </value>
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }

			/// <summary>	Gets or sets the default. </summary>
			/// <value>	The default. </value>
			[XmlAttribute(AttributeName = "default")]
			public string Default { get; set; }
		}
}