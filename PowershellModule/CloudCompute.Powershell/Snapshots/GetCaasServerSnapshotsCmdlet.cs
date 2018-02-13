namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Snapshot;


    [Cmdlet(VerbsCommon.Get, "CaasSeverSnapshots")]
    [OutputType(typeof(SnapshotType))]
    public class GetCaasServerSnapshotsCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets snapshot id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The snapshot id")]
        public Guid SnapshotId { get; set; }

        /// <summary>
        ///     Gets or sets state.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The snapshot state")]
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets type.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The snapshot type")]
        public string SnapshotType { get; set; }

        /// <summary>
        ///     Gets or sets Server.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Server")]
        public ServerType Server { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Snapshot.GetSnapshotsPaginated(Guid.Parse(Server.id),
                    (ParameterSetName.Equals("Filtered")
                        ? new SnapshotListOptions
                        {
                            Id = SnapshotId != Guid.Empty ? SnapshotId : (Guid?)null,
                            Type = SnapshotType,
                            State = State
                        }
                        : null),
                         PageableRequest).Result);
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(
                                new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else
                        {
                            ThrowTerminatingError(
                                new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
        }
    }
}
