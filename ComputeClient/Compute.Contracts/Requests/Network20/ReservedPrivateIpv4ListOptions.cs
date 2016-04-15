namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;

    /// <summary>The reserved private ip v4 list options.</summary>
    public class ReservedPrivateIpv4ListOptions : FilterableRequest
    {
        /// <summary>
        /// The "networkId" field name.
        /// </summary>
        public const string NetworkIdField = "networkId";

        /// <summary>
        /// The "vlanId" field name.
        /// </summary>
        public const string VlanIdField = "vlanId";

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
        /// Identifies VLAN id.
        /// </summary>
        public Guid? VlanId
        {
            get { return GetFilter<Guid?>(VlanIdField); }
            set { SetFilter(VlanIdField, value); }
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