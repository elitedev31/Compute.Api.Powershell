namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Backup;

    /// <summary>
    /// The set backup service plan cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasBackupPlan")]
    [OutputType(typeof(ServerWithBackupType))]
    public class SetCaasBackupPlanCmdlet : PSCmdletCaasBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
        public ServerWithBackupType Server { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The service plan of the backup")]
        public ServicePlan BackupServicePlan { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var status = CaaS.ApiClient.ChangeBackupPlan(Server.id, BackupServicePlan).Result;

                if (status != null)
                {
                    WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                        {
                            if (e is ComputeApiException)
                            {
                                WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, CaaS));
                            }
                            else //if (e is HttpRequestException)
                            {
                                ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, CaaS));
                            }
                            return true;
                        });
            }
            WriteObject(Server);
        }
    }
}