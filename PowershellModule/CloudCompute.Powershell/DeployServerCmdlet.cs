namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// The get network servers cmdlet.
    /// </summary>
    [Cmdlet("Deploy", "Server")]
    public class DeployServerCmdlet : Cmdlet
    {
        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The administrator password")]
        public string AdminPassword { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The machine name")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The description of the machine")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Will the machine be started after deployment (true|false)")]
        public bool IsStarted { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The OS Server Image to use for deployment")]
        public ServerImage OsServerImage { get; set; }

        /// <summary>
        /// The network to deploy the machine to
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to deploy the machine to")]
        public Guid Network { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            //var server = DeployServerTask().Result;
            WriteObject(true);
        }

        //private async Task<string> DeployServerTask()
        //{
        //    return
        //        await
        //        CaaS.ApiClient.DeployServerImageTask(
        //            Name,
        //            AdminPassword,
        //            Description,
        //            IsStarted,
        //            Network,
        //            Guid.Parse(OsServerImage.id));
        //}
    }
}