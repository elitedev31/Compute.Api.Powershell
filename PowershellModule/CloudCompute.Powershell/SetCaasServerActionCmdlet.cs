using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The set server state cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServerState")]
    public class SetCaasServerActionCmdlet : PsCmdletCaasServerBase
    {
        public enum ServerAction
        {
            PowerOff, PowerOn, Restart, Shutdown
        }

        [Parameter(Mandatory = true, HelpMessage = "The server action to take")]
        public ServerAction Action { get; set; }

       
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            SetServerActionTask();
            base.ProcessRecord();

        }

        /// <summary>
        /// Sets the state of the server
        /// </summary>
        private void SetServerActionTask()
        {
            try
            {
                Status status = null;
                switch (Action)
                {
                    case ServerAction.PowerOff:
                        status = Connection.ApiClient.ServerPowerOff(Server.id).Result;
                        break;
                    case ServerAction.PowerOn:
                        status = Connection.ApiClient.ServerPowerOn(Server.id).Result;
                        break;
                    case ServerAction.Restart:
                        status = Connection.ApiClient.ServerRestart(Server.id).Result;
                        break;
                    case ServerAction.Shutdown:
                        status = Connection.ApiClient.ServerShutdown(Server.id).Result;
                        break;
                    default:
                        ThrowTerminatingError(
                            new ErrorRecord(
                                new NotImplementedException(),
                                "-1",
                                ErrorCategory.InvalidOperation,
                                Action));
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
                                WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                            }
                            else //if (e is HttpRequestException)
                            {
                                ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                            }
                            return true;
                        });
            }
        }
    }
}