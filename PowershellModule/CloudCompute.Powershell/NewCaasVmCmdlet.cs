namespace DD.CBU.Compute.Powershell
{
    using System.Management.Automation;

    /// <summary>
    /// The new CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasVM")]
    [OutputType(typeof(CaasServerDetails))]
    public class NewCaasVmCmdlet : Cmdlet
    {
        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        /// <summary>
        /// The Server Details that will be used to deploy the VM
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server details created by New-CaasServerDetails")]
        public CaasServerDetails ServerDetails { get; set; }
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            DeployServerTask();
            
            WriteObject(ServerDetails);
        }

        private async void DeployServerTask()
        {
            var status =
                await
                CaaS.ApiClient.DeployServerImageTask(
                    ServerDetails.Name,
                    ServerDetails.Description,
                    ServerDetails.Network.id,
                    ServerDetails.OsImage.id,
                    ServerDetails.AdministratorPassword,
                    ServerDetails.IsStarted);

            if (status != null)
                WriteDebug(string.Format("{0} resulted in {1} ({2}): {3}", status.operation, status.result, status.resultCode, status.resultDetail));
        }
    }
}