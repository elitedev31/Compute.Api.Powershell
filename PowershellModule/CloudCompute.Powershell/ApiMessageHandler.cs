namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The HTTP message handler for the CaaS API.
    /// Intended to be used like an <see cref="HttpClientHandler"/> (as the terminus in an HTTP client pipeline).
    /// </summary>
    /// <remarks>
    /// Adam's proposed alternative implementation.
    /// </remarks>
    public class ApiMessageHandler
        : HttpClientHandler
    {
        /// <summary>
        /// Password patterns with replacement patterns
        /// </summary>
        private static readonly IList<Tuple<string, string>> ContentPatterns = new List<Tuple<string, string>>
        {
            // Deploy Server
            new Tuple<string, string>("(<administratorPassword>)(.*?)(</administratorPassword>)", "$1*$3"),

            // New Storage/File Account, List Storage Account
            new Tuple<string, string>("(<password>)(.*?)(</password>)", "$1*$3"),

            // Reset password
            new Tuple<string, string>("(<newPassword>)(.*?)(</newPassword>)", "$1*$3"),

            // Add sub-admin account, Update Administrator account, Modify Storage Account
            // Adding 2 to keep regex simpler. 1st for single argument annother for multi-argument
            new Tuple<string, string>("(password=)([^&]+)$", "$1*"),
            new Tuple<string, string>("(password=)([^&]+)(&)(.*?)$", "$1*$3$4"),

            // Hide other PII
            new Tuple<string, string>("(<emailAddress>)(.*?)(</emailAddress>)", "$1*$3"),
            new Tuple<string, string>("(<phoneNumber>)(.*?)(</phoneNumber>)", "$1*$3"),

            // backup api
            new Tuple<string, string>("(\"Email\":)([^,}]+)", "$1*"),

            // Hide access_token
            new Tuple<string, string>("(\"access_token\":)([^,}]+)", "$1*"),
            new Tuple<string, string>("(\"refresh_token\":)([^,}]+)", "$1*"),

            // backup client_secret is passed in the uri
            new Tuple<string, string>("(client_secret=)([^&]+)$", "$1*"),
            new Tuple<string, string>("(client_secret=)([^&]+)(&)", "$1*$3"),
            new Tuple<string, string>("(client_id=)([^&]+)$", "$1*"),
            new Tuple<string, string>("(client_id=)([^&]+)(&)", "$1*$3"),
            new Tuple<string, string>("(code=)([^&]+)$", "$1*"),
            new Tuple<string, string>("(code=)([^&]+)(&)", "$1*$3")
        };

        /// <summary>
        /// Password patterns with replacement patterns
        /// </summary>
        private static readonly IList<Tuple<string, string>> UriPatterns = new List<Tuple<string, string>>
        {
            // backup client_secret is passed in the uri
            new Tuple<string, string>("(client_secret=)([^&]+)$", "$1*"),
            new Tuple<string, string>("(client_secret=)([^&]+)(&)", "$1*$3"),
            new Tuple<string, string>("(client_id=)([^&]+)$", "$1*"),
            new Tuple<string, string>("(client_id=)([^&]+)(&)", "$1*$3"),
            new Tuple<string, string>("(code=)([^&]+)$", "$1*"),
            new Tuple<string, string>("(code=)([^&]+)(&)", "$1*$3")
        };

        /// <summary>
        /// TraceHttp log method
        /// </summary>
        public TraceHttpRequest LogEventHandler;

        /// <summary>
        /// Boolean representing if we need to enable request and response content tracing
        /// </summary>
        private readonly bool _enableContentTracing;

        /// <summary>
        /// Instance of a message handler
        /// </summary>
        /// <param name="logEvent">TraceHttp log method</param>
        /// <param name="enableContentTracing">Boolean representing if we need to enable request and response content tracing</param>
        public ApiMessageHandler(bool enableContentTracing = false)
        {
            _enableContentTracing = enableContentTracing;
        }

        /// <summary>
        /// Instance of a message handler
        /// </summary>
        /// <param name="logEvent">TraceHttp log method</param>
        /// <param name="enableContentTracing">Boolean representing if we need to enable request and response content tracing</param>
        public ApiMessageHandler(TraceHttpRequest logEvent, bool enableContentTracing = false)
        {
            if (logEvent == null)
                throw new ArgumentNullException(nameof(logEvent));

            LogEventHandler = logEvent;
            _enableContentTracing = enableContentTracing;
        }

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
        public delegate void TraceHttpRequest(
            string requestMethod,
            string requestUri,
            string responseStatusCode,
            double timeTaken,
            string userName,
            string requestContent,
            string responseContent);


        /// <summary>
        /// Asynchronously execute an HTTP request.
        /// </summary>
        /// <param name="request">
        /// The request message.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used to cancel the asynchronous operation.
        /// </param>
        /// <returns>
        /// An <see cref="HttpResponseMessage"/> representing the response.
        /// </returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            DateTime startTime = DateTime.UtcNow;
            HttpResponseMessage response = null;

            try
            {
                response = await base.SendAsync(request, cancellationToken);
            }
            finally
            {
                await LogEvent(request, response, startTime);
            }

            return response;
        }

        /// <summary>
        /// ReadContent From Response
        /// </summary>
        /// <param name="response">Http Response Object</param>
        /// <returns>Task for writing the log</returns>
        private async Task<string> SafeReadContentAsync(HttpResponseMessage response)
        {
            try
            {
                if (!_enableContentTracing)
                    return string.Empty;

                return response != null && response.Content != null
                    ? await response.Content.ReadAsStringAsync()
                    : string.Empty;
            }
            catch
            {
                // ignored
            }

            return string.Empty;
        }

        /// <summary>
        /// ReadContent From Response
        /// </summary>
        /// <param name="request">Http Request Object</param>
        /// <returns>Task for writing the log</returns>
        private async Task<string> SafeReadRequestContentAsync(HttpRequestMessage request)
        {
            try
            {
                if (!_enableContentTracing)
                    return string.Empty;
                return request?.Content != null ? await request.Content.ReadAsStringAsync() : string.Empty;
            }
            catch
            {
                // ignored
            }

            return string.Empty;
        }

        /// <summary>
        /// Log Event to call back
        /// </summary>
        /// <param name="request">Http Request Object</param>
        /// <param name="response">Http Response Object</param>
        /// <param name="requestStartTime">Request Start time</param>
        /// <returns>Task for writing the log</returns>
        private async Task LogEvent(HttpRequestMessage request, HttpResponseMessage response, DateTime requestStartTime)
        {
            try
            {
                var requestMethod = request.Method.ToString();
                var requestUri = request.RequestUri.ToString();
                var requestContent = await SafeReadRequestContentAsync(request);
                var responseContent = await SafeReadContentAsync(response);
                var responseStatusCode = response?.StatusCode.ToString() ?? string.Empty;

                var timeSpan = DateTime.UtcNow - requestStartTime;
                var userName = string.Empty;
                var credentials = Credentials?.GetCredential(request.RequestUri, string.Empty);
                if (credentials != null)
                {
                    userName = credentials.UserName;
                }

                LogEventHandler?.Invoke(
                    requestMethod,
                    SanitizeUri(requestUri),
                    responseStatusCode,
                    timeSpan.TotalMilliseconds,
                    userName,
                    SanitizeContent(requestContent),
                    SanitizeContent(responseContent));
            }
            catch(Exception ex)
            {
                // ignored
            }
        }

        /// <summary>
        /// Sanitizes the Uri
        /// </summary>
        /// <param name="uri">Raw content</param>
        /// <returns>Sanitized input</returns>
        private string SanitizeUri(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                return uri;
            }

            var firstSanitization = UriPatterns.Aggregate(
                uri,
                (current, pattern) => Regex.Replace(current, pattern.Item1, pattern.Item2, RegexOptions.IgnoreCase));

            // We will always log unescaped uri
            return UriPatterns.Aggregate(
                Uri.UnescapeDataString(firstSanitization),
                (current, pattern) => Regex.Replace(current, pattern.Item1, pattern.Item2, RegexOptions.IgnoreCase));
        }

        /// <summary>
        /// Sanitizes the content
        /// </summary>
        /// <param name="content">Raw content</param>
        /// <returns>Sanitized input</returns>
        private string SanitizeContent(string content)
        {
            return string.IsNullOrWhiteSpace(content)
                ? content
                : ContentPatterns.Aggregate(
                    content,
                    (current, pattern) => Regex.Replace(current, pattern.Item1, pattern.Item2, RegexOptions.IgnoreCase));
        }
    }
}