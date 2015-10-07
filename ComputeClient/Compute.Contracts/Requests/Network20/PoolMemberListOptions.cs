using System;
using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The Pool Members list option.
    /// </summary>
    public class PoolMemberListOptions: IFilterableRequest
    {
        /// <summary>	
        /// Identifies an individual Pool Member.
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
        /// Identifies an individual Pool.
        /// </summary>
        [FilterParameter("poolId")]
        public Guid? PoolId { get; set; }

        /// <summary>	
        /// Identifies Pools by their name.
        /// </summary>
        [FilterParameter("poolName")]
        public string PoolName { get; set; }

        /// <summary>	
        /// Identifies an individual Node.
        /// </summary>
        [FilterParameter("nodeId")]
        public Guid? NodeId { get; set; }

        /// <summary>	
        /// Identifies Nodes by their name.
        /// </summary>
        [FilterParameter("nodeName")]
        public string NodeName { get; set; }

        /// <summary>	
        /// Identifies Nodes by their ipv4Address or by their ipv6Address.
        /// </summary>
        [FilterParameter("nodeIp")]
        public string NodeIp { get; set; }

        /// <summary>	
        /// Identifies Nodes by their status.
        /// nodeStatus=ENABLED
        /// </summary>
        [FilterParameter("nodeStatus")]
        public string NodeStatus { get; set; }

        /// <summary>	
        /// Identifies Pool Members by their port value.
        /// </summary>
        [FilterParameter("port")]
        public string Port { get; set; }

        /// <summary>	
        /// Identifies Pool Members by their status.
        /// </summary>
        [FilterParameter("status")]
        public string Status { get; set; }

        /// <summary>	
        /// Identifies Pool Members by their state.
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
        /// Identifies the date of creation of Pool Members.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. 
        /// </summary>
        [FilterParameter("createTime")]
        public DateTime? CreateTime { get; set; }
    }
}