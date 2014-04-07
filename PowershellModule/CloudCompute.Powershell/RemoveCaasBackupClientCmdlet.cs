namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Backup;

    /// <summary>
    /// The Remove backup client cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasBackupClient")]
    public class RemoveCaasBackupClientCmdlet : PSCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The server to remove the backup client from",
            ValueFromPipeline = true)]
        public ServersWithBackupServer Server { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The backup client details to remove")]
        public BackupClientDetailsType BackupClient { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                RemoveBackupClient();
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
        /// Removes a backup client from the server
        /// </summary>
        private void RemoveBackupClient()
        {
            var status = CaaS.ApiClient.RemoveBackupClient(Server.id, BackupClient).Result;
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