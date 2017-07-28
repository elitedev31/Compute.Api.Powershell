// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddCaasServerDiskCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual Machine cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
    using DD.CBU.Compute.Api.Contracts.Network20;

    using DiskSpeedType = DD.CBU.Compute.Api.Contracts.Server.DiskSpeedType;

    /// <summary>
    ///     The new CAAS Virtual Machine CMDLET.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "CaasServerScsiController")]
    public class AddCaasServerScsiControllerCmdlet : PsCmdletCaasServerBase
    {

        /// <summary>
        ///     Gets or sets the speed id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "SpeedId", HelpMessage = "The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed")]
        public string AdapterType { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = "BusNumber", HelpMessage = "The Scsi Controller Bus Number")]
        public int? BusNumber { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ResponseType response = null;
            try
            {
                response =
                    Connection.ApiClient.ServerManagement.Server.AddScsiController(
                        new AddScsiControllerType
                        {
                            serverId = Server.id,
                            adapterType = AdapterType,
                            busNumber = BusNumber.Value,
                            busNumberSpecified = BusNumber.HasValue
                        }).Result;
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