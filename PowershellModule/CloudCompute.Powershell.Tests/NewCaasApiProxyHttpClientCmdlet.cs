using System;
using System.Management.Automation;
using System.Net.Http;

namespace DD.CBU.Compute.Powershell.Tests
{   
    /// <summary>
    ///     The new caas Api Proxy Http Client.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasApiProxyHttpClient")]
    [OutputType(typeof(HttpClient))]
    public class NewCaasApiProxyHttpClientCmdlet : PSCmdlet
    {
        /// <summary>
        ///     Gets or sets the Mock Api's setting file path.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Mock Api's setting file path")]
        public string ApiMocksPath { get; set; }

        /// <summary>
        ///     Gets or sets the folder Path where the recorded api responses would be stored
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Folder Path where the recorded api responses would be stored")]
        public string ApiRecordingPath { get; set; }

        /// <summary>
        ///     Gets or sets Flag specifying that in case the mock entry is not found, then should the proxy connect to the real api
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "In case the mock entry is not found, then should the proxy connect to the real api")]
        public bool FallbackToDefaultApi { get; set; }
        
        /// <summary>
        ///     Gets or sets Flag specifying that should the api proxy record the responses from the real api
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Should the api proxy record the responses from the real api")]
        public bool RecordApiRequestResponse { get; set; }
        
        /// <summary>
        ///     Gets or sets the The real caas api to connect to in case the mock is missing
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The real caas api to connect to in case the mock is missing")]
        public Uri DefaultApiAddress { get; set; }

        /// <summary>
		///     The credentials used to connect to the CaaS API.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "In case you are connecting to the real api, provide the real credentials")]
        public PSCredential ApiCredentials { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            HttpClient response = null;
            base.ProcessRecord();          
            try
            {
                var configuration = new ApiProxy.ApiProxyHttpClient.ApiProxyConfiguration()
                {
                    ApiMocksPath = ApiMocksPath,
                    ApiRecordingPath = ApiRecordingPath,
                    FallbackToDefaultApi = FallbackToDefaultApi,
                    RecordApiRequestResponse = RecordApiRequestResponse,
                    DefaultApiAddress = DefaultApiAddress
                };
                response = ApiProxy.ApiProxyHttpClient.HttpClientFactory.GetHttpClient(configuration,
                    ApiCredentials?.GetNetworkCredential());
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, new object()));
                        return true;
                    });
            }

            WriteObject(response);
        }
    }
}