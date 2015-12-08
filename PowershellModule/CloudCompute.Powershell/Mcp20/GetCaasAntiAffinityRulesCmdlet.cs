using System;
using System.Collections.Generic;
using System.Linq;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;
    using Api.Contracts.Requests.Server20;

    [Cmdlet(VerbsCommon.Get, "CaasAntiAffinityRules")]
    [OutputType(typeof(AntiAffinityRuleType))]
    public class GetCaasAntiAffinityRulesCmdlet : PSCmdletCaasWithConnectionBase
    {        
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "NetworkDomainFilter", HelpMessage = "The network domain")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "NetworkFilter", HelpMessage = "The network domain")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "ServerFilter", HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets the network.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "NetworkDomainFilter", HelpMessage = "The network")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "NetworkFilter", HelpMessage = "The network")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "ServerFilter", HelpMessage = "The network")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     Gets or sets Server.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "NetworkDomainFilter", HelpMessage = "The Server")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "NetworkFilter", HelpMessage = "The Server")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "ServerFilter", HelpMessage = "The Server")]
        public ServerType Server { get; set; }

        /// <summary>
        ///     Gets or sets Anti affinity rule id.
        /// </summary>]
        [Parameter(Mandatory = false, HelpMessage = "The anti-afiinity rule id")]
        public Guid RuleId { get; set; }

        /// <summary>
        ///     Gets or sets Anti affinity rule state.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The anti-afiinity rule state")]
        public string State { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<AntiAffinityRuleType> antiAffinityRules = new List<AntiAffinityRuleType>();
            base.ProcessRecord();

            try
            {
                var filterOptions = (RuleId != Guid.Empty || !string.IsNullOrWhiteSpace(State)
                                            ? new AntiAffinityRuleListOptions
                                            {
                                                Id = RuleId != Guid.Empty ? RuleId : (Guid?)null,
                                                State = State
                                            }
                                            : null);

                if (ParameterSetName.Equals("ServerFilter"))
                {
                    antiAffinityRules = Connection.ApiClient.ServerManagement.AntiAffinityRule.GetAntiAffinityRulesForServer(Guid.Parse(Server.id), filterOptions).Result;
                }
                else if (ParameterSetName.Equals("NetworkDomainFilter"))
                {
                    antiAffinityRules = Connection.ApiClient.ServerManagement.AntiAffinityRule.GetAntiAffinityRulesForNetworkDomain(Guid.Parse(NetworkDomain.id), filterOptions).Result;
                }
                else if (ParameterSetName.Equals("NetworkFilter"))
                {
                    antiAffinityRules = Connection.ApiClient.ServerManagement.AntiAffinityRule.GetAntiAffinityRulesForNetwork(Guid.Parse(Network.id), filterOptions).Result;
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
            WriteObject(antiAffinityRules, true);            
        }
    }
}
