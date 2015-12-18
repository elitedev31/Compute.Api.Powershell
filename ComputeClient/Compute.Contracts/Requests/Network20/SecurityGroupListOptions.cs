namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>	A VLAN list options model. </summary>
    public class SecurityGroupListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid[] Ids { get; set; }      
       
        /// <summary>	Identifies VLANs by their name.
        /// name=ProductionVLAN
        /// Supports the use of the LIKE
        /// comparator defined in the Paging
        /// and Filtering for List API
        /// Functions overview. </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>	Identifies VLANs by their state.
        /// Case insensitive. The initial possible
        /// set of values for vlan.state are:
        /// "NORMAL",
        /// "PENDING_ADD",
        /// "PENDING_CHANGE",
        /// "PENDING_DELETE",
        /// "FAILED_ADD",
        /// "FAILED_CHANGE",
        /// "FAILED_DELETE",
        /// "REQUIRES_SUPPORT"
        /// This set of values should not be
        /// assumed to be static and can
        /// increase at any time. </summary>
        [FilterParameter("state")]
        public string State { get; set; }

        /// <summary>	Identifies the date of creation of
        /// Security group.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. </summary>
        [FilterParameter("createTime", ".LT=")]
        public DateTimeOffset? CreateTimeBefore { get; set; }

        /// <summary>	Identifies the date of creation of
        /// Security group.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. </summary>
        [FilterParameter("createTime", ".GT=")]
        public DateTimeOffset? CreateTimeAfter { get; set; }

        /// <summary>	Identifies the date of creation of
        /// Security group.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. </summary>
        [FilterParameter("createTime", ".MIN=")]
        public DateTimeOffset? CreateTimeMin { get; set; }

        /// <summary>	Identifies the date of creation of
        /// Security group.
        /// Supports MIN, MAX, LT and GT.
        /// Refer to samples in Paging and
        /// Filtering for List API Functions. </summary>
        [FilterParameter("createTime", ".MAX=")]
        public DateTimeOffset? CreateTimeMax { get; set; }
    }
}
