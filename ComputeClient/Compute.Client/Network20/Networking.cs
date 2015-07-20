using DD.CBU.Compute.Api.Client.Interfaces;

namespace DD.CBU.Compute.Api.Client.Network20
{
	/// <summary>	A standard implementation of Network 2.0 access methods. </summary>
	/// <seealso cref="T:DD.CBU.Compute.Api.Client.Interfaces.INetworking"/>
	public class Networking : INetworking
	{
		/// <summary>	The network domain. </summary>
		private INetworkDomain _networkDomain;

		private IComputeApiClient _client;
		private IVlan _vlan;

		/// <summary>
		/// 	Initializes a new instance of the DD.CBU.Compute.Api.Client.Network20.Networking
		/// 	class.
		/// </summary>
		/// <param name="computeApiClient"></param>
		public Networking(IComputeApiClient computeApiClient)
		{
			_client = computeApiClient;
			_networkDomain = new NetworkDomain(computeApiClient);
			_vlan = new Vlan(computeApiClient);
		}

		/// <summary>	Gets the network domain. </summary>
		/// <value>	The network domain. </value>
		public INetworkDomain NetworkDomain
		{
			get { return _networkDomain; }
		}

		public IVlan Vlan
		{
			get { return _vlan; }
		}
	}
}
