namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;

    /// <summary>	A VLAN list options model. </summary>
    public class VlanListOptions : FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "networkDomainId" field name.
        /// </summary>
        public const string NetworkDomainIdField = "networkDomainId";

        /// <summary>
        /// The "datacenterId" field name.
        /// </summary>
        public const string DatacenterIdField = "datacenterId";

        /// <summary>
        /// The "name" field name.
        /// </summary>
        public const string NameField = "name";

        /// <summary>
        /// The "privateIpv4Address" field name.
        /// </summary>
        public const string PrivateIpv4AddressField = "privateIpv4Address";

        /// <summary>
        /// The "ipv6Address" field name.
        /// </summary>
        public const string Ipv6AddressField = "ipv6Address";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";

        /// <summary>
        /// The "createTime" field name.
        /// </summary>
        public const string CreateTimeField = "createTime";

        /// <summary>	
        /// Identifies an individual Virtual Listener.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
            set { SetFilter(IdField, value); }
        }

        /// <summary>	
        /// Identifies an individual Network Domain.
        /// </summary>
        public Guid? NetworkDomainId
        {
            get { return GetFilter<Guid?>(NetworkDomainIdField); }
            set { SetFilter(NetworkDomainIdField, value); }
        }

        /// <summary>	
        /// Identifies an individual Data Center.
        /// </summary>
        public string DatacenterId
        {
            get { return GetFilter<string>(DatacenterIdField); }
            set { SetFilter(DatacenterIdField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their name.
        /// </summary>
        public string Name
        {
            get { return GetFilter<string>(NameField); }
            set { SetFilter(NameField, value); }
        }

        /// <summary> Identifies VLANs by their base
        /// network IPv4 address.
        /// privateIpv4Address=10.1.1.0. </summary>
        public string PrivateIpv4Address
        {
            get { return GetFilter<string>(PrivateIpv4AddressField); }
            set { SetFilter(PrivateIpv4AddressField, value); }
        }

        /// <summary>	Identifies VLANs by their base
        /// network IPv6 address.
        /// ipv6Address=
        /// 2607:f480:1111:1102:0:0:0:0. </summary>
        public string Ipv6Address
        {
            get { return GetFilter<string>(Ipv6AddressField); }
            set { SetFilter(Ipv6AddressField, value); }
        }

        /// <summary>	Identifies VLANs by their state.
        /// Case insensitive. The initial possible
        /// set of values for vlan.state are:
        /// "NORMAL",
        /// "PENDING_ADD",
        /// "PENDING_CHANGE",
        /// "PENDING_DELETE",
        /// "FAILED_ADD",
        /// "FAILED_CHANGE",
        /// "FAILED_DELETE" and
        /// "REQUIRES_SUPPORT".
        /// This set of values should not be
        /// assumed to be static and can
        /// increase at any time. </summary>
        public string State
        {
            get { return GetFilter<string>(StateField); }
            set { SetFilter(StateField, value); }
        }

        /// <summary>	Identifies the date of creation of
        /// VLANs.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. </summary>
        public DateTimeOffset? CreateTimeBefore
        {
            get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.LessThan); }
            set { SetFilter(CreateTimeField, FilterOperator.LessThan, value); }
        }

        /// <summary>	Identifies the date of creation of
        /// VLANs.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. </summary>
        public DateTimeOffset? CreateTimeAfter
        {
            get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.GreaterThan); }
            set { SetFilter(CreateTimeField, FilterOperator.GreaterThan, value); }
        }
    }
}
