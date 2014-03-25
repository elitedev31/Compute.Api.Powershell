using System.Xml.Schema;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
	/// <summary>
	///		Represents detailed information about a disk speed specification.
	/// </summary>
	public class DiskSpeedDetail
		: IDiskSpeedDetail
	{
		/// <summary>
		///		Create a new <see cref="DiskSpeedDetail"/>.
		/// </summary>
		public DiskSpeedDetail()
		{
		}

		/// <summary>
		///		Is the disk speed available at the parent data centre?
		/// </summary>
		[XmlAttribute("available", Form = XmlSchemaForm.Qualified)]
		public bool IsAvailable
		{
			get;
			set;
		}

		/// <summary>
		///		Is the disk speed the default disk speed at the parent data centre?
		/// </summary>
		[XmlAttribute("default", Form = XmlSchemaForm.Qualified)]
		public bool IsDefault
		{
			get;
			set;
		}

		/// <summary>
		///		The disk speed Id.
		/// </summary>
		[XmlAttribute("id", Form = XmlSchemaForm.Qualified)]
		public string Id
		{
			get;
			set;
		}

		/// <summary>
		///		A display name for the disk speed.
		/// </summary>
		[XmlElement("displayName")]
		public string DisplayName
		{
			get;
			set;
		}

		/// <summary>
		///		An abbreviated name for the disk speed.
		/// </summary>
		[XmlElement("abbreviation")]
		public string Abbreviation
		{
			get;
			set;
		}

		/// <summary>
		///		A description of the disk speed.
		/// </summary>
		[XmlElement("description")]
		public string Description
		{
			get;
			set;
		}
	}
}
