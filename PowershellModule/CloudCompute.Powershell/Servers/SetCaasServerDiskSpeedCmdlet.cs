// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasServerDiskSpeedCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;
using DiskSpeedType = DD.CBU.Compute.Api.Contracts.Server.DiskSpeedType;

namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    ///     The set server state cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServerDiskSpeed")]
    public class SetCaasServerDiskSpeedCmdlet : PsCmdletCaasServerBase
    {
        /// <summary>
        ///     Gets or sets the scsi id.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Id of the disk to speed to be changed")]
        public string DiskId { get; set; }

        /// <summary>
        ///     Gets or sets the speed id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "SpeedId",
            HelpMessage =
                "The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed"
            )]
        public string SpeedId { get; set; }


        /// <summary>
        ///     Gets or sets the speed.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "DiskSpeedType", HelpMessage = "The disk speed")]
        public DiskSpeedType Speed { get; set; }


        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            SetServerTask();
            base.ProcessRecord();
        }

        /// <summary>
        ///     Edit the server disk details
        /// </summary>
        private void SetServerTask()
        {
            try
            {
                if (ParameterSetName.Equals("DiskSpeedType"))
                    SpeedId = Speed.ToString();

                Status status = null;
                status =
                    Connection.ApiClient.ServerManagementLegacy.Server.ChangeServerDiskSpeed(Server.id, DiskId, SpeedId)
                        .Result;

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