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
    /// The get backup client types cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasBackupClientTypes")]
    [OutputType(typeof(BackupClientType[]))]
    public class GetCaasBackupClientTypesCmdlet : PsCmdletCaasBase
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
                var clientTypes = GetBackupClientTypes();

                if (clientTypes.Any())
                {
                    WriteObject(clientTypes, true);
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
        /// Gets the network servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private IEnumerable<BackupClientType> GetBackupClientTypes()
        {
            return CaaS.ApiClient.GetBackupClientTypes(Server.id).Result;
        }
    }
}