namespace DD.CBU.Compute.Api.Client.Network20
{
    using DD.CBU.Compute.Api.Client.Interfaces.Network20;
    using DD.CBU.Compute.Api.Contracts.Server10;

    using Interfaces;

    /// <summary>	A standard implementation of Network 2.0 access methods. </summary>
    public class NetworkingAccessor : INetworkingAccessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkingAccessor"/> class.
        /// </summary>
        /// <param name="apiClient">
        /// The api Client.
        /// </param>
        public NetworkingAccessor(IWebApi apiClient)
        {
            NetworkDomain = new NetworkDomainAccessor(apiClient);
            Vlan = new VlanAccessor(apiClient);
            IpAddress = new IpAddressAccessor(apiClient);
            Nat = new NatAccessor(apiClient);
            FirewallRule = new FirewallRuleAccessor(apiClient);
            VipSupport = new VipSupportAccessor(apiClient);
            VipPool = new VipPoolAccessor(apiClient);
            VipNode = new VipNodeAccessor(apiClient);
            VipVirtualListener = new VipVirtualListenerAccessor(apiClient);
        }

        /// <summary>
        /// Gets the network domain Accessor.
        /// </summary>
        public INetworkDomainAccessor NetworkDomain { get; private set; }

        /// <summary>
        /// Gets the VLAN Accessor.
        /// </summary>
        public IVlanAccessor Vlan { get; private set; }

        /// <summary>
        /// Gets the IP address Accessor.
        /// </summary>
        public IIpAddressAccessor IpAddress { get; private set; }

        /// <summary>
        /// Gets the NAT Rule Accessor.
        /// </summary>
        public INatAccessor Nat { get; private set; }

        /// <summary>
        /// Gets the Firewall Rule Accessor.
        /// </summary>
        public IFirewallRuleAccessor FirewallRule { get; private set; }

        /// <summary>
        /// Gets the VIP Support Accessor.
        /// </summary>
        public IVipSupportAccessor VipSupport { get; private set; }

        /// <summary>
        /// Gets the VIP Pool Accessor.
        /// </summary>
        public IVipPoolAccessor VipPool { get; private set; }

        /// <summary>
        /// Gets the VIP Node Accessor.
        /// </summary>
        public IVipNodeAccessor VipNode { get; private set; }

        /// <summary>
        /// Gets the VIP Virtual Listener Accessor.
        /// </summary>
        public IVipVirtualListenerAccessor VipVirtualListener { get; private set; }
    }
}
