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
    [Cmdlet(VerbsCommon.New, "CaasConnection")]
    [OutputType(typeof(ComputeServiceConnection))]
    public class NewCaasConnectionCmdlet : PSCmdlet
    {
        /// <summary>
        ///	The credentials used to connect to the CaaS API.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCredential ApiCredentials { get; set; }

        /// <summary>
        /// Name for this connection
        /// </summary>
        [Parameter(Mandatory = false,HelpMessage = "Name to identify this connection")]
        public string Name { get; set; }


        /// <summary>
        /// The base uri of the REST API
        /// </summary>
        [Parameter(Mandatory = true,ParameterSetName = "ApiBaseUri", HelpMessage = "The base URI of the REST API")]
        public Uri ApiBaseUri { get; set; }

        /// <summary>
        /// The known vendor for the connection
        /// </summary>
        [Parameter(Mandatory = true,ParameterSetName = "KnownApiUri", HelpMessage = "A known cloud vendor for the Cloud API Uri. Not all vendor and region combinations are valid.")]
        public KnownApiVendor Vendor { get; set; }


        /// <summary>
        /// The known region for the connection
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "KnownApiUri", HelpMessage = "A known cloud region for the Cloud API Uri. Not all vendor and region combinations are valid.")]
        public KnownApiRegion Region { get; set; }


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
                    newCloudComputeConnection.Name = Name;
                    WriteDebug(String.Format("CaaS connection created successfully: {0}", newCloudComputeConnection));
                   
                    SessionState.AddComputeServiceConnection(newCloudComputeConnection);
                    WriteObject(newCloudComputeConnection);
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
            if(ParameterSetName=="ApiBaseUri")
                apiClient = new ComputeApiClient(ApiBaseUri);
            if(ParameterSetName=="KnownApiUri")
                apiClient = new ComputeApiClient(Vendor,Region);

         
            var newCloudComputeConnection = new ComputeServiceConnection(apiClient); ;

            WriteDebug("Trying to login into the CaaS");
            await newCloudComputeConnection.ApiClient.LoginAsync(ApiCredentials.GetNetworkCredential());

            return newCloudComputeConnection;
        }
    }
}