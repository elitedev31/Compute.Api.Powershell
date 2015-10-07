namespace DD.CBU.Compute.Api.Contracts.Requests.Server20
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>
    /// Filtering options for the anti affinity rule request.
    /// </summary>
    public sealed class AntiAffinityRuleListOptions : IFilterableRequest
    {
        /// <summary>
        /// Gets or sets the anti affinity rule id filter.
        /// </summary>
        [FilterParameter("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the create time before filter.
        /// </summary>
        [FilterParameter("createTime", ".LT=")]
        public DateTimeOffset? CreateTimeBefore { get; set; }

        /// <summary>
        /// Gets or sets the create time after filter.
        /// </summary>
        [FilterParameter("createTime", ".GT=")]
        public DateTimeOffset? CreateTimeAfter { get; set; }

        /// <summary>
        /// Gets or sets the state filter.
        /// </summary>
        [FilterParameter("state")]
        public string State { get; set; }
	}
}
