namespace DD.CBU.Compute.Powershell
{
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// The get deployed servers cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasDeployedServers")]
    public class GetCaasDeployedServersCmdlet : Cmdlet
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

            var servers = GetNetworksTask().Result;
            if (servers.Items.Length > 0)
            {
                WriteObject(servers.Items, true);
            }
        }

        /// <summary>
        /// Gets the network servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async Task<ServersWithBackup> GetNetworksTask()
        {
            return await CaaS.ApiClient.GetDeployedServers();
        }
    }
}