using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Directory;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
     [Cmdlet(VerbsCommon.Set, "CaasAccount")]
    public class SetCaasAccountCmdlet:PsCmdletCaasBase
    {
         [Parameter(Mandatory = true, HelpMessage = "The account username to be updated",ValueFromPipeline = true)]
        public string Username { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The account full name")]
        public string FullName { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "The account first name")]
        public string FirstName { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "The account last name")]
        public string LastName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The account password")]
        public SecureString Password { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The account email address")]
        public string EmailAddress { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "The account department")]
        public string Department { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The account phone country code address")]
        public string PhoneCountryCode { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "The account phone number")]
        public string PhoneNumber { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "The account custom defined field 1")]
        public string CustomDefined1 { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The account custom defined field 2")]
        public string CustomDefined2 { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The roles for this account, use the cmdlet New-CaasAccountRoles to create the values")]
        public Role[] Roles { get; set; }


        /// <summary>
        /// Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var roles = new List<Role>();
                if(Roles !=null)
                    roles.AddRange(Roles);

                var account = new AccountWithPhoneNumber
                {
                    userName = Username,
                    fullName = FullName,
                    firstName = FirstName,
                    lastName = LastName,
                    emailAddress = EmailAddress,
                    department = Department,
                    phoneCountryCode = PhoneCountryCode,
                    phoneNumber = PhoneNumber,
                    customDefined1 = CustomDefined1,
                    customDefined2 = CustomDefined2,
                    MemberOfRoles = roles

                };
                if (Password != null)
                    account.password = Password.ToPlainString();

                var status = CaaS.ApiClient.UpdateAdministratorAccount(account).Result;
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
