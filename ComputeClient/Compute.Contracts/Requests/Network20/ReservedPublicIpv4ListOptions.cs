namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;

    /// <summary>The reserved public IP v4 list options.</summary>
    public class ReservedPublicIpv4ListOptions : FilterableRequest
    {
        /// <summary>
        /// The "networkId" field name.
        /// </summary>
        public const string NetworkIdField = "networkId";

        /// <summary>
        /// The "networkDomainId" field name.
        /// </summary>
        public const string NetworkDomainIdField = "networkDomainId";

        /// <summary>
        /// The "ipBlockId" field name.
        /// </summary>
        public const string IpBlockIdField = "ipBlockId";

        /// <summary>
        /// The "ipAddress" field name.
        /// </summary>
        public const string IpAddressField = "ipAddress";

        /// <summary>	
        /// Identifies MCP 1.0 network id.
        /// </summary>
        public string NetworkId
        {
            get { return GetFilter<string>(NetworkIdField); }
            set { SetFilter(NetworkIdField, value); }
        }

        /// <summary>	
        /// Identifies MCP 2.0 network domain id.
        /// </summary>
        public string NetworkDomainId
        {
            get { return GetFilter<string>(NetworkDomainIdField); }
            set { SetFilter(NetworkDomainIdField, value); }
        }

        /// <summary>	
        /// Identifies IP Block id.
        /// </summary>
        public Guid? IpBlockId
        {
            get { return GetFilter<Guid?>(IpBlockIdField); }
            set { SetFilter(IpBlockIdField, value); }
        }

        /// <summary>	
        /// Identifies private IPv4 addresses.
        /// </summary>
        public string IpAddress
        {
            get { return GetFilter<string>(IpAddressField); }
            set { SetFilter(IpAddressField, value); }
        }
    }
}