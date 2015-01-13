using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;


namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    /// The remove account cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasAccount", SupportsShouldProcess = true)]
    public class RemoveCaasAccountCmdlet:PsCmdletCaasBase
    {
        /// <summary>
        /// The username to be deleted
        /// </summary>
        [Parameter(Mandatory = true ,ValueFromPipelineByPropertyName = true, HelpMessage = "The account username to be deleted")]
        public string Username { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                if (!ShouldProcess(Username)) return;
                var status = Connection.ApiClient.DeleteSubAdministratorAccount(Username).Result;

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
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }
                        return true;
                    });
            }


        }
    }
}
