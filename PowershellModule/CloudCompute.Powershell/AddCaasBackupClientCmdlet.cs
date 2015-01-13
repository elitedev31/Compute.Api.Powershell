using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Backup;
    using DD.CBU.Compute.Api.Contracts.Backup;

    /// <summary>
    /// The Add backup client cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "CaasBackupClient")]
    [OutputType(typeof(string))]
    public class AddCaasBackupClientCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The server to add the backup client",
            ValueFromPipeline = true)]
        public ServerWithBackupType Server { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The storage policy availabe from Get-CaasBackupStoragePolicies cmdlet")]
        public BackupStoragePolicy StoragePolicy { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The schedule policy availabe from Get-CaasBackupSchedulePolicies cmdlet")]
        public BackupSchedulePolicy SchedulePolicy { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The backup client type availabe from Get-CaasBackupClientTypes cmdlet")]
        public BackupClientType ClientType { get; set; }

        [Parameter(HelpMessage = "The trigger type for alerting purposes")]
        public TriggerType? Trigger { get; set; }

        [Parameter(HelpMessage = "The email addresses for alerting purposes. At least one must be added when using alerting")]
        public IReadOnlyList<string> EmailAddresses { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var downloadLink = AddBackupClient();
                
                WriteObject(downloadLink);
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

        /// <summary>
        /// Adds a backup client to the server and returns the download link url
        /// </summary>
        /// <returns>The download link</returns>
        private string AddBackupClient()
        {
            AlertingType alerting = null;

            if (Trigger.HasValue)
            {
                if (EmailAddresses == null || EmailAddresses.Count == 0)
                {
                    ThrowTerminatingError(new ErrorRecord(new ArgumentException("At least one email address must be supploed when setting a trigger type"), "-1", ErrorCategory.NotSpecified, this));
                    return string.Empty;
                }

                alerting = new AlertingType { emailAddress = EmailAddresses.ToArray(), trigger = Trigger.Value };
            }

            var status = Connection.ApiClient.AddBackupClient(Server.id, ClientType, StoragePolicy, SchedulePolicy, alerting).Result;
            if (status != null)
            {
                WriteDebug(
                    string.Format(
                        "{0} resulted in {1} ({2}): {3}",
                        status.operation,
                        status.result,
                        status.resultCode,
                        status.resultDetail));

                return status.additionalInformation.Single(ai => ai.name == "backupClient.downloadUrl").value;
            }
            return string.Empty;
        }
    }
}