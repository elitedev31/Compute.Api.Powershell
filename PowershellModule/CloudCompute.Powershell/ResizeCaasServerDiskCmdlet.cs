namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The set server state cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Resize, "CaasServerDisk")]
    public class ResizeCaasServerDiskCmdlet : PsCmdletCaasBase
    {
        
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
        public ServerWithBackupType Server { get; set; }

         [Parameter(Mandatory = true, HelpMessage = "SCSI Id of the disk to be resized")]
        public int ScsiId { get; set; }

         [Parameter(Mandatory = true, HelpMessage = "New disk size in GB")]
         public int NewSizeInGB { get; set; }


        

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            SetServerTask();
        }

        /// <summary>
        /// Edit the server disk details
        /// </summary>
        private void SetServerTask()
        {
            try
            {
                Status status = null;

                var disk = Server.disk.Where(d => d.scsiId == ScsiId);
                if (disk.Any())
                {

                    status = CaaS.ApiClient.ChangeServerDiskSize(Server.id, disk.ElementAt(0).id, NewSizeInGB.ToString()).Result;

                }
                else
                    WriteError(new ErrorRecord(new PSArgumentException("The scsi id does not exits"), "-1", ErrorCategory.InvalidArgument, null));

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
                                WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, CaaS));
                            }
                            else //if (e is HttpRequestException)
                            {
                                ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, CaaS));
                            }
                            return true;
                        });
            }
        }
    }
}