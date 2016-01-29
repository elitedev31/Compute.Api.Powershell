namespace DD.CBU.Compute.Api.Contracts.Requests.Infrastructure
{
    /// <summary>
    /// Filtering options for the operating system request.
    /// </summary>
    public sealed class OperatingSystemListOptions : FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "name" field name.
        /// </summary>
        public const string NameField = "name";

        /// <summary>
        /// The "Family" field name.
        /// </summary>
        public const string FamilyField = "family";

        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        public string Id
        {
            get { return GetFilter<string>(IdField); }
            set { SetFilter(IdField, value); }
        }

        /// <summary>
        /// Gets or sets the Name filter.
        /// </summary>
        public string Name
        {
            get { return GetFilter<string>(NameField); }
            set { SetFilter(NameField, value); }
        }

        /// <summary>
        /// Gets or sets the operating system family filter.
        /// </summary>
        public string Family
        {
            get { return GetFilter<string>(FamilyField); }
            set { SetFilter(FamilyField, value); }
        }
    }
}
