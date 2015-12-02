using System;
using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The NAT Rule list options type.
    /// </summary>
    public class NatRuleListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid[] Ids { get; set; }

        /// <summary>
        /// Identifies an individual NAT Rule.
        /// </summary>
        [FilterParameter("id")]
        public Guid? Id { get; set; }

        /// <summary>	
        /// Identifies NAT Rules by their state.
        /// Case insensitive. The initial possible
        /// set of values for state are:
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
        /// Identifies the date of creation of NAT Rules.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. 
        /// </summary>
        [FilterParameter("createTime")]
        public DateTime? CreateTime { get; set; }

        /// <summary>	
        /// Identifies internal IPv4 address addresses.
        /// </summary>
        [FilterParameter("internalIp")]
        public string InternalIp { get; set; }

        /// <summary>	
        /// Identifies external IPv4 addresses.
        /// </summary>
        [FilterParameter("externalIp")]
        public string ExternalIp { get; set; }

        /// <summary>	
        /// Identifies NAT Rule by node id.
        /// </summary>
        [FilterParameter("nodeId")]
        public Guid? NodeId { get; set; }
    }
}