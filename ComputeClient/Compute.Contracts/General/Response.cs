using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.General
{
	/// <summary>	A response (MCP 2.0). </summary>
	[XmlRoot(ElementName = "response", Namespace = "urn:didata.com:api:cloud:types")]
	public class Response
	{
		[XmlElement(ElementName = "operation", Namespace = "urn:didata.com:api:cloud:types")]
		public string Operation { get; set; }
		[XmlElement(ElementName = "responseCode", Namespace = "urn:didata.com:api:cloud:types")]
		public string ResponseCode { get; set; }
		[XmlElement(ElementName = "message", Namespace = "urn:didata.com:api:cloud:types")]
		public string Message { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "requestId")]
		public string RequestId { get; set; }
	}
}
