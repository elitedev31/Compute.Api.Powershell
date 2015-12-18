namespace DD.CBU.Compute.Api.Contracts.Requests.Server20
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// Filtering options for the server request.
    /// </summary>
    public sealed class ServerCustomerImageListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid[] Ids { get; set; }

        /// <summary>
        /// Gets or sets the DatacenterId filter.
        /// </summary>
        [FilterParameter("datacenterId")]
        public string DatacenterId { get; set; }     

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
        /// Gets or sets the CreateTimeAfter Inclusive filter.
        /// </summary>
        [FilterParameter("createTime", ".MIN=")]
        public DateTimeOffset? CreateTimeMin { get; set; }

        /// <summary>
        /// Gets or sets the CreateTimeMax filter.
        /// </summary>
        [FilterParameter("createTime", ".MAX=")]
        public DateTimeOffset? CreateTimeMax { get; set; }

        /// <summary>
        /// Gets or sets the State filter.
        /// </summary>
        [FilterParameter("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Operating SystemId filter like REDHAT664.
        /// </summary>
        [FilterParameter("operatingSystemId")]
        public string OperatingSystemId { get; set; }

        /// <summary>
        /// Gets or sets the Operating System Family filter. eg : UNIX
        /// </summary>
        [FilterParameter("operatingSystemFamily")]
        public string OperatingSystemFamily { get; set; }
	}
}
