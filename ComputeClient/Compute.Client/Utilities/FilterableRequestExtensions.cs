namespace DD.CBU.Compute.Api.Client.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Attributes;

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

            var parameters = filterableRequest
                .GetType()
                .GetProperties()
                .Select(property => FormatFilterProperty(filterableRequest, property))
                .Where(property => property != null)
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

        /// <summary>
        /// Formats the supplied property as a API request filter query parameter.
        /// </summary>
        /// <param name="listOptions">
        /// The list options object.
        /// </param>
        /// <param name="property">
        /// The property information.
        /// </param>
        /// <returns>
        /// The formatted parameter query string or null.
        /// </returns>
        private static string FormatFilterProperty(object listOptions, PropertyInfo property)
        {
            // Get the attribute with the filter metadata.
            var attribute = property.GetCustomAttributes(typeof(FilterParameterAttribute), true)
                .Cast<FilterParameterAttribute>()
                .FirstOrDefault();
            if (attribute == null)
            {
                return null;
            }

            // Get the value.
            var value = property.GetValue(listOptions);
            if (value == null)
            {
                return null;
            }

            var stringValue = value.ToString();

            if (property.PropertyType == typeof(DateTime?))
                stringValue = ((DateTime?)value).Value.ToString("o");

            if (property.PropertyType == typeof(DateTimeOffset?))
                stringValue = ((DateTimeOffset?)value).Value.ToString("o");

            if (property.PropertyType == typeof(bool?))
                stringValue = stringValue.ToLower();

            // Get the operator.
            var op = attribute.Operator;
            if (String.IsNullOrEmpty(op))
            {
                op = stringValue.Contains("*") ? ".LIKE=" : "=";
            }

            // Format the query string.
            return attribute.ParameterName + op + stringValue;
        }
    }
}
