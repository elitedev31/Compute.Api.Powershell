namespace DD.CBU.Compute.Api.Client.Utilities
{
    using System;
    using System.Linq;

    using DD.CBU.Compute.Api.Contracts.Requests;

    /// <summary>
    /// Provides utility methods to append filtering options to URIs.
    /// </summary>
    public static class FilterableRequestExtensions
    {
        /// <summary>
        /// Appends query parameters for the supplied list options object to the supplied URI.
        /// </summary>
        /// <param name="uri">
        /// The URI to append the filter parameters to.
        /// </param>
        /// <param name="filterableRequest">
        /// The filtering options.
        /// </param>
        /// <returns>
        /// The URI with the filter parameters.
        /// </returns>
        public static Uri AppendToUri(this IFilterableRequest filterableRequest, Uri uri)
        {
	        if (uri == null)
		        throw new ArgumentNullException("uri");

            if (filterableRequest == null)
            {
                return uri;
            }

            var parameters = filterableRequest.Filters
                .Select(filter => filter.ToString())
                .ToArray();

            if (parameters.Length == 0)
            {
                return uri;
            }

            var queryString = String.Join("&", parameters);

            return uri.ToString().Contains("?")
                ? new Uri(uri + "&" + queryString, UriKind.Relative)
                : new Uri(uri + "?" + queryString, UriKind.Relative);
        }
    }
}
