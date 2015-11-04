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

    [Cmdlet(VerbsCommon.Get, "CaasNatRule")]
    [OutputType(typeof(NatRuleType))]
    public class GetCaasNatRuleCmdlet : PSCmdletCaasWithConnectionBase
    {        
        /// <summary>
        ///     Gets or sets NAT rule id.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The NAT Rule Id")]
        public Guid NatRuleId { get; set; }

        protected override void ProcessRecord()
        {
            NatRuleType natRule = new NatRuleType();
            base.ProcessRecord();

            try
            {
                natRule = Connection.ApiClient.Networking.Nat.GetNatRule(NatRuleId).Result;
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

            WriteObject(natRule);            
        }
    }
}
