using System;
using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

namespace DD.CBU.Compute.Api.Contracts.Requests.Vip
{
    /// <summary>
    /// The Node list options.
    /// </summary>
    public class NodeListOptions: IFilterableRequest
    {
        /// <summary>	
        /// Identifies an individual Node.
        /// </summary>
        [FilterParameter("id")]
        public Guid? Id { get; set; }

        /// <summary>	
        /// Identifies an individual Network Domain.
        /// </summary>
        [FilterParameter("networkDomainId")]
        public Guid? NetworkDomainId { get; set; }

        /// <summary>	
        /// Identifies an individual Data Center.
        /// </summary>
        [FilterParameter("datacenterId")]
        public Guid? DatacenterId { get; set; }

        /// <summary>	
        /// Identifies Nodes by their name.
        /// </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>	
        /// Identifies Nodes by their state.
        /// Case insensitive. The initial possible set of values for state are:
        /// "NORMAL",
        /// "PENDING_ADD",
        /// "PENDING_CHANGE",
        /// "PENDING_DELETE",
        /// "FAILED_ADD",
        /// "FAILED_CHANGE",
        /// "FAILED_DELETE" and
        /// "REQUIRES_SUPPORT".
        /// </summary>
        [FilterParameter("state")]
        public string State { get; set; }

        /// <summary>	
        /// Identifies the date of creation of Pools.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. 
        /// </summary>
        [FilterParameter("createTime")]
        public DateTime? CreateTime { get; set; }

        /// <summary>	
        /// Identifies Nodes by their specific Ipv4Address.
        /// loadBalanceMethod=ROUND_ROBIN
        /// </summary>
        [FilterParameter("ipv4Address")]
        public string Ipv4Address { get; set; }

        /// <summary>	
        /// Identifies Nodes by their specific Ipv6Address.
        /// loadBalanceMethod=ROUND_ROBIN
        /// </summary>
        [FilterParameter("ipv6Address")]
        public string Ipv6Address { get; set; }
    }
}