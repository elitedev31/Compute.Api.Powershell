using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		Well-known operating system types.
	/// </summary>
	[XmlRoot("OperatingSystemType", Namespace = XmlNamespaceConstants.Server)]
	public enum OperatingSystemTypeEnum
	{
		/// <summary>
		///		An unknown type of operating system.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown	= 0,

		/// <summary>
		///		A windows operating system.
		/// </summary>
		[XmlEnum("WINDOWS")]
		Windows	= 1,

		/// <summary>
		///		A UNIX-style operating system.
		/// </summary>
		[XmlEnum("UNIX")]
		Unix	= 2
	}
}
