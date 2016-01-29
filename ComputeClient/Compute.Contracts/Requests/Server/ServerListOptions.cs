namespace DD.CBU.Compute.Api.Contracts.Requests.Server
{
    using System;

    /// <summary>
    /// Filtering options for the server request.
    /// </summary>
    public sealed class ServerListOptions : FilterableRequest
	{
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "location" field name.
        /// </summary>
        public const string LocationField = "location";

        /// <summary>
        /// The "name" field name.
        /// </summary>
        public const string NameField = "name";

        /// <summary>
        /// The "machineName" field name.
        /// </summary>
        public const string MachineNameField = "machineName";

        /// <summary>
        /// The "networkId" field name.
        /// </summary>
        public const string NetworkIdField = "networkId";

        /// <summary>
        /// The "sourceImageId" field name.
        /// </summary>
        public const string SourceImageIdField = "sourceImageId";

        /// <summary>
        /// The "deployed" field name.
        /// </summary>
        public const string DeployedField = "deployed";

        /// <summary>
        /// The "createTime" field name.
        /// </summary>
        public const string CreateTimeField = "createTime";

        /// <summary>
        /// The "privateIp" field name.
        /// </summary>
        public const string PrivateIpField = "privateIp";

        /// <summary>
        /// Gets or sets the Id filter.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
            set { SetFilter(IdField, value); }
        }

        /// <summary>
        /// Gets or sets the Location filter.
        /// </summary>
        public string Location
        {
            get { return GetFilter<string>(LocationField); }
            set { SetFilter(LocationField, value); }
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
        /// Gets or sets the MachineName filter.
        /// </summary>
        public string MachineName
        {
            get { return GetFilter<string>(MachineNameField); }
            set { SetFilter(MachineNameField, value); }
        }

        /// <summary>
        /// Gets or sets the NetworkId filter.
        /// </summary>
        public Guid? NetworkId
        {
            get { return GetFilter<Guid?>(NetworkIdField); }
            set { SetFilter(NetworkIdField, value); }
        }

        /// <summary>
        /// Gets or sets the SourceImageId filter.
        /// </summary>
        public Guid? SourceImageId
        {
            get { return GetFilter<Guid?>(SourceImageIdField); }
            set { SetFilter(SourceImageIdField, value); }
        }

        /// <summary>
        /// Gets or sets the Deployed filter.
        /// </summary>
        public bool? Deployed
        {
            get { return GetFilter<bool?>(DeployedField); }
            set { SetFilter(DeployedField, value); }
        }

        /// <summary>
        /// Gets or sets the CreateTimeBefore filter.
        /// </summary>
        public DateTimeOffset? CreateTimeBefore
        {
            get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.LessThan); }
            set { SetFilter(CreateTimeField, FilterOperator.LessThan, value); }
        }

        /// <summary>
        /// Gets or sets the CreateTimeAfter filter.
        /// </summary>
        public DateTimeOffset? CreateTimeAfter
        {
            get { return GetFilter<DateTimeOffset?>(CreateTimeField, FilterOperator.GreaterThan); }
            set { SetFilter(CreateTimeField, FilterOperator.LessThan, value); }
        }

        /// <summary>
        /// Gets or sets the PrivateIp filter.
        /// </summary>
        public string PrivateIp
        {
            get { return GetFilter<string>(PrivateIpField); }
            set { SetFilter(PrivateIpField, value); }
        }
    }
}
