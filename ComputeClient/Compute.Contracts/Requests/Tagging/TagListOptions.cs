namespace DD.CBU.Compute.Api.Contracts.Requests.Tagging
{
    using System;

    /// <summary>The tag key list options.</summary>
    public sealed class TagListOptions : FilterableRequest
    {
        /// <summary>
        /// The "assetId" field name.
        /// </summary>
        public const string AssetIdField = "assetId";

        /// <summary>
        /// The "assetType" field name.
        /// </summary>
        public const string AssetTypeField = "assetType";

        /// <summary>
        /// The "datecenterId" field name.
        /// </summary>
        public const string DatecenterIdField = "datecenterId";

        /// <summary>
        /// The "tagKeyName" field name.
        /// </summary>
        public const string TagKeyNameField = "tagKeyName";

        /// <summary>
        /// The "tagKeyId" field name.
        /// </summary>
        public const string TagKeyIdField = "tagKeyId";

        /// <summary>
        /// The "value" field name.
        /// </summary>
        public const string ValueField = "value";

        /// <summary>
        /// The "valueRequired" field name.
        /// </summary>
        public const string ValueRequiredField = "valueRequired";

        /// <summary>
        /// The "displayOnReport" field name.
        /// </summary>
        public const string DisplayOnReportField = "displayOnReport";


        /// <summary>Gets or sets the asset id.</summary>
        public Guid? AssetId
        {
            get { return GetFilter<Guid?>(AssetIdField); }
            set { SetFilter(AssetIdField, value); }
        }

        /// <summary>Gets or sets the asset type.</summary>
        public string AssetType
        {
            get { return GetFilter<string>(AssetTypeField); }
            set { SetFilter(AssetTypeField, value); }
        }

        /// <summary>Gets or sets the datecenter id.</summary>
        public string DatecenterId
        {
            get { return GetFilter<string>(DatecenterIdField); }
            set { SetFilter(DatecenterIdField, value); }
        }

        /// <summary>Gets or sets the tag key name.</summary>
        public string TagKeyName
        {
            get { return GetFilter<string>(TagKeyNameField); }
            set { SetFilter(TagKeyNameField, value); }
        }

        /// <summary>Gets or sets the tag key id.</summary>
        public Guid? TagKeyId
        {
            get { return GetFilter<Guid?>(TagKeyIdField); }
            set { SetFilter(TagKeyIdField, value); }
        }

        /// <summary>Gets or sets the value.</summary>
        public string Value
        {
            get { return GetFilter<string>(ValueField); }
            set { SetFilter(ValueField, value); }
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