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

        /// <summary>
        /// Creates an ip address list.
        /// </summary>
        /// <param name="createIpAddressList">The ip address list details.</param>
        /// <returns>The response details.</returns>
        Task<ResponseType> CreateIpAddressList(CreateIpAddressList createIpAddressList);

        /// <summary>
        /// Lists all ip address list.
        /// </summary>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <param name="options">The filter options.</param>
        /// <returns>The collection of matching ip address list.</returns>
        Task<IEnumerable<IpAddressListType>> GetIpAddressLists(Guid networkDomainId, IpAddressListOptions options = null);

        /// <summary>
        /// Lists all ip address list.
        /// </summary>
        /// <param name="networkDomainId">The Network domain id.</param>
        /// <param name="options">The filter options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The async task of <see cref="PagedResponse{IpAddressListType}"/></returns>
        Task<PagedResponse<IpAddressListType>> GetIpAddressListsPaginated(Guid networkDomainId, IpAddressListOptions options = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// Gets the ip address list.
        /// </summary>
        /// <param name="ipAddressListId">The ip address list id.</param>
        /// <returns>The collection of matching ip address list.</returns>
        Task<IpAddressListType> GetIpAddressList(Guid ipAddressListId);

        /// <summary>
        /// Edits an ip address list.
        /// </summary>
        /// <param name="editIpAddressList">The ip address list details.</param>
        /// <returns>The response details.</returns>
        Task<ResponseType> EditIpAddressList(EditIpAddressList editIpAddressList);

        /// <summary>
        /// Deletes an ip address list.
        /// </summary>
        /// <param name="deleteIpAddressList">The ip address list id to be deleted.</param>
        /// <returns>The response details.</returns>
        Task<ResponseType> DeleteIpAddressList(DeleteIpAddressListType deleteIpAddressList);
    }
}
