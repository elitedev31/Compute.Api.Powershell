using System;
using System.Management.Automation;
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
            
			WriteDebug("Trying to login to the REST API");
			ComputeServiceConnection newCloudComputeConnection = LoginTask().Result;
            if (newCloudComputeConnection != null)
            {
                WriteDebug(
					String.Format(
						"CaaS connection created successfully: {0}",
						newCloudComputeConnection
					)
				);

	            SessionState.AddComputeServiceConnection(newCloudComputeConnection);
                WriteObject(newCloudComputeConnection);
            }
        }

        /// <summary>
        /// Try to login into the account using the credentials.
        /// If succeed, it will return the account details.
        /// </summary>
        /// <returns>The CaaS connection</returns>
        private async Task<ComputeServiceConnection> LoginTask()
        {
            // Login to the CaaS REST API
            var caas = new ComputeServiceConnection(new ComputeApiClient(ApiBaseUri));
            WriteDebug("CaaS object created");

            await caas.ApiClient.LoginAsync(ApiCredentials.GetNetworkCredential());

            return caas;
        }
    }
}