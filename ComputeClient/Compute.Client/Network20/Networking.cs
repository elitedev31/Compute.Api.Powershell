namespace DD.CBU.Compute.Api.Client.Network20
{
	using Interfaces;

	/// <summary>	A standard implementation of Network 2.0 access methods. </summary>
	/// <seealso cref="T:DD.CBU.Compute.Api.Client.Interfaces.INetworking"/>
	public class Networking : INetworking
	{
		/// <summary>	The network domain. </summary>
		private INetworkDomain _networkDomain;

		/// <summary>	The VLAN bus logic. </summary>
		private IVlan _vlan;

		/// <summary>	The IPAM logic. </summary>
		private IIpam _ipam;

		/// <summary>
		/// 	Initializes a new instance of the DD.CBU.Compute.Api.Client.Network20.Networking
		/// 	class.
		/// </summary>
		/// <param name="computeApiClient">The API client for the compute library.</param>
		public Networking(IComputeApiClient computeApiClient)
		{
			_networkDomain = new NetworkDomain(computeApiClient);
			_vlan = new Vlan(computeApiClient);
			_ipam = new IpAddressManagement(computeApiClient);
		}

		/// <summary>	Gets the network domain. </summary>
		/// <value>	The network domain. </value>
		public INetworkDomain NetworkDomain
		{
			get { return _networkDomain; }
		}

		/// <summary>	VLAN related opertions. </summary>
		/// <value>	The vlan. </value>
		/// <seealso cref="P:DD.CBU.Compute.Api.Client.Interfaces.INetworking.Vlan"/>
		public IVlan Vlan
		{
			get { return _vlan; }
		}

		/// <summary>	IP address management. </summary>
		/// <value>	The IP address management. </value>
		/// <seealso cref="P:DD.CBU.Compute.Api.Client.Interfaces.INetworking.IpAddressManagement"/>
		public IIpam IpAddressManagement
		{
			get { return _ipam; }
		}
	}
}
