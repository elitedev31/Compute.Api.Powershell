namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// The set server state cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServerState")]
    [OutputType(typeof(ServersWithBackupServer))]
    public class SetCaasServerActionCmdlet : Cmdlet
    {
        public enum ServerActions
        {
            PowerOff, PowerOn, Restart, Shutdown
        }

        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The server action to take")]
        public ServerActions ServerAction { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
        public ServersWithBackupServer Server { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            SetServerActionTask();
            WriteObject(Server);
        }

        /// <summary>
        /// Gets the network servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async void SetServerActionTask()
        {
            Status status = null;
            switch (ServerAction)
            {
                case ServerActions.PowerOff:
                    status = await CaaS.ApiClient.ServerPowerOff(Server.id);
                    break;
                case ServerActions.PowerOn:
                    status = await CaaS.ApiClient.ServerPowerOn(Server.id);
                    break;
                case ServerActions.Restart:
                    status = await CaaS.ApiClient.ServerRestart(Server.id);
                    break;
                case ServerActions.Shutdown:
                    status = await CaaS.ApiClient.ServerShutdown(Server.id);
                    break;
                default:
                    ThrowTerminatingError(new ErrorRecord(new NotImplementedException(), "-1", ErrorCategory.InvalidOperation, ServerAction));
                    break;
            }
            if (status != null)
                WriteDebug(string.Format("{0} resulted in {1} ({2}): {3}", status.operation, status.result, status.resultCode, status.resultDetail));
        }
    }
}