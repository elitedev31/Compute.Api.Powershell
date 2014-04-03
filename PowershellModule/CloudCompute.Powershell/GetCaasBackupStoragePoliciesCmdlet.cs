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
    /// The get backup storage policies cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasBackupStoragePolicies")]
    [OutputType(typeof(BackupClientType[]))]
    public class GetCaasBackupStragePoliciesCmdlet : PSCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The server associated with the backup storage policies",
            ValueFromPipeline = true)]
        public ServersWithBackupServer Server { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var storagePolicies = GetBackupStoragePolicies();

                if (storagePolicies.Any())
                {
                    WriteObject(storagePolicies, true);
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
        /// Gets the storage policies
        /// </summary>
        /// <returns>The storage policies</returns>
        private IEnumerable<BackupStoragePolicy> GetBackupStoragePolicies()
        {
            return CaaS.ApiClient.GetBackupStoragePolicies(Server.id).Result;
        }
    }
}