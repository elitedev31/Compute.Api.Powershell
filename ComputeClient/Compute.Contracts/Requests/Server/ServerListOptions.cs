using System;

namespace DD.CBU.Compute.Api.Contracts.Requests.Server
{
	public class ServerListOptions
	{
		public Guid id { get; set; }
		public Guid datacenterId { get; set; }
		public Guid networkDomainId { get; set; }
		public Guid networkId { get; set; }
		public Guid vlanId { get; set; }
		public Guid sourceImageId { get; set; }
		public string deployed { get; set; }
		public string name { get; set; }
		public string createTime { get; set; }
		public string state { get; set; }
		public bool started { get; set; }
		public Guid operatingSystemId { get; set; }
		public string ipv6 { get; set; }
		public string privateIpv4 { get; set; }
	}
}
