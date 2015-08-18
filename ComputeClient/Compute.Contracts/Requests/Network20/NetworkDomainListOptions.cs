namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// Filtering options for the network request.
    /// </summary>
    public sealed class NetworkDomainListOptions : IFilterableRequest
	{
        /// <summary>
        /// Gets or sets the Id filter.
        /// </summary>
        [FilterParameter("id")]
		public Guid? Id { get; set; }

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
        /// Gets or sets the Type filter.
        /// </summary>
        [FilterParameter("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the State filter.
        /// </summary>
        [FilterParameter("state")]
        public string State { get; set; }

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
	}
}
