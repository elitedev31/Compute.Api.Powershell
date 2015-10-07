using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
    /// <summary>
    /// The Firewall Rule Accessor interface.
    /// </summary>
    public interface IFirewallRuleAccessor
    {
        /// <summary>
        /// Lists all firewall rules.
        /// </summary>
        /// <param name="options">The filter options.</param>
        /// <returns>The collection of matching firewall rules.</returns>
        Task<IEnumerable<FirewallRuleType>> GetFirewallRules(FirewallRuleListOptions options = null);

        /// <summary>
        /// Lists all firewall rules.
        /// </summary>
        /// <param name="options">The filter options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The async task of <see cref="PagedResponse{FirewallRuleType}"/></returns>
        Task<PagedResponse<FirewallRuleType>> GetFirewallRulesPaginated(FirewallRuleListOptions options = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// Gets a specific firewall rule.
        /// </summary>
        /// <param name="firewallRuleId">The firewall rule identifier.</param>
        /// <returns>The response details.</returns>
        Task<FirewallRuleType> GetFirewallRule(Guid firewallRuleId);

        /// <summary>
        /// Creates a firewall rule.
        /// </summary>
        /// <param name="createFirewallRule">The firewall rule details.</param>
        /// <returns>The response details.</returns>
        Task<ResponseType> CreateFirewallRule(CreateFirewallRuleType createFirewallRule);

        /// <summary>
        /// Edits a firewall rule.
        /// </summary>
        /// <param name="editFirewallRule">The firewall rule details.</param>
        /// <returns>The response details.</returns>
        Task<ResponseType> EditFirewallRule(EditFirewallRuleType editFirewallRule);

        /// <summary>
        /// Deletes a firewall rule.
        /// </summary>
        /// <param name="firewallRuleId">The firewall rule identifier.</param>
        /// <returns>The response details.</returns>
        Task<ResponseType> DeleteFirewallRule(Guid firewallRuleId);
	}
}
