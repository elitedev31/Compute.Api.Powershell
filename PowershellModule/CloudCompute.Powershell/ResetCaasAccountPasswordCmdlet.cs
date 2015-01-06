using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Directory;
using DD.CBU.Compute.Api.Contracts.General;


namespace DD.CBU.Compute.Powershell
{
     [Cmdlet(VerbsCommon.Reset, "CaasAccountPassword")]
    public class ResetCaasAccountPasswordCmdlet:PSCmdlet
    {

        /// <summary>
        ///	The credentials used to connect to the CaaS API.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCredential ApiCredentials { get; set; }


     
        /// <summary>
        /// The base uri of the REST API
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "ApiBaseUri", HelpMessage = "The base URI of the REST API")]
        public Uri ApiBaseUri { get; set; }

        /// <summary>
        /// The known vendor for the connection
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "KnownApiUri", HelpMessage = "A known cloud vendor for the Cloud API Uri. Not all vendor and region combinations are valid.")]
        public KnownApiVendor Vendor { get; set; }


        /// <summary>
        /// The known region for the connection
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "KnownApiUri", HelpMessage = "A known cloud region for the Cloud API Uri. Not all vendor and region combinations are valid.")]
        public KnownApiRegion Region { get; set; }

        [Parameter(Mandatory = false)]
        public SecureString NewPassword { private get; set; }

         protected override void BeginProcessing()
         {
             base.BeginProcessing();
             
            
             if (NewPassword == null)
             {
                 var psobj = this.InvokeCommand.InvokeScript("Read-Host 'Enter your new password:' -AsSecureString");
                 if (psobj.Count > 0)
                     NewPassword = psobj[0].BaseObject as SecureString;
             }
         }

         protected override void ProcessRecord()
         {
             base.ProcessRecord();

             ComputeServiceConnection newCloudComputeConnection = null;

             WriteDebug("Trying to login to the REST API");
             try
             {
                 newCloudComputeConnection = LoginTask().Result;
                 if (newCloudComputeConnection != null)
                 {
                     var status = ResetPasswordTask(newCloudComputeConnection).Result;

                 }
             }
             catch (AggregateException ae)
             {
                 ae.Handle(
                     e =>
                     {
                         ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.AuthenticationError, newCloudComputeConnection));
                         return true;
                     });
             }

         }


        

         /// <summary>
         /// Try to login into the account using the credentials.
         /// If succeed, it will return the account details.
         /// </summary>
         /// <returns>The CaaS connection</returns>
         private async Task<ComputeServiceConnection> LoginTask()
         {
             ComputeApiClient apiClient = null;
             if (ParameterSetName == "ApiBaseUri")
                 apiClient = new ComputeApiClient(ApiBaseUri);
             if (ParameterSetName == "KnownApiUri")
                 apiClient = new ComputeApiClient(Vendor, Region);


             var newCloudComputeConnection = new ComputeServiceConnection(apiClient); ;

             WriteDebug("Trying to login into the CaaS");
             await newCloudComputeConnection.ApiClient.LoginAsync(ApiCredentials.GetNetworkCredential());

             return newCloudComputeConnection;
         }

         /// <summary>
         /// Try to login into the account using the credentials.
         /// If succeed, it will return the account details.
         /// </summary>
         /// <returns>The CaaS connection</returns>
         private async Task<Status> ResetPasswordTask(ComputeServiceConnection connection)
         {

             var account = new AccountWithPhoneNumber
             {
                 userName = connection.Account.UserName,
                 password = NewPassword.ToPlainString()
             };

             return await connection.ApiClient.UpdateAdministratorAccount(account);
              
          }
    }
}
