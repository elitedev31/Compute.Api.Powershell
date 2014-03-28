namespace DD.CBU.Compute.Powershell
{
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// The get deployed server/s cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasDeployedServer")]
    [OutputType(typeof(ServersWithBackupServer[]))]
    public class GetCaasDeployedServerCmdlet : Cmdlet
    {
        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        [Parameter(HelpMessage = "The server ID to search for")]
        public string ServerId { get; set; }

        [Parameter(HelpMessage = "The search criteria that will be used to retrieve deployed servers")]
        public ServersWithBackupServer ServerSearchCriteria { get; set; }

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