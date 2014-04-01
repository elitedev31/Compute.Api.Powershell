namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The new CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasVM")]
    [OutputType(typeof(CaasServerDetails))]
    public class NewCaasVmCmdlet : PSCmdletCaasBase
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

        private async void DeployServerTask()
        {
            var status =
                await
                CaaS.ApiClient.DeployServerImageTask(
                    ServerDetails.Name,
                    ServerDetails.Description,
                    ServerDetails.Network.id,
                    ServerDetails.OsImage.id,
                    ServerDetails.AdministratorPassword,
                    ServerDetails.IsStarted);

            if (status != null)
                WriteDebug(string.Format("{0} resulted in {1} ({2}): {3}", status.operation, status.result, status.resultCode, status.resultDetail));
        }
    }
}