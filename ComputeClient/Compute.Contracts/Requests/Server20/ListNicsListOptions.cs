namespace DD.CBU.Compute.Api.Contracts.Requests.Server20
{
    using System;

    /// <summary>
    /// Filtering options for the List NICs request.
    /// </summary>
    public sealed class ListNicsOptions : FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "datacenterId" field name.
        /// </summary>
        public const string ServerIdField = "serverId";

        /// <summary>
        /// The "networkDomainId" field name.
        /// </summary>
        public const string SecurityGroupIdField = "securityGroupId";

        /// <summary>
        /// The "networkId" field name.
        /// </summary>
        public const string NetworkIdField = "networkId";


        /// <summary>	
        /// Identifies an individual server nic.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
            set { SetFilter(IdField, value); }
        }

        /// <summary>	
        /// Identifies an individual server.
        /// </summary>
        public Guid? ServerId
        {
            get { return GetFilter<Guid?>(ServerIdField); }
            set { SetFilter(ServerIdField, value); }
        }

        /// <summary>	
        /// Identifies an individual security group.
        /// </summary>
        public Guid? SecurityGroupId
        {
            get { return GetFilter<Guid?>(SecurityGroupIdField); }
            set { SetFilter(SecurityGroupIdField, value); }
        }

        /// <summary>
        /// Gets or sets the NetworkId filter.
        /// </summary>
        public Guid? NetworkId
        {
            get { return GetFilter<Guid?>(NetworkIdField); }
            set { SetFilter(NetworkIdField, value); }
        }
    }
}
