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
    [Cmdlet(VerbsCommon.Add, "CaasServerDisk")]
    public class AddCaasServerDiskCmdlet : PsCmdletCaasServerBase
    {
        /// <summary>
        ///     Gets or sets the size in gb.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The new disk size")]
        public int SizeInGB { get; set; }

        /// <summary>
        ///     Gets or sets the speed id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "SpeedId", HelpMessage = "The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed")]
        public string SpeedId { get; set; }

        /// <summary>
        ///     Gets or sets the speed.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "DiskSpeedType", HelpMessage = "The disk speed to be created")]
        public DiskSpeedType Speed { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "ScsiId", HelpMessage = "The Scsi Id")]
        public int? ScsiId { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ResponseType response = null;
            try
            {
                if (ParameterSetName.Equals("DiskSpeedType"))
                {
                    SpeedId = Speed.ToString();
                }

                response =
                    Connection.ApiClient.ServerManagement.Server.AddDisk(
                        new AddDiskType
                        {
                            id = Server.id,
                            sizeGb = SizeInGB,
                            speed = Speed.ToString(),
                            scsiId = ScsiId ?? 0,
                            scsiIdSpecified = ScsiId.HasValue
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