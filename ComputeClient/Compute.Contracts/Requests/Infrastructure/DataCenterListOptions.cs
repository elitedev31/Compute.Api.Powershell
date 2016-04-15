namespace DD.CBU.Compute.Api.Contracts.Requests.Infrastructure
{
    using System;

    /// <summary>
    /// Filtering options for the data center request.
    /// </summary>
    public sealed class DataCenterListOptions : FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>	
        /// Filter by identifier.
        /// </summary>
        public string Id
        {
            get { return GetFilter<string>(IdField); }
            set { SetFilter(IdField, value); }
        }
    }
}
