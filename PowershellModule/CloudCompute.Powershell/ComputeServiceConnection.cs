// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComputeServiceConnection.cs" company="">
//   
// </copyright>
// <summary>
//   Represents a connection to the CaaS API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.FtpClient;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Directory;

namespace DD.CBU.Compute.Powershell
{

    /// <summary>
    ///     Represents a connection to the CaaS API.
    /// </summary>
    public sealed class ComputeServiceConnection
        : IDisposable
    {

        /// <summary>
        /// Delegate handling the http request trace
        /// </summary>
        /// <param name="requestMethod">
        /// The HTTP request method (e.g. GET / POST / etc).
        /// </param>
        /// <param name="requestUri">
        /// The request URI (truncated to 1000 Unicode characters).
        /// </param>
        /// <param name="responseStatusCode">
        /// A textual representation of the response status code.
        /// </param>
        /// <param name="timeTaken">
        /// The time taken to perform the request.
        /// </param>
        /// <param name="userName">
        /// The CaaS user name used t make the request.
        /// </param>
        /// <param name="requestContent">
        /// The request content (truncated to 2000 Unicode characters).
        /// </param>
        /// <param name="responseContent">
        /// The response Content.
        /// </param>
        public delegate void HttpRequestLogHandler(
            string requestMethod,
            string requestUri,
            string responseStatusCode,
            double timeTaken,
            string userName,
            string requestContent,
            string responseContent);

        // internal TraceHttpRequest OnRequestStarted;

        /// <summary>
        /// Initialises a new instance of the <see cref="ComputeServiceConnection"/> class.
        ///     Create a new compute service connection.
        /// </summary>
        /// <param name="apiClient">
        /// The CaaS API client represented by the connection.
        /// </param>
        public ComputeServiceConnection(IComputeApiClient apiClient, ApiMessageHandler messageHandler)
        {
            MessageHandler = messageHandler;
            if (apiClient == null)
                throw new ArgumentNullException("apiClient");
            ApiClient = apiClient;

            MessageHandler.LogEventHandler += (requestMethod, requestUri, responseStatusCode, timeTaken, userName, requestContent, responseContent) =>
            {
                OnRequestStart?.Invoke(requestMethod, requestUri, responseStatusCode, timeTaken, userName, requestContent, responseContent);
            };
        }

        /// <summary>
        ///     The CaaS account targeted by the connection.
        /// </summary>
        public IUser User { get; internal set; }

        /// <summary>
        ///     The CaaS FTP client.
        /// </summary>
        public FtpClient FtpClient { get; set; }

        /// <summary>
        ///     The CaaS API client represented by the connection.
        /// </summary>
        internal IComputeApiClient ApiClient { get; private set; }

        public ApiMessageHandler MessageHandler { get; internal set; }

        public event HttpRequestLogHandler OnRequestStart;

        /// <summary>
        ///     Dispose of resources being used by the CaaS API connection.
        /// </summary>
        public void Dispose()
        {
            if (ApiClient != null)
            {
                ApiClient.Dispose();
                ApiClient = null;
            }
        }
    }
}