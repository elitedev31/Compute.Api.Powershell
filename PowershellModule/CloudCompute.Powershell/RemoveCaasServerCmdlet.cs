namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The Re,pve CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasServer")]
    public class RemoveCaasServerCmdlet : PsCmdletCaasServerBase
    {
      


     
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {


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
            base.ProcessRecord();
        }
    }
}