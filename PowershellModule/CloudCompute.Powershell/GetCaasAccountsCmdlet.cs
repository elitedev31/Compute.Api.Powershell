using DD.CBU.Compute.Api.Contracts.Datacenter;
using DD.CBU.Compute.Api.Contracts.Directory;

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;

    /// <summary>
    /// The Get-CaasDataCentre cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasAccounts")]
    [OutputType(typeof(AccountWithPhoneNumber[]))]
    public class GetCaasAccountsCmdlet : PsCmdletCaasBase
    {

        /// <summary>
        /// Get a CaaS network by name
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "Username to filter")]
        public string UserName { get; set; }

       



        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var resultlist = CaaS.ApiClient.GetAccounts().Result;

                if (resultlist!=null && resultlist.Any())
                {
                    if (!string.IsNullOrEmpty(UserName))
                        resultlist = resultlist.Where(item => String.Equals(item.UserName, UserName, StringComparison.CurrentCultureIgnoreCase));

                    switch (resultlist.Count())
                    {
                        case 0:
                            WriteError(
                                new ErrorRecord(
                                    new ItemNotFoundException(
                                        "This command cannot find a matching object with the given parameters."
                                        ), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
                            break;
                        case 1:
                            WriteObject(resultlist.First());
                            break;
                        default:
                            WriteObject(resultlist, true);
                            break;
                    }
                }
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