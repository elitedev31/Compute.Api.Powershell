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
    /// The get backup schedule policies cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasBackupSchedulePolicies")]
    [OutputType(typeof(BackupSchedulePolicy[]))]
    public class GetCaasBackupSchedulePoliciesCmdlet : PSCmdletCaasBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The server associated with the backup schedule policies",
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
                var schedulePolicies = GetBackupSchedulePolicies();

                if (schedulePolicies.Any())
                {
                    WriteObject(schedulePolicies, true);
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
        /// Gets the schedule policies
        /// </summary>
        /// <returns>The schedule policies</returns>
        private IEnumerable<BackupSchedulePolicy> GetBackupSchedulePolicies()
        {
            return CaaS.ApiClient.GetBackupSchedulePolicies(Server.id).Result;
        }
    }
}