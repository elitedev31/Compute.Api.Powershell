namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The Re,pve CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasVM")]
    [OutputType(typeof(CaasServerDetails))]
    public class RemoveCaasVmCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// The Server Details that will be used to remove the VM
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to be removed.")]
        public ServerWithBackupType Server { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var status = CaaS.ApiClient.ServerDelete(Server.id).Result;

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