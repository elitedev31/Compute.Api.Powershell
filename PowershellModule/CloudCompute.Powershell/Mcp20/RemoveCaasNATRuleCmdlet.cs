using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The Remove NAT Rule CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasNatRule")]
    [OutputType(typeof(ResponseType))]
    public class RemoveCaasNATRuleCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the NAT Rule.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The NAT Rule")]
        public NatRuleType NatRule { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {    
                response = Connection.ApiClient.Networking.Nat.DeleteNatRule(Guid.Parse(NatRule.id)).Result;
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