// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasConnectionCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The "New-CaasConnection" Cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Management.Automation;
using System.Net.FtpClient;
using System.Net.Http;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.WebApi;
using System.Net;

namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    ///     The "New-CaasConnection" Cmdlet.
    /// </summary>
    /// <remarks>
    ///     Used to create a new connection to the CaaS API.
    /// </remarks>
    [Cmdlet(VerbsCommon.New, "CaasConnection")]
    [OutputType(typeof(ComputeServiceConnection))]
    public class NewCaasConnectionCmdlet : PSCmdletCaasBase
    {
        /// <summary>
        ///     The credentials used to connect to the CaaS API.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCredential ApiCredentials { get; set; }

        /// <summary>
        ///     Name for this connection
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Name to identify this connection")]
        public string Name { get; set; }

        /// <summary>
        ///     The known vendor for the connection
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "KnownApiUri",
            HelpMessage = "A known cloud vendor for the Cloud API Uri. Not all vendor and region combinations are valid.")]
        [PSDefaultValue(Help = "Dimension Data is the default value", Value = KnownApiVendor.DimensionData)]
        public KnownApiVendor Vendor { get; set; }


        /// <summary>
        ///     The known region for the connection
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "KnownApiUri",
            HelpMessage = "A known cloud region for the Cloud API Uri. Not all vendor and region combinations are valid.")]
        public KnownApiRegion Region { get; set; }

        /// <summary>
        ///     The base uri of the REST API
        /// </summary>		
        [Parameter(Mandatory = true, ParameterSetName = "ApiDomainName", HelpMessage = "The domain name for the REST API")]
        public string ApiDomainName { get; set; }

        /// <summary>
		///     The base uri of the FTP domain
		/// </summary>		
		[Parameter(Mandatory = false, ParameterSetName = "ApiDomainName", HelpMessage = "The domain name for the FTP, default is the api domain name")]
        public string FtpDomainName { get; set; }

        /// <summary>
        ///     The base uri of the REST API
        /// </summary>        
        [Parameter(Mandatory = true, ParameterSetName = "HttpClient",
            HelpMessage = "The http client which will handle the api requests")]
        public HttpClient HttpClient { get; set; }

        /// <summary>
        ///     HTTP trace log file path
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "File path to log all the HTTP trace")]
        public string LogFilePath { get; set; }

        /// <summary>
        ///     Process the record
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ComputeServiceConnection newCloudComputeConnection = null;
            var connectionName = string.IsNullOrEmpty(Name) ? Guid.NewGuid().ToString() : Name;

            WriteDebug("Trying to login to the REST API");
            try
            {
                newCloudComputeConnection = LoginTask(connectionName).Result;
                if (newCloudComputeConnection != null)
                {
                    WriteDebug(string.Format("CaaS connection created successfully: {0}", newCloudComputeConnection));
                    if (string.IsNullOrEmpty(Name))
                    {
                        Name = connectionName;
                        WriteWarning(
                            string.Format("Connection name not specified. Therefore this connection name will be a random GUID: {0}", Name));
                    }

                    if (!SessionState.GetComputeServiceConnections().Any())
                        WriteDebug("This is the first connection and will be the default connection.");
                    SessionState.AddComputeServiceConnection(Name, newCloudComputeConnection);
                    if (SessionState.GetComputeServiceConnections().Count > 1)
                        WriteWarning(
                            "You have created more than one connection on this session, please use the cmdlet Set-CaasActiveConnection -Name <name> to change the active/default connection");

                    SessionState.AddComputeServiceConnection(Name, newCloudComputeConnection);
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
        ///     Try to login into the account using the credentials.
        ///     If succeed, it will return the account details.
        /// </summary>
        /// <returns>
        ///     The CaaS connection
        /// </returns>
        private async Task<ComputeServiceConnection> LoginTask(string connectionName)
        {
            string ftpHost = string.Empty;
            IComputeApiClient apiClient = null;

            if (ParameterSetName == "KnownApiUri")
            {
                var baseUri = KnownApiUri.Instance.GetBaseUri(Vendor, Region);
                apiClient = GetComputeApiClient(baseUri, ApiCredentials.GetNetworkCredential(), LogFilePath, connectionName);
                ftpHost = ComputeApiClient.GetFtpHost(Vendor, Region);
            }

            if (ParameterSetName == "ApiDomainName")
            {
                Uri baseUri;
                // Support ApiDomainName containing https://
                if (Uri.TryCreate(ApiDomainName, UriKind.Absolute, out baseUri))
                {
                    ftpHost = baseUri.Host;
                }
                else
                {
                    // Support ApiDomainName as in just the domainName
                    baseUri = new Uri(string.Format("https://{0}/", ApiDomainName));
                    ftpHost = ApiDomainName;
                }

                // Handle explicit FTP host name
                if (!String.IsNullOrWhiteSpace(FtpDomainName))
                {
                    ftpHost = FtpDomainName;
                    Uri ftpUri;
                    if (Uri.TryCreate(FtpDomainName, UriKind.Absolute, out ftpUri))
                    {
                        ftpHost = ftpUri.Host;
                    }
                }

                apiClient = GetComputeApiClient(baseUri, ApiCredentials.GetNetworkCredential(), LogFilePath, connectionName);
            }
            if (ParameterSetName == "HttpClient")
            {
                apiClient = new ComputeApiClient(new HttpClientAdapter(HttpClient));
            }

            var newCloudComputeConnection = new ComputeServiceConnection(apiClient);

            WriteDebug("Trying to login into the CaaS");
            newCloudComputeConnection.User = await newCloudComputeConnection.ApiClient.LoginAsync();

            if (!String.IsNullOrWhiteSpace(ftpHost))
            {
                // Right now we dont need to do a connect, as ftp is used in only a few commands
                newCloudComputeConnection.FtpClient = new FtpClient
                {
                    Host = ftpHost,
                    EncryptionMode = FtpEncryptionMode.Explicit,
                    DataConnectionEncryption = true,
                    Credentials = ApiCredentials.GetNetworkCredential()
                        .GetCredential(new Uri(string.Format("ftp://{0}", ftpHost)), "Basic")
                };
            }
            return newCloudComputeConnection;
        }

        /// <summary>The get compute api client.</summary>
        /// <param name="geoKey">The geo Key.</param>
        /// <param name="credentials">The User credentials</param>
        /// <param name="logFile">The Log File Path</param>
        /// <param name="connectionName">The Connection Name</param>
        /// <returns>The <see cref="IComputeApiClient"/>.</returns>
        private IComputeApiClient GetComputeApiClient(Uri baseUri, ICredentials credentials, string logFile, string connectionName)
        {
            LogWriter logWriter = null;
            if (!string.IsNullOrWhiteSpace(logFile))
            {
                logWriter = new LogWriter(logFile, connectionName);
            }
            var messageHandler = new ApiMessageHandler(
                (requestMethod, requestUri, responseStatusCode, timeTaken, userName, requestContent, responseContent) =>
                {
                    if (logWriter != null)
                    {
                        logWriter.WriteLog($"{requestMethod}, {requestUri}, {responseStatusCode}, {timeTaken}, {userName}, {requestContent}, {responseContent}");
                    }
                }, true);

            messageHandler.Credentials = credentials;
            messageHandler.PreAuthenticate = true;

            // Handle disposing the message handler
            var httpClient = new HttpClientAdapter(
                new HttpClient(messageHandler, disposeHandler: true)
                {
                    BaseAddress = baseUri,
                    Timeout = TimeSpan.FromMinutes(5),
                });

            // we will not try to login again, assuming the clientId remains the same accross the regions
            return new ComputeApiClient(httpClient);
        }
    }
}