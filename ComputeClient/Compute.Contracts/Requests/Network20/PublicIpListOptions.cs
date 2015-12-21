using System;
using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The NAT Rule list options type.
    /// </summary>
    public class PublicIpListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid[] Ids { get; set; }

        /// <summary>
        /// Identifies an Datacenter.
        /// </summary>
        [FilterParameter("datacenterId")]
        public string DataCenterId { get; set; }

        /// <summary>
        /// Identifies an Datacenter.
        /// </summary>
        [FilterParameter("baseIp")]
        public string BaseIp { get; set; }


        /// <summary>
        /// Identifies an Datacenter.
        /// </summary>
        [FilterParameter("size")]
        public string Size { get; set; }

        /// <summary>
        /// Identifies an Datacenter.
        /// </summary>
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