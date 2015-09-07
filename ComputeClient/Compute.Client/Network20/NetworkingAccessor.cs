namespace DD.CBU.Compute.Api.Client.Network20
{
	using DD.CBU.Compute.Api.Client.Interfaces.Network20;

	using Interfaces;

	/// <summary>	A standard implementation of Network 2.0 access methods. </summary>
	public class NetworkingAccessor : INetworkingAccessor
	{	
		/// <summary>
		/// 	Initializes a new instance of the DD.CBU.Compute.Api.Client.Network20.Networking
		/// 	class.
		/// </summary>
		/// <param name="apiClient">
		/// The api Client.
		/// </param>
		public NetworkingAccessor(IWebApi apiClient)
		{
			NetworkDomain = new NetworkDomainAccessor(apiClient);
			Vlan = new VlanAccessor(apiClient);
			IpAddressManagement = new IpAddressManagementAccessor(apiClient);
            NatAccessor = new NatAccessor(apiClient);
		}

		/// <summary> Gets the network domain. </summary>
		/// <value>	The network domain. </value>
		public INetworkDomainAccessor NetworkDomain { get; private set; }
	
		/// <summary>
		/// Gets the vlan.
		/// </summary>
		public IVlanAccessor Vlan { get; private set; }		

		/// <summary> IP address management. </summary>
		/// <value>	The IP address management. </value>
		/// <seealso cref="P:DD.CBU.Compute.Api.Client.Interfaces.INetworking.IpAddressManagement"/>
		public IIpamAccessor IpAddressManagement { get; private set; }

        /// <summary>
        /// Gets the NAT Rule Accessor.
        /// </summary>
        public INatAccessor NatAccessor { get; }
	}
}
