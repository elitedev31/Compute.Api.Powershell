namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;

    /// <summary>The reserved ip v6 list options.</summary>
    public class ReservedIpv6ListOptions : FilterableRequest
    {

        /// <summary>
        /// The "vlanId" field name.
        /// </summary>
        public const string VlanIdField = "vlanId";

        /// <summary>
        /// The "ipAddress" field name.
        /// </summary>
        public const string IpAddressField = "ipAddress";

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