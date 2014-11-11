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
    [Cmdlet(VerbsCommon.Add, "CaasServerDisk")]
 

    public class AddCaasServerDiskCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The Server Details that will be used to deploy the VM
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server details created by New-CaasServerDetails")]
        public ServerWithBackupType Server { get; set; }


        
        [Parameter(Mandatory = true, HelpMessage = "The new disk size")]
        public int SizeInGB { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "The speedId of the new disk. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.diskSpeed")]
        public string SpeedId { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {

            base.ProcessRecord();
            try
            {
                var status = CaaS.ApiClient.AddServerDisk(Server.id, SizeInGB.ToString(),SpeedId).Result;
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