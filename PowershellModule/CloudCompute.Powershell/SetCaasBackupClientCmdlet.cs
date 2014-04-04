namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Backup;
    using DD.CBU.Compute.Api.Contracts.Backup;

    /// <summary>
    /// The Set backup client cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasBackupClient")]
    [OutputType(typeof(ServersWithBackupServer))]
    public class SetCaasBackupClientCmdlet : PSCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The server to modify the backup client",
            ValueFromPipeline = true)]
        public ServersWithBackupServer Server { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The backup client details to modify")]
        public BackupClientDetailsType BackupClient { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The storage policy to modify")]
        public BackupStoragePolicy StoragePolicy { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The schedule policy to modify")]
        public BackupSchedulePolicy SchedulePolicy { get; set; }

        [Parameter(HelpMessage = "The alerting type to modify")]
        public AlertingType Aletring { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                ModifyBackupClient();
                WriteObject(Server);
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
        }

        /// <summary>
        /// Modify a backup client
        /// </summary>
        private void ModifyBackupClient()
        {
            var status = CaaS.ApiClient.ModifyBackupClient(Server.id, BackupClient, StoragePolicy, SchedulePolicy, Aletring).Result;
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
    }
}