namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.General;
    using Api.Contracts.Server10;

    /// <summary>
    ///     The remove caas server anti affinity rule cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasServerAntiAffinityRule", SupportsShouldProcess = true)]
    [OutputType(typeof(Status))]
    public class RemoveCaasServerAntiAffinityRuleCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the rule.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Anti affinity rule, retrived by Get-CaasServerAntiAffinityRule.", ValueFromPipeline = true)]
        public AntiAffinityRuleType Rule { get; set; }

        /// <summary>
        ///     Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                if (!ShouldProcess(Rule.id))
                {
                    return;
                }

                Status status = Connection.ApiClient.ServerManagementLegacy.Server.RemoveServerAntiAffinityRule(Rule.id).Result;
                WriteObject(status);
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
        }
    }
}