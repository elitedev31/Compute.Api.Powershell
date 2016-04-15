namespace DD.CBU.Compute.Api.Contracts.Requests.Server20
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
        /// The "datacenterId" field name.
        /// </summary>
        public const string DatacenterIdField = "datacenterId";

        /// <summary>
        /// The "networkDomainId" field name.
        /// </summary>
        public const string NetworkDomainIdField = "networkDomainId";

        /// <summary>
        /// The "networkId" field name.
        /// </summary>
        public const string NetworkIdField = "networkId";

        /// <summary>
        /// The "vlanId" field name.
        /// </summary>
        public const string VlanIdField = "vlanId";

        /// <summary>
        /// The "sourceImageId" field name.
        /// </summary>
        public const string SourceImageIdField = "sourceImageId";

        /// <summary>
        /// The "deployed" field name.
        /// </summary>
        public const string DeployedField = "deployed";

        /// <summary>
        /// The "name" field name.
        /// </summary>
        public const string NameField = "name";

        /// <summary>
        /// The "createTime" field name.
        /// </summary>
        public const string CreateTimeField = "createTime";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";

        /// <summary>
        /// The "started" field name.
        /// </summary>
        public const string StartedField = "started";

        /// <summary>
        /// The "operatingSystemId" field name.
        /// </summary>
        public const string OperatingSystemIdField = "operatingSystemId";

        /// <summary>
        /// The "ipv6" field name.
        /// </summary>
        public const string Ipv6Field = "ipv6";

        /// <summary>
        /// The "privateIpv4" field name.
        /// </summary>
        public const string PrivateIpv4Field = "privateIpv4";

        /// <summary>	
        /// Identifies an individual Virtual Listener.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
            set { SetFilter(IdField, value); }
        }

        /// <summary>	
        /// Identifies an individual Network Domain.
        /// </summary>
        public Guid? NetworkDomainId
        {
            get { return GetFilter<Guid?>(NetworkDomainIdField); }
            set { SetFilter(NetworkDomainIdField, value); }
        }

        /// <summary>	
        /// Identifies an individual Data Center.
        /// </summary>
        public string DatacenterId
        {
            get { return GetFilter<string>(DatacenterIdField); }
            set { SetFilter(DatacenterIdField, value); }
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
        /// Gets or sets the VlanId filter.
        /// </summary>
        public Guid? VlanId
        {
            get { return GetFilter<Guid?>(VlanIdField); }
            set { SetFilter(VlanIdField, value); }
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
        /// Identifies Virtual Listeners by their name.
        /// </summary>
        public string Name
        {
            get { return GetFilter<string>(NameField); }
            set { SetFilter(NameField, value); }
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
            set { SetFilter(CreateTimeField, FilterOperator.GreaterThan, value); }
        }

        /// <summary>
        /// Gets or sets the State filter.
        /// </summary>
        public string State
        {
            get { return GetFilter<string>(StateField); }
            set { SetFilter(StateField, value); }
        }

        /// <summary>
        /// Gets or sets the Started filter.
        /// </summary>
        public bool? Started
        {
            get { return GetFilter<bool?>(StartedField); }
            set { SetFilter(StartedField, value); }
        }

        /// <summary>
        /// Gets or sets the OperatingSystemId filter.
        /// </summary>
        public Guid? OperatingSystemId
        {
            get { return GetFilter<Guid?>(OperatingSystemIdField); }
            set { SetFilter(OperatingSystemIdField, value); }
        }

        /// <summary>
        /// Gets or sets the Ipv6 filter.
        /// </summary>
        public string Ipv6
        {
            get { return GetFilter<string>(Ipv6Field); }
            set { SetFilter(Ipv6Field, value); }
        }

        /// <summary>
        /// Gets or sets the PrivateIpv4 filter.
        /// </summary>
        public string PrivateIpv4
        {
            get { return GetFilter<string>(PrivateIpv4Field); }
            set { SetFilter(PrivateIpv4Field, value); }
        }
    }
}
