namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The get networks cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasNetworks")]
    [OutputType(typeof(NetworkWithLocationsNetwork[]))]
    public class GetCaasNetworksCmdlet : PSCmdletCaasBase
    {
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var networks = GetNetworksTask().Result;

                if (networks.Any())
                {
                    WriteObject(networks, true);
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
        private async Task<IEnumerable<NetworkWithLocationsNetwork>> GetNetworksTask()
        {
            return await CaaS.ApiClient.GetNetworksTask();
        }
    }
}