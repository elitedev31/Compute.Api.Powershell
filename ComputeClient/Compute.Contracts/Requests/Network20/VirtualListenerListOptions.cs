using System;

namespace DD.CBU.Compute.Api.Contracts.Requests.Network20
{
    /// <summary>
    /// The Virtal Listener List Options type.
    /// </summary>
    public class VirtualListenerListOptions: FilterableRequest
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
        /// The "name" field name.
        /// </summary>
        public const string NameField = "name";

        /// <summary>
        /// The "enabled" field name.
        /// </summary>
        public const string EnabledField = "enabled";

        /// <summary>
        /// The "state" field name.
        /// </summary>
        public const string StateField = "state";

        /// <summary>
        /// The "createTime" field name.
        /// </summary>
        public const string CreateTimeField = "createTime";

        /// <summary>
        /// The "type" field name.
        /// </summary>
        public const string TypeField = "type";

        /// <summary>
        /// The "protocol" field name.
        /// </summary>
        public const string ProtocolField = "protocol";

        /// <summary>
        /// The "listenerIpAddress" field name.
        /// </summary>
        public const string ListenerIpAddressField = "listenerIpAddress";

        /// <summary>
        /// The "port" field name.
        /// </summary>
        public const string PortField = "port";

        /// <summary>
        /// The "poolId" field name.
        /// </summary>
        public const string PoolIdField = "poolId";

        /// <summary>
        /// The "clientClonePoolId" field name.
        /// </summary>
        public const string ClientClonePoolIdField = "clientClonePoolId";

        /// <summary>
        /// The "persistenceProfileId" field name.
        /// </summary>
        public const string PersistenceProfileIdField = "persistenceProfileId";

        /// <summary>
        /// The "fallbackPersistenceProfileId" field name.
        /// </summary>
        public const string FallbackPersistenceProfileIdField = "fallbackPersistenceProfileId";

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
        /// Identifies Virtual Listeners by their name.
        /// </summary>
        public string Name
        {
            get { return GetFilter<string>(NameField); }
            set { SetFilter(NameField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by whether or not they are enabled.
        /// </summary>
        public bool? Enabled
        {
            get { return GetFilter<bool?>(EnabledField); }
            set { SetFilter(EnabledField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their state.
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

        /// <summary>	
        /// Identifies Virtual Listeners by their type.
        /// </summary>
        public string Type
        {
            get { return GetFilter<string>(TypeField); }
            set { SetFilter(TypeField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their protocol.
        /// </summary>
        public string Protocol
        {
            get { return GetFilter<string>(ProtocolField); }
            set { SetFilter(ProtocolField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their Listener IP Address.
        /// </summary>
        public string ListenerIpAddress
        {
            get { return GetFilter<string>(ListenerIpAddressField); }
            set { SetFilter(ListenerIpAddressField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their virtual listener port.
        /// </summary>
        public int? Port
        {
            get { return GetFilter<int?>(PortField); }
            set { SetFilter(PortField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their Pool Id.
        /// </summary>
        public string PoolId
        {
            get { return GetFilter<string>(PoolIdField); }
            set { SetFilter(PoolIdField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their Client Pool Id.
        /// </summary>
        public string ClientClonePoolId
        {
            get { return GetFilter<string>(ClientClonePoolIdField); }
            set { SetFilter(ClientClonePoolIdField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their default Persistence profile Id.
        /// </summary>
        public string PersistenceProfileId
        {
            get { return GetFilter<string>(PersistenceProfileIdField); }
            set { SetFilter(PersistenceProfileIdField, value); }
        }

        /// <summary>	
        /// Identifies Virtual Listeners by their Fallback Persistence Profile Id.
        /// </summary>
        public string FallbacKPersistenceProfileId
        {
            get { return GetFilter<string>(FallbackPersistenceProfileIdField); }
            set { SetFilter(FallbackPersistenceProfileIdField, value); }
        }
    }
}