namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The get deployed server/s cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasDeployedServer")]
    [OutputType(typeof(ServersWithBackupServer[]))]
    public class GetCaasDeployedServerCmdlet : PSCmdletCaasBase
    {
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var servers = this.GetDeployedServers().Result;
                if (servers.Items.Any())
                {
                    WriteObject(servers.Items, true);
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
        /// Gets the deployed servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async Task<ServersWithBackup> GetDeployedServers()
        {
            return await CaaS.ApiClient.GetDeployedServers();
        }
    }
}