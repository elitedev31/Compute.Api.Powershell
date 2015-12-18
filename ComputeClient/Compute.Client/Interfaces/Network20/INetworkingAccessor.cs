namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
	/// <summary>	Interface for networking 2.0 API. </summary>
	public interface INetworkingAccessor
	{
        /// <summary>
        /// Gets the Network Domain Accessor
        /// </summary>
        INetworkDomainAccessor NetworkDomain { get; }

        /// <summary>
        /// Gets the VLAN Accessor
        /// </summary>
        IVlanAccessor Vlan { get; }

        /// <summary>
        /// Gets the Vlan Security Group Accessor
        /// </summary>
        IVlanSecurityGroupAccessor SecurityGroup { get; }

        /// <summary>
        /// Gets the IP address Accessor.
        /// </summary>
        IIpAddressAccessor IpAddress { get; }

        /// <summary>
        /// Gets the NAT Rule Accessor.
        /// </summary>
		INatAccessor Nat { get; }

        /// <summary>
        /// Gets the Firewall Rule Accessor.
        /// </summary>
        IFirewallRuleAccessor FirewallRule { get; }

        /// <summary>
        /// Gets the VIP Support Accessor.
        /// </summary>
        IVipSupportAccessor VipSupport { get; }

        /// <summary>
        /// Gets the VIP Pool Accessor.
        /// </summary>
        IVipPoolAccessor VipPool { get; }

        /// <summary>
        /// Gets the VIP Node Accessor.
        /// </summary>
        IVipNodeAccessor VipNode { get; }

        /// <summary>
        /// Gets the VIP Virtual Listener Accessor.
        /// </summary>
        IVipVirtualListenerAccessor VipVirtualListener { get; }
    }
}
