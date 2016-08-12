using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Tests
{
    /// <summary>
    ///     The new caas Api Proxy Http Client.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasTestContext")]
    [OutputType(typeof(TestContext))]
    public class NewCaasTestContextCmdlet : PSCmdletCaasBase
    { /// <summary>
      ///     Gets or sets the Mock Api's setting file path.
      /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Mock Api's setting file path")]
        public string MockApisPath { get; set; }
       
        /// <summary>
        ///     Gets or sets the folder Path where the recorded api responses would be stored
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Folder Path where the recorded api responses would be stored")]
        public string MockApisRecordingPath { get; set; }

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

        [Parameter(Mandatory = false)]
        public bool UseMockCredentials { get; set; }

        [Parameter(Mandatory = true)]
        public Guid CaaSClientId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            var context = new TestContext
            {
                ApiMocksPath = MockApisPath,
                ApiRecordingPath = MockApisRecordingPath,
                FallbackToDefaultApi = FallbackToDefaultApi,
                RecordApiRequestResponse = RecordApiRequestResponse,
                DefaultApiAddress = DefaultApiAddress,
                ApiCredentials = ApiCredentials,
                UseMockCredentials = UseMockCredentials,
                CaaSClientId = CaaSClientId
            };
            WriteObject(context);
        }
    }
}
