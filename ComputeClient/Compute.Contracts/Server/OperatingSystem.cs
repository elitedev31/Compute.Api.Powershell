using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		Represents a well-known operating system for CaaS virtual machines.
	/// </summary>
	public class OperatingSystem
		: IOperatingSystem
	{
		/// <summary>
		///		Create a new operating system.
		/// </summary>
		public OperatingSystem()
		{
		}

		/// <summary>
		///		The operating system type.
		/// </summary>
		[XmlElement("type", Namespace = XmlNamespaceConstants.Server)]
		public OperatingSystemTypeEnum OperatingSystemType
		{
			get;
			set;
		}

		/// <summary>
		///		The operating system display-name.
		/// </summary>
		[XmlElement("displayName", Namespace = XmlNamespaceConstants.Server)]
		public string DisplayName
		{
			get;
			set;
		}
	}
}
