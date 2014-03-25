using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.General
{
	/// <summary>
	///		Represents a generic response to a CaaS API call.
	/// </summary>
	[XmlRoot("Status", Namespace = XmlNamespaceConstants.General)]
	public class ApiStatus
	{
		/// <summary>
		///		Create a generic CaaS response data-contract.
		/// </summary>
		public ApiStatus()
		{
		}

		/// <summary>
		///		The operation that was requested.
		/// </summary>
		[XmlElement("operation", Namespace = XmlNamespaceConstants.General)]
		public string Operation
		{
			get;
			set;
		}

		/// <summary>
		///		The result of the operation.
		/// </summary>
		[XmlElement("result", Namespace = XmlNamespaceConstants.General)]
		public string Result
		{
			get;
			set;
		}

		/// <summary>
		///		Detailed information (if available) about the operation result.
		/// </summary>
		[XmlElement("resultDetail", Namespace = XmlNamespaceConstants.General)]
		public string ResultDetail
		{
			get;
			set;
		}

		/// <summary>
		///		A result code that can be used to further identify the nature of the result.
		/// </summary>
		[XmlElement("resultCode", Namespace = XmlNamespaceConstants.General)]
		public string ResultCode
		{
			get;
			set;
		}
	}
}
