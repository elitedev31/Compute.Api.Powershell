namespace DD.CBU.Compute.Powershell
{
    using System.Management.Automation;
    using System.Collections.Generic;

    /// <summary>
    /// The new CaaS Server Details cmdlet.
    /// This will be used to deploy a new VM.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServerDiskDetails")]
    [OutputType(typeof(CaasServerDetails))]
    public class SetCaasServerDiskDetailsCmdlet : Cmdlet
    {
        /// <summary>
        /// The VM name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The server details created by New-CaasServerDetails")]
        public CaasServerDetails ServerDetails { get; set; }

        /// <summary>
        /// SCSI ID from the OS or customer image
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "SCSI ID from the OS or customer image")]
        public string ScsiId { get; set; }

        /// <summary>
        /// The speed of the disk 
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed")]
        public string SpeedId { get; set; }


        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (ServerDetails == null)
            {
                ThrowTerminatingError(new ErrorRecord(new PSArgumentException("The ServerDetails parameter cannot be empty"), "-1", ErrorCategory.InvalidArgument, null));
            }

            if (ServerDetails.InternalDiskDetails == null)
                ServerDetails.InternalDiskDetails = new List<CaasServerDiskDetails>();

            var diskdetails = ServerDetails.InternalDiskDetails.Find(disk => disk.ScsiId == this.ScsiId);
            if (diskdetails == null)
            {
                diskdetails =
               new CaasServerDiskDetails
               {
                   ScsiId = ScsiId,
                   SpeedId = SpeedId
               };
                ServerDetails.InternalDiskDetails.Add(diskdetails);
            }
            else
              diskdetails.SpeedId = SpeedId;
  
               


            WriteObject(ServerDetails);

        }
    }
}