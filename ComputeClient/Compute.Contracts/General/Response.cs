using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.General
{
	/// <summary>	A response (MCP 2.0). </summary>
	[XmlRoot(ElementName = "response", Namespace = "urn:didata.com:api:cloud:types")]
	public class Response
	{
		/// <summary>	Gets or sets the operation. </summary>
		/// <value>	The operation. </value>
		[XmlElement(ElementName = "operation", Namespace = "urn:didata.com:api:cloud:types")]
		public string Operation { get; set; }

		/// <summary>	Gets or sets the response code. </summary>
		/// <value>	The response code. </value>
		[XmlElement(ElementName = "responseCode", Namespace = "urn:didata.com:api:cloud:types")]
		public string ResponseCode { get; set; }

		/// <summary>	Gets or sets the message. </summary>
		/// <value>	The message. </value>
		[XmlElement(ElementName = "message", Namespace = "urn:didata.com:api:cloud:types")]
		public string Message { get; set; }

		/// <summary>	Gets or sets the xmlns. </summary>
		/// <value>	The xmlns. </value>
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }

		/// <summary>	Gets or sets the identifier of the request. </summary>
		/// <value>	The identifier of the request. </value>
		[XmlAttribute(AttributeName = "requestId")]
		public string RequestId { get; set; }
	}
}
