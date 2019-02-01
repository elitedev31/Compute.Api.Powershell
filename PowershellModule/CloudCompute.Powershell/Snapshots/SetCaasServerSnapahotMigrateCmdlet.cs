namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Snapshot;

    /// <summary>
    ///     The set server snapshot migrate cmdlet.
    /// </summary>
    [Cmdlet("Set", "CaasServerSnapshotMigrate")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasServerSnapahotMigrateCmdlet : PsCmdletCaasServerBase
    {
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                response = Connection.ApiClient.Snapshot.MigrateSnapshotPreviewServer(new MigrateSnapshotPreviewServerType { serverId = Server.id }).Result;
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