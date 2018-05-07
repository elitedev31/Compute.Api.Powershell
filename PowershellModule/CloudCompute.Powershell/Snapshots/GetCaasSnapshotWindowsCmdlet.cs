// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasDataCentreCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Get-CaasDataCentre cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Infrastructure;

    /// <summary>
    ///     The Get-CaasSnapshotWindows cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasSnapshotWindows")]
    [OutputType(typeof(SnapshotWindowType))]
    public class GetCaasSnapshotWindowsCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The data center Id")]
        public string DatacenterId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Service Plan")]
        public string ServicePlan { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The Snapshot Id")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The slots available")]
        public bool? SlotsAvailable { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WritePagedObject<SnapshotWindowType>(Connection.ApiClient.Infrastructure.GetSnapshotWindowPaginated(DatacenterId, ServicePlan, 
                    (ParameterSetName.Equals("Filtered")
                        ? new SnapshotWindowListOptions
                        {
                            Id = Id,
                            SlotsAvailable = SlotsAvailable.Value
                        } : null), PageableRequest).Result);
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
        }
    }
}