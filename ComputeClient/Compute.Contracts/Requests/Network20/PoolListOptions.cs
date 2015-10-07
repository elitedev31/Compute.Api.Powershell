using System;
using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The pool list options.
    /// </summary>
    public class PoolListOptions: IFilterableRequest
    {
        /// <summary>	
        /// Identifies an individual Pool.
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
        /// Identifies Pools by their name.
        /// </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>	
        /// Identifies Pools by their state.
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
        /// Identifies Pools with the supplied loadBalanceMethod(s).
        /// loadBalanceMethod=ROUND_ROBIN
        /// </summary>
        [FilterParameter("loadBalancedMethod")]
        public string LoadBalancedMethod { get; set; }

        /// <summary>	
        /// Filters the list to Pools with the supplied serviceDownAction(s).
        /// serviceDownAction=DROP
        /// </summary>
        [FilterParameter("serviceDownAction")]
        public string ServiceDownAction { get; set; }

        /// <summary>	
        /// Filters the list to Pools with the supplied slowRampTime(s).
        /// Supports MIN, MAX, LT and GT. 
        /// slowRampTime.GT=10
        /// </summary>
        [FilterParameter("slowRampTime")]
        public int? SlowRampTime { get; set; }
    }
}