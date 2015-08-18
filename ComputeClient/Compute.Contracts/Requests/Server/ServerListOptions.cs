namespace DD.CBU.Compute.Api.Contracts.Requests.Server
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// Filtering options for the server request.
    /// </summary>
    public sealed class ServerListOptions : IFilterableRequest
	{
        /// <summary>
        /// Gets or sets the Id filter.
        /// </summary>
        [FilterParameter("id")]
		public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the Location filter.
        /// </summary>
        [FilterParameter("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Name filter.
        /// </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the MachineName filter.
        /// </summary>
        [FilterParameter("machineName")]
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the NetworkId filter.
        /// </summary>
        [FilterParameter("networkId")]
        public Guid? NetworkId { get; set; }

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
        /// Gets or sets the PrivateIp filter.
        /// </summary>
        [FilterParameter("privateIp")]
        public string PrivateIp { get; set; }
	}
}
