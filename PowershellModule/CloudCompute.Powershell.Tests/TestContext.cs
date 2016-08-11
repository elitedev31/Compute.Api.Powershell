using System;
using System.Management.Automation;

namespace DD.CBU.Compute.Powershell.Tests
{
    public class TestContext
    {
        /// <summary>
        ///     Gets or sets the Mock Api's setting file path.
        /// </summary>

        public string ApiMocksPath { get; set; }

        /// <summary>
        ///     Gets or sets the folder Path where the recorded api responses would be stored
        /// </summary>

        public string ApiRecordingPath { get; set; }

        /// <summary>
        ///     Gets or sets Flag specifying that in case the mock entry is not found, then should the proxy connect to the real api
        /// </summary>

        public bool FallbackToDefaultApi { get; set; }

        /// <summary>
        ///     Gets or sets Flag specifying that should the api proxy record the responses from the real api
        /// </summary>

        public bool RecordApiRequestResponse { get; set; }

        /// <summary>
        ///     Gets or sets the The real caas api to connect to in case the mock is missing
        /// </summary>

        public Uri DefaultApiAddress { get; set; }

        /// <summary>
        ///     The credentials used to connect to the CaaS API.
        /// </summary>		
        public PSCredential ApiCredentials { get; set; }

        public bool UseMockCredentials { get; set; }
    }
}
