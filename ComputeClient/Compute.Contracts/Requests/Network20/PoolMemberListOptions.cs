using System;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The Pool Members list option.
    /// </summary>
    public class PoolMemberListOptions: FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "networkDomainId" field name.
        /// </summary>
        public const string NetworkDomainIdField = "networkDomainId";

        /// <summary>
        /// The "datacenterId" field name.
        /// </summary>
        public const string DatacenterIdField = "datacenterId";

        /// <summary>
        /// The "poolId" field name.
        /// </summary>
        public const string PoolIdField = "poolId";

        /// <summary>
        /// The "poolName" field name.
        /// </summary>
        public const string PoolNameField = "poolName";

        /// <summary>
        /// The "nodeId" field name.
        /// </summary>
        public const string NodeIdField = "nodeId";

        /// <summary>
        /// The "nodeName" field name.
        /// </summary>
        public const string NodeNameField = "nodeName";

        /// <summary>
        /// The "nodeIp" field name.
        /// </summary>
        public const string NodeIpField = "nodeIp";

        /// <summary>
        /// The "nodeStatus" field name.
        /// </summary>
        public const string NodeStatusField = "nodeStatus";

        /// <summary>
        /// The "port" field name.
        /// </summary>
        public const string PortField = "port";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";

        /// <summary>
        /// The "status" field name.
        /// </summary>
        public const string StatusField = "status";

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
        /// Identifies an individual Pool.
        /// </summary>
        public Guid? PoolId
        {
            get { return GetFilter<Guid?>(PoolIdField); }
            set { SetFilter(PoolIdField, value); }
        }

        /// <summary>	
        /// Identifies Pools by their name.
        /// </summary>
        public string PoolName
        {
            get { return GetFilter<string>(PoolNameField); }
            set { SetFilter(PoolNameField, value); }
        }

        /// <summary>	
        /// Identifies an individual Node.
        /// </summary>
        public Guid? NodeId
        {
            get { return GetFilter<Guid?>(NodeIdField); }
            set { SetFilter(NodeIdField, value); }
        }

        /// <summary>	
        /// Identifies Nodes by their name.
        /// </summary>
        public string NodeName
        {
            get { return GetFilter<string>(NodeNameField); }
            set { SetFilter(NodeNameField, value); }
        }

        /// <summary>	
        /// Identifies Nodes by their ipv4Address or by their ipv6Address.
        /// </summary>
        public string NodeIp
        {
            get { return GetFilter<string>(NodeIpField); }
            set { SetFilter(NodeIpField, value); }
        }

        /// <summary>	
        /// Identifies Nodes by their status.
        /// nodeStatus=ENABLED
        /// </summary>
        public string NodeStatus
        {
            get { return GetFilter<string>(NodeStatusField); }
            set { SetFilter(NodeStatusField, value); }
        }

        /// <summary>	
        /// Identifies Pool Members by their port value.
        /// </summary>
        public int? Port
        {
            get { return GetFilter<int?>(PortField); }
            set { SetFilter(PortField, value); }
        }

        /// <summary>	
        /// Identifies Pool Members by their status.
        /// </summary>
        public string Status
        {
            get { return GetFilter<string>(StatusField); }
            set { SetFilter(StatusField, value); }
        }

        /// <summary>	
        /// Identifies Pool Members by their state.
        /// Case insensitive. The initial possible set of values for state are:
        /// "NORMAL",
        /// "PENDING_ADD",
        /// "PENDING_CHANGE",
        /// "PENDING_DELETE",
        /// "FAILED_ADD",
        /// "FAILED_CHANGE",
        /// "FAILED_DELETE" and
        /// "REQUIRES_SUPPORT".
        /// </summary>
        public string State
        {
            get { return GetFilter<string>(StateField); }
            set { SetFilter(StateField, value); }
        }
    }
}