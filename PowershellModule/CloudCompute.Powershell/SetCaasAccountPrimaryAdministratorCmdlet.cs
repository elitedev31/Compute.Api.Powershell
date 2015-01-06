using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Set, "CaasAccountPrimaryAdministrator")]
    public class SetCaasAccountPrimaryAdministrator : PsCmdletCaasBase
    {
        /// <summary>
        /// The account username to be primary administrator
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The account username to be primary administrator")]
        public string Username { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                var status = CaaS.ApiClient.DesignatePrimaryAdministratorAccount(Username).Result;

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
