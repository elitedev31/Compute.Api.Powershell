using System.Xml.Schema;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
	/// <summary>
	///		Represents summary information about a CaaS data centre.
	/// </summary>
	[XmlRoot("Datacenter", Namespace = XmlNamespaceConstants.Datacenter)]
	public class DatacenterSummary
		: IDatacenterSummary
	{
		/// <summary>
		///		Create a new <see cref="DatacenterSummary"/>.
		/// </summary>
		public DatacenterSummary()
		{
		}

		/// <summary>
		///		Is the data centre the default data centre for the caller's organisation?
		/// </summary>
		[XmlAttribute("default", Form = XmlSchemaForm.Qualified)]
		public bool IsDefault
		{
			get;
			set;
		}

		/// <summary>
		///		The short location code used as a key to identity the data centre.
		/// </summary>
		[XmlAttribute("location", Form = XmlSchemaForm.Qualified)]
		public string LocationCode
		{
			get;
			set;
		}

		/// <summary>
		///		The data centre display name.
		/// </summary>
		[XmlElement("displayName")]
		public string DisplayName
		{
			get;
			set;
		}

		/// <summary>
		///		The name of the city in which the data centre is located.
		/// </summary>
		[XmlElement("city")]
		public string City
		{
			get;
			set;
		}

		/// <summary>
		///		The name of the state in which the data centre is located.
		/// </summary>
		[XmlElement("state")]
		public string State
		{
			get;
			set;
		}

		/// <summary>
		///		The name of the country in which the data centre is located.
		/// </summary>
		[XmlElement("country")]
		public string Country
		{
			get;
			set;
		}

		/// <summary>
		///		The access URL for the data centre VPN.
		/// </summary>
		[XmlElement("vpnUrl")]
		public string VpnUrl
		{
			get;
			set;
		}

		/// <summary>
		///		The maximum number of CPUs per virtual machine supported by the data centre.
		/// </summary>
		[XmlElement("maxCpu")]
		public short MaxCpu
		{
			get;
			set;
		}

		/// <summary>
		///		The maximum RAM (in MB) per virtual machine supported by the data centre.
		/// </summary>
		[XmlElement("maxRamMb")]
		public int MaxRamMB
		{
			get;
			set;
		}
	}
}
