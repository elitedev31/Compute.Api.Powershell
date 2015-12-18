namespace DD.CBU.Compute.Api.Contracts.Requests.Infrastructure
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// Filtering options for the operating system request.
    /// 
    /// </summary>
    public sealed class OperatingSystemListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the operating system id filter.
        /// 
        /// </summary>
        [FilterParameter("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the operating system name filter.
        /// 
        /// </summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the operating system family filter.
        /// 
        /// </summary>
        [FilterParameter("family")]
        public string Family { get; set; }
    }
}
