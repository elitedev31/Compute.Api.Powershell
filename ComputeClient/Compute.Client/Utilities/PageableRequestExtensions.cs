namespace DD.CBU.Compute.Api.Client.Utilities
{
    using System;
    using DD.CBU.Compute.Api.Contracts.Requests;

    /// <summary>
    /// Provides utility methods to append paging options to URIs.
    /// </summary>
    public static class PageableRequestExtensions
    {
        /// <summary>
        /// Appends query parameters for the supplied paging options to the supplied URI.
        /// </summary>
        /// <param name="uri">
        /// The URI to append the paging parameters to.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// The URI with the paging parameters.
        /// </returns>
        public static Uri AppendToUri(this IPageableRequest pagingOptions, Uri uri)
        {
	        if (uri == null)
		        throw new ArgumentNullException("uri");

            if (pagingOptions == null)
            {
                return uri;
            }

            var queryString = String.IsNullOrEmpty(pagingOptions.Order)
                ? String.Format("pageSize={0}&pageNumber={1}", pagingOptions.PageSize, pagingOptions.PageNumber)
                : String.Format("pageSize={0}&pageNumber={1}&orderBy={2}", pagingOptions.PageSize, pagingOptions.PageNumber, pagingOptions.Order);

            return uri.ToString().Contains("?")
                ? new Uri(uri + "&" + queryString, UriKind.Relative)
                : new Uri(uri + "?" + queryString, UriKind.Relative);
        }
    }
}
