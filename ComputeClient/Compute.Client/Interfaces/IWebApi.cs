namespace DD.CBU.Compute.Api.Client.Interfaces
{
	using System;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.Directory;
	using DD.CBU.Compute.Api.Contracts.Requests;

    /// <summary>
    /// The web API interface for communication with CaaS REST API.
    /// </summary>
    public interface IWebApi : IDisposable
    {    
	    /// <summary>
	    /// Gets the CaaS client organization id.
	    /// </summary>
	    Guid OrganizationId { get; }

	    /// <summary>
	    /// The login async.
	    /// </summary>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    Task<IAccount> LoginAsync();

        /// <summary>
        /// Invoke a CaaS API operation using a HTTP GET request.
        /// </summary>
        /// <typeparam name="TResult">
        /// The XML-serialisable data contract type into which the response will be deserialised.
        /// </typeparam>
        /// <param name="relativeOperationUri">
        /// The operation URI (relative to the CaaS API's base URI).
        /// </param>
        /// <param name="pagingOptions">
        /// The paging Options.
        /// </param>
		/// <param name="filteringOptions">
		/// The filtering Options.
		/// </param>
        /// <returns>
        /// The operation result.
        /// </returns>
        Task<TResult> GetAsync<TResult>(Uri relativeOperationUri, IPageableRequest pagingOptions = null, IFilterableRequest filteringOptions = null);

        /// <summary>
        /// Invoke a CaaS API operation using a HTTP POST request.
        /// </summary>
		/// <typeparam name="TObject">
		/// The XML-Serialisable data contract type that the request will be sent.
		/// </typeparam>
		/// <typeparam name="TResult">
		/// The XML-serialisable data contract type into which the response will be deserialised.
		/// </typeparam>
		/// <param name="relativeOperationUri">
		/// The operation URI (relative to the CaaS API's base URI).
		/// </param>
		/// <param name="content">
		/// The content that will be deserialised and passed in the body of the POST request.
		/// </param>
		/// <returns>
		/// The operation result.
		/// </returns>
        Task<TResult> PostAsync<TObject, TResult>(Uri relativeOperationUri, TObject content);

        /// <summary>
        /// Invoke a CaaS API operation using a HTTP POST request with string content
        /// </summary>
		/// <typeparam name="TResult">
		/// The XML-serialisable data contract type into which the response will be deserialised.
		/// </typeparam>
		/// <param name="relativeOperationUri">
		/// The operation URI (relative to the CaaS API's base URI).
		/// </param>
		/// <param name="content">
		/// The content that will be passed as string in the body of the POST request.
		/// </param>
		/// <returns>
		/// The operation result.
		/// </returns>
        Task<TResult> PostAsync<TResult>(Uri relativeOperationUri, string content);
    }
}
