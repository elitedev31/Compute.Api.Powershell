namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

    /// <summary>A firewall rule list options model. </summary>
    public class FirewallRuleListOptions : IFilterableRequest
    {
        /// <summary>Gets or sets the id filter.</summary>
        [FilterParameter("id")]
        public Guid[] Ids { get; set; }

        /// <summary>Filter firewall rules by identifier.</summary>
        [FilterParameter("id")]
        public Guid? Id { get; set; }

        /// <summary>Filter firewall rules by network domain.</summary>
        [FilterParameter("networkDomainId")]
        public Guid? NetworkDomainId { get; set; }

        /// <summary>Filter firewall rules by name.</summary>
        [FilterParameter("name")]
        public string Name { get; set; }

        /// <summary>Filter fireall rules by state.
        /// Case insensitive. The initial possible set of values for state are:
        /// "NORMAL",
        /// "PENDING_ADD",
        /// "PENDING_CHANGE",
        /// "PENDING_DELETE",
        /// "FAILED_ADD",
        /// "FAILED_CHANGE",
        /// "FAILED_DELETE" and
        /// "REQUIRES_SUPPORT".
        /// This set of values should not be
        /// assumed to be static and can
        /// increase at any time. </summary>
        [FilterParameter("state")]
        public string State { get; set; }

        /// <summary>Filter firewall rules by creation date before.</summary>
        [FilterParameter("createTime", ".LT=")]
        public DateTimeOffset? CreateTimeBefore { get; set; }

        /// <summary>Filter firewall rules by creation date after.</summary>
        [FilterParameter("createTime", ".GT=")]
        public DateTimeOffset? CreateTimeAfter { get; set; }
    }
}
