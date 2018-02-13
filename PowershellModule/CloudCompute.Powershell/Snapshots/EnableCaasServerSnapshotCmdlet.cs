using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The Enable Caas Server Snapshot CmdLet
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, "CaasServerSnapshot")]
    [OutputType(typeof(ResponseType))]
    public class EnableCaasServerSnapshotCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets Server.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Server")]
        public ServerType Server { get; set; }

        /// <summary>
        /// Gets or sets Service Plan
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Snapshot service plan")]
        public string ServicePlan { get; set; }

        /// <summary>
        /// Gets or sets Snapshot Window
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Snapshot Window Id")]
        public Guid SnapshotWindowId { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var snapshotType = new EnableSnapshotServiceType
                {
                    serverId = Server.id,
                    servicePlan = ServicePlan,
                    windowId = SnapshotWindowId.ToString(),
                    initiateManualSnapshot = false
                };

                response = Connection.ApiClient.ServerManagement.Server.EnableSnapshotService(snapshotType).Result;
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
                        else
                        {
                            // if (e is HttpRequestException)
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }

            WriteObject(response);
        }
    }
}