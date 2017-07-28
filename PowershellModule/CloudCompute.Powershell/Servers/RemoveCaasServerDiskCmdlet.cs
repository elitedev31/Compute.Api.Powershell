// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasServerDiskCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Remove, "CaasServerDisk", SupportsShouldProcess = true)]
    public class RemoveCaasServerDiskCmdlet : PsCmdletCaasServerBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "With_SCSIId", HelpMessage = "SCSI Id of the disk to be resized")]
        public int ScsiId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_DiskId", HelpMessage = "The id of Disk")]
        public string Id { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                switch (ParameterSetName)
                {
                    case "With_DiskId":
                        break;
                    default:
                        if (!ShouldProcess(string.Concat("Disk SCSI Id", ScsiId.ToString(CultureInfo.InvariantCulture))))
                        {
                            return;
                        }

                        if (Server.disk.Any(d => d.scsiId == ScsiId))
                        {
                            Id = Server.disk.First(d => d.scsiId == ScsiId).id;
                        }

                        break;
                }

                if (!ShouldProcess(string.Concat("Disk Id", Id.ToString(CultureInfo.InvariantCulture))))
                {
                    return;
                }

                WriteObject(Connection.ApiClient.ServerManagement.Server.RemoveDisk(new RemoveDiskType { id = Id }).Result);
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
                                ThrowTerminatingError(
                                    new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                            }

                            return true;
                        });
            }
        }
    }
}
