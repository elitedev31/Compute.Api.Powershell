using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Backup;

    /// <summary>
    /// The provision/deprovision backup cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasProvisionBackup")]
    [OutputType(typeof(ServerWithBackupType))]
    public class SetCaasProvisionBackupCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
        public ServerWithBackupType Server { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Determines whether to enable or disable backup. If enable, you must use BackupServicePlan")]
        public bool IsEnable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The service plan of the backup")]
        public ServicePlan? BackupServicePlan { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                if (IsEnable)
                {
                    ProvisionBackup();
                }
                else
                {
                    DeprovisionBackup();
                }
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

            WriteObject(Server);
        }

        private void ProvisionBackup()
        {
            if (!BackupServicePlan.HasValue)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        new ArgumentException(
                            "The BackupServicePlan argument must be set when using Provision Backup"),
                        "-1",
                        ErrorCategory.InvalidArgument,
                        this));
                return;
            }
            var status = Connection.ApiClient.EnableBackup(Server.id, BackupServicePlan.Value).Result;
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

        private void DeprovisionBackup()
        {
            var status = Connection.ApiClient.DisableBackup(Server.id).Result;
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