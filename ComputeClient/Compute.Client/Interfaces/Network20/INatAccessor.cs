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
    /// The Network Address Translation Management interface.
    /// </summary>
    public interface INatAccessor
    {
        /// <summary>
        /// Retrieves the list of the NAT Rules on a particular Network Domain at an MCP 2.0 data center
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="networkDomainId">  Identifier for the network domain.</param>
        /// <param name="options">          Options for filtering the operations.</param>
        /// <returns></returns>
        Task<IEnumerable<NatRuleType>> GetNatRules(Guid networkDomainId, NatRuleListOptions options = null);

        /// <summary>
        /// Retrieves the list of the NAT Rules on a particular Network Domain at an MCP 2.0 data center
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="networkDomainId">  Identifier for the network domain.</param>
        /// <param name="options">          Options for filtering the operations.</param>
        /// <param name="pagingOptions">    The paging options, null means default.</param>
        /// <returns>                       The NAT Rule collection.</returns>
        Task<PagedResponse<NatRuleType>> GetNatRulesPaginated(Guid networkDomainId, NatRuleListOptions options = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// Creates a NAT Rule on a Network Domain in an MCP 2.0 data center location.
        /// </summary>
        /// <param name="natRule">
        /// The NAT Rule.
        /// </param>
        /// <returns>
        /// Operation status
        /// </returns>
        Task<ResponseType> CreateNatRule(createNatRule natRule);

        /// <summary>
        /// 	Returns details of a single NAT Rule.
        /// </summary>
        /// <param name="natRuleId">
        /// 	The NAT Rule id.
        /// </param>
        /// <returns>
        /// 	The NAt Rule. 
        /// </returns>
        Task<NatRuleType> GetNatRule(Guid natRuleId);

        /// <summary>
        /// 	Deletes a NAT Rule. 
        /// </summary>
        /// <param name="natRuleId">
        /// 	 	The id of the VLAN. 
        /// </param>
        /// <returns>
        /// 	The job from the API; 
        /// </returns>
        Task<ResponseType> DeleteNatRule(Guid natRuleId);
    }
}