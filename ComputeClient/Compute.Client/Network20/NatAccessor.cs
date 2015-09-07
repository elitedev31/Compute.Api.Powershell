using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.Interfaces.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;
using NatRuleType = DD.CBU.Compute.Api.Contracts.Network.NatRuleType;

namespace DD.CBU.Compute.Api.Client.Network20
{
    /// <summary>
    /// The Network Address Translation Management.
    /// </summary>
    public class NatAccessor: INatAccessor
    {
        /// <summary>
        /// The Web Api.
        /// </summary>
        private readonly IWebApi _api;

        /// <summary>
        /// Initialises a new instance of the <see cref="NatAccessor"/> class.
        /// </summary>
        /// /// <param name="api">
		/// The api.
		/// </param>
        public NatAccessor(IWebApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Retrieves the list of the NAT Rules on a particular Network Domain at an MCP 2.0 data center
        /// This API requires your organization ID and the ID of the target network.
        /// </summary>
        /// <param name="networkDomainId">  Identifier for the network domain.</param>
        /// <param name="options">          Options for filtering the operations.</param>
        /// <param name="pagingOptions">    The paging options, null means default.</param>
        /// <returns>                       The NAT Rule collection.</returns>
        public async Task<natRules> GetNatRules(string networkDomainId, NatRuleListOptions options = null, PageableRequest pagingOptions = null)
        {
            return 
                await
                    _api.GetAsync<natRules>(ApiUris.GetDomainNatRules(_api.OrganizationId, networkDomainId),
                        pagingOptions, options);
        }

        /// <summary>
        /// Creates a NAT Rule on a Network Domain in an MCP 2.0 data center location.
        /// </summary>
        /// <param name="natRule">
        /// The NAT Rule.
        /// </param>
        /// <returns>
        /// Operation status
        /// </returns>
        public async Task<ResponseType> CreateNatRule(createNatRule natRule)
        {
            return
                await _api.PostAsync<createNatRule, ResponseType>(ApiUris.CreateNatRule(_api.OrganizationId), natRule);
        }

        /// <summary>
        /// 	Returns details of a single NAT Rule.
        /// </summary>
        /// <param name="natRuleId">
        /// 	The NAT Rule id.
        /// </param>
        /// <returns>
        /// 	The NAt Rule. 
        /// </returns>
        public async Task<Contracts.Network20.NatRuleType> GetNatRule(string natRuleId)
        {
            return
                await _api.GetAsync<Contracts.Network20.NatRuleType>(ApiUris.GetNatRule(_api.OrganizationId, natRuleId));
        }

        /// <summary>
        /// 	Deletes a NAT Rule. 
        /// </summary>
        /// <param name="natRuleId">
        /// 	 	The id of the VLAN. 
        /// </param>
        /// <returns>
        /// 	The job from the API; 
        /// </returns>
        public async Task<ResponseType> DeleteNatRule(string natRuleId)
        {
            return
                await
                    _api.PostAsync<deleteNatRule, ResponseType>(ApiUris.DeleteNatRule(_api.OrganizationId),
                        new deleteNatRule {id = natRuleId});
        }
    }
}