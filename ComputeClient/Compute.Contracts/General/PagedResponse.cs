using System.Collections.Generic;

namespace DD.CBU.Compute.Api.Contracts.General
{
    /// <summary>
    /// Wrapper classe for pages result collection.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    public partial class PagedResponse<T>
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IEnumerable<T> items { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int? pageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        public int? pageCount { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        public int? totalCount { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        public int? pageSize { get; set; }
    }
}