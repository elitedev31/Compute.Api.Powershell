namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Backup;

    /// <summary>
    /// The get backup client types cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasBackupClients")]
    [OutputType(typeof(BackupClientDetailsType[]))]
    public class GetCaasBackupClientsCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The server associated with the backup client types",
            ValueFromPipeline = true)]
        public ServerWithBackupType Server { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var clients = GetBackupClients();

                if (clients != null && clients.Any())
                {
                    WriteObject(clients, true);
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
        }

        /// <summary>
        /// Gets the backup clients
        /// </summary>
        /// <returns>The backup clients</returns>
        private IEnumerable<BackupClientDetailsType> GetBackupClients()
        {
            return CaaS.ApiClient.GetBackupClients(Server.id).Result;
        }
    }
}