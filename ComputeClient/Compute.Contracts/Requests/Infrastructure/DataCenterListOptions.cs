namespace DD.CBU.Compute.Api.Contracts.Requests.Infrastructure
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// Filtering options for the anti affinity rule request.
    /// </summary>
    public sealed class DataCenterListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the anti affinity rule id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid? Id { get; set; }
	}
}
