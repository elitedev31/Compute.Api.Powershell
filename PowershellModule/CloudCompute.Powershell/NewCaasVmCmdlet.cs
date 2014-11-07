namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using System.Collections.Generic;

    /// <summary>
    /// The new CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasVM")]
    [OutputType(typeof(CaasServerDetails))]
    public class NewCaasVmCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The Server Details that will be used to deploy the VM
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server details created by New-CaasServerDetails")]
        public CaasServerDetails ServerDetails { get; set; }
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                DeployServerTask();
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
            
            WriteObject(ServerDetails);
        }

        private void DeployServerTask()
        {

            var networkid = this.ServerDetails.Network != null ? this.ServerDetails.Network.id : null;

            // convert CaasServerDiskDetails to Disk[]
            Disk[] diskarray = null;
            if(ServerDetails.InternalDiskDetails!=null &&
                ServerDetails.InternalDiskDetails.Count>0)
            {
                List<Disk> disks = new List<Disk>();
                foreach (CaasServerDiskDetails item in ServerDetails.InternalDiskDetails)
	                    {
		                       var disk = 
                                   new Disk {
                                         scsiId = item.ScsiId,
                                           speed = item.SpeedId
                                   };
                                disks.Add(disk);
	                    }
                
            diskarray = disks.ToArray();
            }

            var status =
                CaaS.ApiClient.DeployServerWithDiskSpeedImageTask(
                    ServerDetails.Name,
                    ServerDetails.Description,
                    networkid,  
                    ServerDetails.PrivateIp,
                    ServerDetails.OsImage.id,
                    ServerDetails.AdministratorPassword,
                    ServerDetails.IsStarted,
                    diskarray
                  ).Result;

            if (status != null)
                WriteDebug(
                    string.Format(
                        "{0} resulted in {1} ({2}): {3}",
                        status.operation,
                        status.result,
                        status.resultCode,
                        status.resultDetail));
        }
    }
}