using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The Set Caas Firewall Rule CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasFirewallRule")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasFirewallRuleCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets Firewall Rule.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Firewall Rule")]
        public FirewallRuleType FirewallRule { get; set; }
        
        [Parameter(Mandatory = true, HelpMessage = "Is Firewall enabled?")]
        public bool Enabled { get; set; }
        
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var firewall = new EditFirewallRuleType
                                {
                                    id = FirewallRule.id,
                                    enabled = Enabled
                                };

                response = Connection.ApiClient.Networking.FirewallRule.EditFirewallRule(firewall).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else
                        {
                            // if (e is HttpRequestException)
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }

            WriteObject(response);
        }
    }
}