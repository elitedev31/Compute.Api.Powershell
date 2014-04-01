namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using System.Net.Http;
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
        private void SetServerActionTask()
        {
            try
            {
                Status status = null;
                switch (ServerAction)
                {
                    case ServerActions.PowerOff:
                        status = CaaS.ApiClient.ServerPowerOff(Server.id).Result;
                        break;
                    case ServerActions.PowerOn:
                        status = CaaS.ApiClient.ServerPowerOn(Server.id).Result;
                        break;
                    case ServerActions.Restart:
                        status = CaaS.ApiClient.ServerRestart(Server.id).Result;
                        break;
                    case ServerActions.Shutdown:
                        status = CaaS.ApiClient.ServerShutdown(Server.id).Result;
                        break;
                    default:
                        ThrowTerminatingError(
                            new ErrorRecord(
                                new NotImplementedException(),
                                "-1",
                                ErrorCategory.InvalidOperation,
                                ServerAction));
                        break;
                }
                if (status != null)
                    WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));
            }
            catch (HttpRequestException exception)
            {
                ThrowTerminatingError(new ErrorRecord(exception, "-1", ErrorCategory.InvalidOperation, CaaS));
            }
        }
    }
}