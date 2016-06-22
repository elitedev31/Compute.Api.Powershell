namespace DD.CBU.Compute.Api.Contracts.Requests.Drs
{
    using System;

    /// <summary>
    /// Filtering options for the Consistency Group.
    /// </summary>
    public sealed class ConsistencyGroupListOptions : FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "source datacenterId" field name.
        /// </summary>
        public const string SourceDatacenterIdField = "sourceDatacenterId";

        /// <summary>
        /// The "target datacenterId" field name.
        /// </summary>
        public const string TargetDatacenterIdField = "targetDatacenterId";

        /// <summary>
        /// The "source source network domain id" field name.
        /// </summary>
        public const string SourceNetworkDomainIdField = "sourceNetworkDomainId";

        /// <summary>
        /// The "target network domain id" field name.
        /// </summary>
        public const string TargetNetworkDomainIdField = "targetNetworkDomainId";

        /// <summary>
        /// The source server id field name.
        /// </summary>
        public const string SourceServerIdField = "sourceServerId";

        /// <summary>
        /// The "target server id" field name.
        /// </summary>
        public const string TargetServerIdField = "targetServerId";


        /// <summary>
        /// The "operation status" field name.
        /// </summary>
        public const string OperationStatusField = "operationStatus";

        /// <summary>
        /// The DRS infrastructure status field name.
        /// </summary>
        public const string DrsInfrastructureStatusField = "drsInfrastructureStatus";


        /// <summary>
        /// The "name" field name.
        /// </summary>
        public const string NameField = "name";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";

        /// <summary>
        /// The "createTime" field name.
        /// </summary>
        public const string CreateTimeField = "createTime";

        /// <summary>
        /// Gets or sets the id filter.
        /// </summary>
        public Guid? Id
        {
            get { return GetFilter<Guid?>(IdField); }
            set { SetFilter(IdField, value); }
        }

        /// <summary>	
        /// Identifies the source Data Center.
        /// </summary>
        public string SourceDatacenterId
        {
            get { return GetFilter<string>(SourceDatacenterIdField); }
            set { SetFilter(SourceDatacenterIdField, value); }
        }

        /// <summary>
        /// Identifies the target Data Center.
        /// </summary>
        public string TargetDatacenterId
        {
            get { return GetFilter<string>(TargetDatacenterIdField); }
            set { SetFilter(TargetDatacenterIdField, value); }
        }

        /// <summary>
        /// Identifies the source network domain id.
        /// </summary>
        public string SourceNetworkDomainId
        {
            get { return GetFilter<string>(SourceNetworkDomainIdField); }
            set { SetFilter(SourceNetworkDomainIdField, value); }
        }

        /// <summary>
        /// Identifies the target network domain id.
        /// </summary>
        public string TargetNetworkDomainId
        {
            get { return GetFilter<string>(TargetNetworkDomainIdField); }
            set { SetFilter(TargetNetworkDomainIdField, value); }
        }

        /// <summary>
        /// Identifies the source server id.
        /// </summary>
        public string SourceServerId
        {
            get { return GetFilter<string>(SourceServerIdField); }
            set { SetFilter(SourceServerIdField, value); }
        }

        /// <summary>
        /// Identifies the target server id.
        /// </summary>
        public string TargetServerId
        {
            get { return GetFilter<string>(TargetServerIdField); }
            set { SetFilter(TargetServerIdField, value); }
        }

        /// <summary>
        /// Identifies the operation status.
        /// </summary>
        public string OperationStatus
        {
            get { return GetFilter<string>(SourceServerIdField); }
            set { SetFilter(SourceServerIdField, value); }
        }

        /// <summary>
        /// The DRS infrastructure status field.
        /// </summary>
        public string DrsInfrastructureStatus
        {
            get { return GetFilter<string>(DrsInfrastructureStatusField); }
            set { SetFilter(DrsInfrastructureStatusField, value); }
        }

        /// <summary>	
        /// Identifies consistency group by their name.
        /// </summary>
        public string Name
        {
            get { return GetFilter<string>(NameField); }
            set { SetFilter(NameField, value); }
        }

        /// <summary>
        /// Gets or sets the State filter.
        /// </summary>
        public string State
        {
            get { return GetFilter<string>(StateField); }
            set { SetFilter(StateField, value); }
        }
    }
}