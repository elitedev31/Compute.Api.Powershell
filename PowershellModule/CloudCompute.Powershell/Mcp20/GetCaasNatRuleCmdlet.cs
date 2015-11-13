using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;
    using Mcp1 = Api.Contracts.Network;
    using Mcp2 = Api.Contracts.Network20;

    [Cmdlet(VerbsCommon.Get, "CaasNatRule")]
    [OutputType(typeof(Mcp1.NatRuleType), ParameterSetName = new[] { "MCP1" })]
    [OutputType(typeof(Mcp2.NatRuleType), ParameterSetName = new[] { "MCP2" })]
    public class GetCaasNATRuleCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the Nat rule state.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "MCP2", HelpMessage = "The NAT rule state")]
        public string State { get; set; }

        /// <summary>	
        /// Gets or sets internal IP address.
        /// </summary>        
        [Parameter(Mandatory = false, ParameterSetName = "MCP2", HelpMessage = "The firewall internal IP")]
        public string InternalIp { get; set; }

        /// <summary>	
        /// Identifies internal IP address.
        /// </summary>        
        [Parameter(Mandatory = false, ParameterSetName = "MCP2", HelpMessage = "The firewall external IP")]
        public string ExternalIp { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP2", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets NAT rule id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "MCP2", HelpMessage = "The NAT rule id")]
        public Guid NatRuleId { get; set; }

        /// <summary>
		///     The network to show the NAT rules from
		/// </summary>
		[Parameter(Mandatory = true, ParameterSetName = "MCP1", ValueFromPipeline = true, HelpMessage = "The network to show the images from")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     Get a CaaS network by name
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "MCP1", HelpMessage = "Name to filter")]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<Object> natRules = null;
            base.ProcessRecord();

            try
            {
                if (ParameterSetName.Equals("MCP1"))
                {
                    var resultlist = Connection.ApiClient.NetworkingLegacy.Network.GetNatRules(Network.id).Result;

                    if (!string.IsNullOrEmpty(Name))
                        resultlist = resultlist.Where(
                                net => string.Equals(net.name, Name, StringComparison.CurrentCultureIgnoreCase));

                    natRules = resultlist;
                }
                else if (ParameterSetName.Equals("MCP2"))
                {
                    natRules =
                        Connection.ApiClient.Networking.Nat.GetNatRules(
                            NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty,
                            (NatRuleId != Guid.Empty || !string.IsNullOrWhiteSpace(State) || !string.IsNullOrWhiteSpace(InternalIp) || !string.IsNullOrWhiteSpace(ExternalIp)
                                ? new NatRuleListOptions
                                {
                                    Id = NatRuleId != Guid.Empty ? NatRuleId : (Guid?)null,
                                    State = State,
                                    InternalIp = InternalIp,
                                    ExternalIp = ExternalIp
                                }
                                : null))
                                  .Result;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(
                                new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else
                        {
                            ThrowTerminatingError(
                                new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }

            if (natRules != null && natRules.Count() == 1)
            {
                WriteObject(natRules.First());
            }
            else
            {
                WriteObject(natRules);
            }
        }
    }
}
