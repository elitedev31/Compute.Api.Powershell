namespace DD.CBU.Compute.Powershell
{
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// The get CaaS OS Images cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasOsImages")]
    public class GetCaasOsImagesCmdlet : Cmdlet
    {
        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        /// <summary>
        /// The network to show the images from
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to show the images from")]
        public NetworkWithLocationsNetwork NetworkWithLocations { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var servers = GetOsImagesTask().Result;
            if (servers.Items.Length > 0)
            {
                WriteObject(servers.Items, true);
            }
        }

        /// <summary>
        /// Gets the network servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async Task<DeployedImagesWithSoftwareLabels> GetOsImagesTask()
        {
            return await CaaS.ApiClient.GetOsServerImagesTask(NetworkWithLocations.location);
        }
    }
}