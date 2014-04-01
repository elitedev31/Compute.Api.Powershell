    using System;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell
{
    using Api.Client;

    /// <summary>
    ///		The "New-CaasConnection" Cmdlet.
    /// </summary>
    /// <remarks>
    ///		Used to create a new connection to the CaaS API.
    /// </remarks>
    [Cmdlet(VerbsCommon.New, "CaasConnection", SupportsShouldProcess = true)]
    [OutputType(typeof(ComputeServiceConnection))]
    public class NewCaasConnectionCmdlet : PSCmdlet
    {
        /// <summary>
        ///		The credentials used to connect to the CaaS API.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCredential ApiCredentials { get; set; }

        /// <summary>
        /// The base uri of the REST API
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The base URI of the REST API")]
        public Uri ApiBaseUri { get; set; }

        /// <summary>
        /// Process the record
        /// </summary>
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
                    WriteDebug(String.Format("CaaS connection created successfully: {0}", newCloudComputeConnection));

                    SessionState.AddComputeServiceConnection(newCloudComputeConnection);
                    WriteObject(newCloudComputeConnection);
                }
            }
            catch (Exception exception)
            {
                ThrowTerminatingError(new ErrorRecord(exception, "-1", ErrorCategory.InvalidOperation, newCloudComputeConnection));
            }
        }

        /// <summary>
        /// Try to login into the account using the credentials.
        /// If succeed, it will return the account details.
        /// </summary>
        /// <returns>The CaaS connection</returns>
        private async Task<ComputeServiceConnection> LoginTask()
        {
            var newCloudComputeConnection = new ComputeServiceConnection(new ComputeApiClient(ApiBaseUri)); ;

            WriteDebug("Trying to login into the CaaS");
            await newCloudComputeConnection.ApiClient.LoginAsync(ApiCredentials.GetNetworkCredential());

            return newCloudComputeConnection;
        }
    }
}