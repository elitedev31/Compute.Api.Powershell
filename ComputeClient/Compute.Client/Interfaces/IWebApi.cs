namespace DD.CBU.Compute.Api.Client.Interfaces
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.Directory;

    /// <summary>
    /// The web API interface for communication with CaaS REST API.
    /// </summary>
    public interface IWebApi : IDisposable
    {
        /// <summary>
        ///		Invoke a CaaS API operation using a HTTP GET request.
        /// </summary>
        /// <typeparam name="TResult">
        ///		The XML-serialisable data contract type into which the response will be deserialised.
        /// </typeparam>
        /// <param name="relativeOperationUri">
        ///		The operation URI (relative to the CaaS API's base URI).
        /// </param>
        /// <returns>
        ///		The operation result.
        /// </returns>
        Task<TResult> ApiGetAsync<TResult>(Uri relativeOperationUri);

        /// <summary>
        ///		Invoke a CaaS API operation using a HTTP GET request and return the RAW response as string
        /// </summary>
        /// <param name="relativeOperationUri">
        ///		The operation URI (relative to the CaaS API's base URI).
        /// </param>
        /// <returns>
        ///		The operation result.
        /// </returns>
      
        Task<string> ApiGetAsync(Uri relativeOperationUri);

        /// <summary>
        /// Invoke a CaaS API operation using a HTTP POST request.
        /// </summary>
        /// <typeparam name="TObject">The XML-Serialisable data contract type that the request will be sent.</typeparam>
        /// <typeparam name="TResult">The XML-serialisable data contract type into which the response will be deserialised.</typeparam>
        /// <param name="relativeOperationUri">The operation URI (relative to the CaaS API's base URI).</param>
        /// <param name="content">The content that will be deserialised and passed in the body of the POST request.</param>
        /// <returns>The operation result.</returns>
        Task<TResult> ApiPostAsync<TObject, TResult>(Uri relativeOperationUri, TObject content);


        /// <summary>
        /// Invoke a CaaS API operation using a HTTP POST request with string content
        /// </summary>
        /// <typeparam name="TResult">The XML-serialisable data contract type into which the response will be deserialised.</typeparam>
        /// <param name="relativeOperationUri">The operation URI (relative to the CaaS API's base URI).</param>
        /// <param name="content">The content that will be passed as string in the body of the POST request.</param>
        /// <returns>The operation result.</returns>
        Task<TResult> ApiPostAsync<TResult>(Uri relativeOperationUri, string content);

        /// <summary>
        ///		Asynchronously log into the CaaS API.
        /// </summary>
        /// <param name="accountCredentials">
        ///		The CaaS account credentials used to authenticate against the CaaS API.
        /// </param>
        /// <returns>
        ///		An <see cref="IAccount"/> implementation representing the CaaS account that the client is logged into.
        /// </returns>
        Task<IAccount> LoginAsync(ICredentials accountCredentials);

        /// <summary>
        ///		Log out of the CaaS API.
        /// </summary>
        void Logout();

        /// <summary>
        ///	Is the API client currently logged in to the CaaS API?
        /// </summary>
        bool IsLoggedIn { get; }

        /// <summary>
        ///		Read-only information about the CaaS account targeted by the CaaS API client.
        /// </summary>
        /// <remarks>
        ///		<c>null</c>, unless logged in.
        /// </remarks>
        /// <seealso cref="LoginAsync"/>
        IAccount Account { get; }
    }
}
