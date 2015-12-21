using System.Collections.Generic;

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

            var filters = new List<string>();
            if(pagingOptions.PageSize.HasValue)
                filters.Add(string.Format("pageSize={0}", pagingOptions.PageSize.Value));

            if (pagingOptions.PageNumber.HasValue)
                filters.Add(string.Format("pageNumber={0}", pagingOptions.PageNumber.Value));

            if (!String.IsNullOrEmpty(pagingOptions.Order))
                filters.Add(string.Format("orderBy={0}", pagingOptions.Order));
           
            var queryString = String.Join("&", filters);

            return uri.ToString().Contains("?")
                ? new Uri(uri + "&" + queryString, UriKind.Relative)
                : new Uri(uri + "?" + queryString, UriKind.Relative);
        }
    }
}
