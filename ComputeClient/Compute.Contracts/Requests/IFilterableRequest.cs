namespace DD.CBU.Compute.Api.Contracts.Requests
{
    using System.Collections.Generic;

    /// <summary>
    /// The interface need to be implemented by requests which support filtering options.
    /// </summary>
	public interface IFilterableRequest
    {
        /// <summary>
        /// Gets the filters.
        /// </summary>
        IList<Filter> Filters { get; }
    }
}