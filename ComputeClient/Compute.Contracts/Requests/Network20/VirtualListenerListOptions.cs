using System;
using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The Virtal Listener List Options type.
    /// </summary>
    public class VirtualListenerListOptions: IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid[] Ids { get; set; }

        /// <summary>	
        /// Identifies an individual Virtual Listener.
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
        /// Identifies Virtual Listeners by their name.
        /// </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by whether or not they are enabled.
        /// </summary>
        [FilterParameter("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by their state.
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
        /// Identifies Virtual Listeners by their type.
        /// </summary>
        [FilterParameter("type")]
        public string Type { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by their protocol.
        /// </summary>
        [FilterParameter("protocol")]
        public string Protocol { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by their Listener IP Address.
        /// </summary>
        [FilterParameter("listenerIpAddress")]
        public string ListenerIpAddress { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by their virtual listener port.
        /// </summary>
        [FilterParameter("port")]
        public int? Port { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by their Pool Id.
        /// </summary>
        [FilterParameter("poolId")]
        public string PoolId { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by their Client Pool Id.
        /// </summary>
        [FilterParameter("clientClonePoolId")]
        public string ClientClonePoolId { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by their default Persistence profile Id.
        /// </summary>
        [FilterParameter("persistenceProfileId")]
        public string PersistenceProfileId { get; set; }

        /// <summary>	
        /// Identifies Virtual Listeners by their Fallback Persistence Profile Id.
        /// </summary>
        [FilterParameter("fallbaclPersistenceProfileId")]
        public string FallbaclPersistenceProfileId { get; set; }
    }
}