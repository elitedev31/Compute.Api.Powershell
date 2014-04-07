namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The set server state cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServerState")]
    [OutputType(typeof(ServersWithBackupServer))]
    public class SetCaasServerActionCmdlet : PSCmdletCaasBase
    {
        public enum ServerActions
        {
            PowerOff, PowerOn, Restart, Shutdown
        }

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
        /// Sets the state of the server
        /// </summary>
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
    }
}