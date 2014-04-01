    using System.Management.Automation;
    using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell
{
    using System.Linq;

    /// <summary>
    /// The get networks cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasNetworks")]
    [OutputType(typeof(NetworkWithLocationsNetwork[]))]
    public class GetCaasNetworksCmdlet : PSCmdlet
    {
        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var networks = GetNetworksTask().Result;
            if (networks.Items.Any())
            {
                WriteObject(networks.Items, true);
            }
        }

        /// <summary>
        /// Gets the network servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async Task<NetworkWithLocations> GetNetworksTask()
        {
            return await CaaS.ApiClient.GetNetworksTask();
        }
    }
}