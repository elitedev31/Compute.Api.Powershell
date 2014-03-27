namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// The set server state cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServerState")]
    public class SetCaasServerActionCmdlet : Cmdlet
    {
        public enum ServerActions
        {
            PowerOff, PowerOn, Restart, Shutdown
        }

        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The server action to take")]
        public ServerActions ServerAction { get; set; }

        public ServersWithBackupServer Server { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var status = SetServerActionTask().Result;
            if (status != null)
            {
                WriteObject(status);
            }
        }

        /// <summary>
        /// Gets the network servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async Task<Status> SetServerActionTask()
        {
            switch (ServerAction)
            {
                case ServerActions.PowerOff:
                    return await CaaS.ApiClient.ServerPowerOff(Server.id);
                case ServerActions.PowerOn:
                    return await CaaS.ApiClient.ServerPowerOn(Server.id);
                case ServerActions.Restart:
                    return await CaaS.ApiClient.ServerRestart(Server.id);
                case ServerActions.Shutdown:
                    return await CaaS.ApiClient.ServerShutdown(Server.id);
                default:
                    throw new NotSupportedException("The server action is not supported by this cmdlet");
            }
        }
    }
}