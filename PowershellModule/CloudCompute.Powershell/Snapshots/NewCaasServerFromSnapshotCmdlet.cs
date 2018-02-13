// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasServerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual Machine cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
    using Api.Contracts.Snapshot;

    /// <summary>
    ///     The new CaaS Virtual Machine from snapshot cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasServerFromSnapshot")]
    [OutputType(typeof(Api.Contracts.Network20.ServerType))]
    public class NewCaasServerFromSnapshotCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     The  snpashot server id.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Set the Snapshot Server Id")]
        public Guid SnapshotServerId { get; set; }

        /// <summary>
        ///     The  snapshot Id.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Set the snapshot Id")]
        public Guid SnapshotId { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Server Name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Server Description")]
        public string Description { get; set; }

        /// <summary>
        ///     The  Microsoft time zone for windows machine
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the destination cluster for the new CaaS Server")]
        public string ClusterId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is started.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Server to Started")]
        public bool IsStarted { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is started.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Nics to be Connected")]
        public bool NicsConnected { get; set; }

        /// <summary>
        ///     Switch to return the server object after execution
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the Server object after execution")]
        public SwitchParameter PassThru { get; set; }


        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var request = new CreateSnapshotPreviewServerType
                {
                    snapshotServerId = SnapshotServerId.ToString(),
                    snapshotId = SnapshotId.ToString(),
                    serverName = Name,
                    serverDescription = Description,
                    targetClusterId = ClusterId,
                    serverStarted = IsStarted,
                    nicsConnected = NicsConnected
                };

                response = Connection.ApiClient.Snapshot.CreateSnapshotPreviewServer(request).Result;
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