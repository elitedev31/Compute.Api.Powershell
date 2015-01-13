using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Remove, "CaasServerAntiAffinityRule",SupportsShouldProcess = true)]
    public class RemoveCaasServerAntiAffinityRuleCmdlet:PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The Anti affinity rule, retrived by Get-CaasServerAntiAffinityRule.", ValueFromPipeline = true)]
        public AntiAffinityRuleType Rule { get; set; }

        /// <summary>
        /// Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                if (!ShouldProcess(Rule.id)) return;
                var status = Connection.ApiClient.RemoveServerAntiAffinityRule(Rule.id).Result;
                if (status != null)
                    WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));
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
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }
                        return true;
                    });
            }
        }
    }
}
