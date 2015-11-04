using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    [Cmdlet(VerbsCommon.Get, "CaasFirewallRule")]
    [OutputType(typeof(FirewallRuleType))]
    public class GetCaasFirewallRuleCmdlet : PSCmdletCaasWithConnectionBase
    {        
        /// <summary>
        ///     Gets or sets firewall rule id.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The firewall rule id")]
        public Guid FirewallRuleId { get; set; }

        protected override void ProcessRecord()
        {
            FirewallRuleType firewallRule = new FirewallRuleType();
            base.ProcessRecord();

            try
            {
                firewallRule = Connection.ApiClient.Networking.FirewallRule.GetFirewallRule(FirewallRuleId).Result;
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

            WriteObject(firewallRule);            
        }
    }
}
