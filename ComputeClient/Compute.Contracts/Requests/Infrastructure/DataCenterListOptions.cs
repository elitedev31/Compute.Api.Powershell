namespace DD.CBU.Compute.Api.Contracts.Requests.Infrastructure
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// Filtering options for the data center request.
    /// 
    /// </summary>
    public sealed class DataCenterListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the data center id filter.
        /// 
        /// </summary>
        [FilterParameter("id")]
        public string Id { get; set; }
    }
}
