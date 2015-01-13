using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using System.Linq;
    using DD.CBU.Compute.Api.Client;
    using System.Collections.Generic;

    /// <summary>
    /// The new CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasServer")]
    
    [OutputType(typeof(ServerWithBackupType))]
    public class NewCaasServerCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The Server Details that will be used to deploy the VM
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server details created by New-CaasServerDetails")]
        public CaasServerDetails ServerDetails { get; set; }

        /// <summary>
        /// Switch to return the server object after execution
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the Server object after execution")]
        public SwitchParameter PassThru { get; set; }



        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ServerWithBackupType server = null;
            base.ProcessRecord();
            try
            {
                server = DeployServerTask();
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
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }
                        return true;
                    });
            }
            if(PassThru.IsPresent)
                WriteObject(server);
        }

        private ServerWithBackupType DeployServerTask()
        {
            ServerWithBackupType server = null;
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
                Connection.ApiClient.DeployServerWithDiskSpeedImageTask(
                    ServerDetails.Name,
                    ServerDetails.Description,
                    networkid,  
                    ServerDetails.PrivateIp,
                    ServerDetails.Image.id,
                    ServerDetails.AdministratorPassword,
                    ServerDetails.IsStarted,
                    diskarray
                  ).Result;
            //get the server id from status message
        
		    var statusadditionalInfo = status.additionalInformation.Single(info => info.name == "serverId");
            if (statusadditionalInfo != null)
            {
                var servers = Connection.ApiClient.GetDeployedServers(statusadditionalInfo.value,null,null,null).Result;
                   if (servers.Any())
                   {
                       server = servers.First();
                   
                   } 
            
            }

            if (status != null)
                WriteDebug(
                    string.Format(
                        "{0} resulted in {1} ({2}): {3}",
                        status.operation,
                        status.result,
                        status.resultCode,
                        status.resultDetail));
            return server;

        }
    }
}