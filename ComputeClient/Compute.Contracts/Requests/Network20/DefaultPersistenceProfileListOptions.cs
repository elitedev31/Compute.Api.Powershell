namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// A persistence profile list options model.
    /// </summary>
    public class DefaultPersistenceProfileListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the datacenter id filter.
        /// </summary>
        [FilterParameter("datacenterId")]
        public string DatacenterId { get; set; }

        /// <summary>
        /// Gets or sets the name filter.
        /// </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state filter.
        /// </summary>
        [FilterParameter("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the enabled filter.
        /// </summary>
        [FilterParameter("enabled")]
        public bool Enabled { get; set; }
    }
}
