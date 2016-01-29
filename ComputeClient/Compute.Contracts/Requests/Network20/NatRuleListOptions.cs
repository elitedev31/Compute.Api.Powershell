using System;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The NAT Rule list options type.
    /// </summary>
    public class NatRuleListOptions : FilterableRequest
    {
        /// <summary>
        /// The "id" field name.
        /// </summary>
        public const string IdField = "id";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";

        /// <summary>
        /// The "internalIp" field name.
        /// </summary>
        public const string InternalIpField = "internalIp";

        /// <summary>
        /// The "externalIp" field name.
        /// </summary>
        public const string ExternalIpField = "externalIp";

        /// <summary>
        /// The "nodeIdField" field name.
        /// </summary>
        public const string NodeIdField = "nodeId";

        /// <summary>
        /// Identifies an individual NAT Rule.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>	
        /// Identifies NAT Rules by their state.
        /// Case insensitive. The initial possible
        /// set of values for state are:
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

        /// <summary>	
        /// Identifies internal IPv4 address addresses.
        /// </summary>
        public string InternalIp
        {
            get { return GetFilter<string>(InternalIpField); }
            set { SetFilter(InternalIpField, value); }
        }

        /// <summary>	
        /// Identifies external IPv4 addresses.
        /// </summary>
        public string ExternalIp
        {
            get { return GetFilter<string>(ExternalIpField); }
            set { SetFilter(ExternalIpField, value); }
        }

        /// <summary>	
        /// Identifies NAT Rule by node id.
        /// </summary>
        public Guid? NodeId
        {
            get { return GetFilter<Guid?>(NodeIdField); }
            set { SetFilter(NodeIdField, value); }
        }
    }
}