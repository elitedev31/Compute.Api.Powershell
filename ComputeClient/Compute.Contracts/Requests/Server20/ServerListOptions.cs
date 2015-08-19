namespace DD.CBU.Compute.Api.Contracts.Requests.Server20
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// Filtering options for the server request.
    /// </summary>
    public sealed class ServerListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the DatacenterId filter.
        /// </summary>
        [FilterParameter("datacenterId")]
        public string DatacenterId { get; set; }

        /// <summary>
        /// Gets or sets the NetworkDomainId filter.
        /// </summary>
        [FilterParameter("networkDomainId")]
        public Guid? NetworkDomainId { get; set; }

        /// <summary>
        /// Gets or sets the NetworkId filter.
        /// </summary>
        [FilterParameter("networkId")]
        public Guid? NetworkId { get; set; }

        /// <summary>
        /// Gets or sets the VlanId filter.
        /// </summary>
        [FilterParameter("vlanId")]
        public Guid? VlanId { get; set; }

        /// <summary>
        /// Gets or sets the SourceImageId filter.
        /// </summary>
        [FilterParameter("sourceImageId")]
        public Guid? SourceImageId { get; set; }

        /// <summary>
        /// Gets or sets the Deployed filter.
        /// </summary>
        [FilterParameter("deployed")]
        public string Deployed { get; set; }

        /// <summary>
        /// Gets or sets the Name filter.
        /// </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the CreateTimeBefore filter.
        /// </summary>
        [FilterParameter("createTime", ".LT=")]
        public DateTimeOffset? CreateTimeBefore { get; set; }

        /// <summary>
        /// Gets or sets the CreateTimeAfter filter.
        /// </summary>
        [FilterParameter("createTime", ".GT=")]
        public DateTimeOffset? CreateTimeAfter { get; set; }

        /// <summary>
        /// Gets or sets the State filter.
        /// </summary>
        [FilterParameter("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Started filter.
        /// </summary>
        [FilterParameter("started")]
        public bool? Started { get; set; }

        /// <summary>
        /// Gets or sets the OperatingSystemId filter.
        /// </summary>
        [FilterParameter("operatingSystemId")]
        public Guid? OperatingSystemId { get; set; }

        /// <summary>
        /// Gets or sets the Ipv6 filter.
        /// </summary>
        [FilterParameter("ipv6")]
        public string Ipv6 { get; set; }

        /// <summary>
        /// Gets or sets the PrivateIpv4 filter.
        /// </summary>
        [FilterParameter("privateIpv4")]
        public string PrivateIpv4 { get; set; }
	}
}
