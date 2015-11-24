namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>	A VLAN list options model. </summary>
    public class VlanListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid[] Ids { get; set; }

        /// <summary>	Identifies an individual VLAN.
        /// id=9a857b7c-37bd-11e2-a91c-
        /// 0030487e0302. </summary>
        [FilterParameter("id")]
        public Guid? Id { get; set; }

        /// <summary>	Identifies an individual Network
        /// Domain.
        /// networkDomainId=9a857b7c-37bd-
        /// 11e2-a91c-0030487e0302. </summary>
        [FilterParameter("networkDomainId")]
        public Guid? NetworkDomainId { get; set; }

        /// <summary>	Identifies an individual Data Center.
        /// See List Data Centers.
        /// datacenterId=NA9. </summary>
        [FilterParameter("datacenterId")]
        public string DatacenterId { get; set; }

        /// <summary>	Identifies VLANs by their name.
        /// name=ProductionVLAN
        /// Supports the use of the LIKE
        /// comparator defined in the Paging
        /// and Filtering for List API
        /// Functions overview. </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary> Identifies VLANs by their base
        /// network IPv4 address.
        /// privateIpv4Address=10.1.1.0. </summary>
        [FilterParameter("privateIpv4Address")]
        public string PrivateIpv4Address { get; set; }

        /// <summary>	Identifies VLANs by their base
        /// network IPv6 address.
        /// ipv6Address=
        /// 2607:f480:1111:1102:0:0:0:0. </summary>
        [FilterParameter("ipv6Address")]
        public string Ipv6Address { get; set; }

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
        [FilterParameter("state")]
        public string State { get; set; }

        /// <summary>	Identifies the date of creation of
        /// VLANs.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. </summary>
        [FilterParameter("createTime", ".LT=")]
        public DateTimeOffset? CreateTimeBefore { get; set; }

        /// <summary>	Identifies the date of creation of
        /// VLANs.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. </summary>
        [FilterParameter("createTime", ".GT=")]
        public DateTimeOffset? CreateTimeAfter { get; set; }
    }
}
