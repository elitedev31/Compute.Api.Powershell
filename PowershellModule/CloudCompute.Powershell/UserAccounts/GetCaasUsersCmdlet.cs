// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasAccountsCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Get-CaasUser cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Directory;

    /// <summary>
    ///     The Get-CaasUser cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasUser")]
    [OutputType(typeof(AccountWithPhoneNumber))]
    public class GetCaasUsersCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Get a CaaS User Name
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Username to filter")]
        public string UserName { get; set; }


        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                WriteObject(Connection.ApiClient.Account.GetUser(UserName).Result);
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
                        else
                        {
                            // if (e is HttpRequestException)
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
        }
    }
}