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
    /// The get backup storage policies cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasBackupStoragePolicies")]
    [OutputType(typeof(BackupStoragePolicy[]))]
    public class GetCaasBackupStragePoliciesCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The server associated with the backup storage policies",
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
                var resultlist = GetBackupStoragePolicies();

                if (resultlist!=null && resultlist.Any())
                {
                    switch (resultlist.Count())
                    {
                        case 0:
                            WriteError(
                                   new ErrorRecord(
                                       new ItemNotFoundException(
                                           "This command cannot find a matching object with the given parameters."
                                           ), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
                            break;
                        case 1:
                            WriteObject(resultlist.First());
                            break;
                        default:
                            WriteObject(resultlist, true);
                            break;
                    }
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