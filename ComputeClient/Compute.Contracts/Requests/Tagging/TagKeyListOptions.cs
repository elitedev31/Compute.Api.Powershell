namespace DD.CBU.Compute.Api.Contracts.Requests.Tagging
{
    using System;

    /// <summary>The tag key list options.</summary>
    public sealed class TagKeyListOptions : FilterableRequest
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
        /// The "valueRequired" field name.
        /// </summary>
        public const string ValueRequiredField = "valueRequired";

        /// <summary>
        /// The "displayOnReport" field name.
        /// </summary>
        public const string DisplayOnReportField = "displayOnReport";


        /// <summary>
        /// Gets or sets the Id filter.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
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
        /// Gets or sets the ValueRequired filter.
        /// </summary>
        public bool? ValueRequired
        {
            get { return GetFilter<bool?>(ValueRequiredField); }
            set { SetFilter(ValueRequiredField, value); }
        }

        /// <summary>
        /// Gets or sets the DisplayOnReport filter.
        /// </summary>
        public bool? DisplayOnReport
        {
            get { return GetFilter<bool?>(DisplayOnReportField); }
            set { SetFilter(DisplayOnReportField, value); }
        }
    }
}