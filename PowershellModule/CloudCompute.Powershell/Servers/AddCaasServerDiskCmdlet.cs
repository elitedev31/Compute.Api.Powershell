// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddCaasServerDiskCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual Machine cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using DiskSpeedType = Api.Contracts.Server.DiskSpeedType;

    /// <summary>
    ///     The new CAAS Virtual Machine CMDLET.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "CaasServerDisk")]
    public class AddCaasServerDiskCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the server.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "ServerType", HelpMessage = "The server to add the Disk", ValueFromPipeline = true)]
        public ServerType Server { get; set; }

        /// <summary>
        ///     Gets or sets the size in gb.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The new disk size")]
        public int SizeInGB { get; set; }

        /// <summary>
        ///     Gets or sets the speed id.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed")]
        public string SpeedId { get; set; }

        /// <summary>
        ///     Gets or sets the speed.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The disk speed to be created")]
        public DiskSpeedType Speed { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Scsi", HelpMessage = "The SCSI Controller Id")]
        public string ScsiControllerId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Scsi", HelpMessage = "The Scsi Id")]
        public int? ScsiId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "IDE", HelpMessage = "The IDE Controller Id")]
        public string IdeControllerId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "SATA", HelpMessage = "The SATA Controller Id")]
        public string SataControllerId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "SATA", HelpMessage = "The Sata Id")]
        public int? SataId { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ResponseType response = null;
            try
            {
                AddDiskType request = null;
                switch (ParameterSetName)
                {
                    case "ServerType":
                        request = new AddDiskType
                        {
                            sizeGb = SizeInGB,
                            speed = SpeedId,
                            ItemElementName = AddDiskItemChoiceType.serverId,
                            Item = Server.id,
                        };
                        break;
                    case "Scsi":
                        request = new AddDiskType
                        {
                            sizeGb = SizeInGB,
                            speed = SpeedId,
                            ItemElementName = AddDiskItemChoiceType.scsiController,
                            Item = new ScsiControllerType
                            {
                                controllerId = ScsiControllerId,
                                scsiId = ScsiId ?? 0,
                                scsiIdSpecified = ScsiId.HasValue
                            }
                        };
                        break;
                    case "IDE":
                        request = new AddDiskType
                        {
                            sizeGb = SizeInGB,
                            speed = SpeedId,
                            ItemElementName = AddDiskItemChoiceType.ideController,
                            Item = new IdeControllerType
                            {
                                controllerId = IdeControllerId
                            }
                        };
                        break;
                    case "SATA":
                        request = new AddDiskType
                        {
                            sizeGb = SizeInGB,
                            speed = SpeedId,
                            ItemElementName = AddDiskItemChoiceType.sataController,
                            Item = new SataControllerType
                            {
                                controllerId = SataControllerId,
                                sataId = SataId ?? 0,
                                sataIdSpecified = SataId.HasValue
                            }
                        };
                        break;
                }

                if (string.IsNullOrEmpty(SpeedId))
                {
                    SpeedId = Speed.ToString();
                }

                response =
                    Connection.ApiClient.ServerManagement.Server.AddDisk(request).Result;
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