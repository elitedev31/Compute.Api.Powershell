using DD.CBU.Compute.Api.Client.Interfaces;

namespace DD.CBU.Compute.Api.Client.Network20
{
	/// <summary>	A standard implementation of Network 2.0 access methods. </summary>
	public class Networking : INetworking
	{	
		/// <summary>
		/// 	Initializes a new instance of the DD.CBU.Compute.Api.Client.Network20.Networking
		/// 	class.
		/// </summary>
		/// <param name="apiClient">
		/// WebApi client 
		/// </param>
		public Networking(IWebApi apiClient)
		{
			NetworkDomain = new NetworkDomain(apiClient);
			Vlan = new Vlan(apiClient);
		}

		/// <summary>	Gets the network domain. </summary>
		/// <value>	The network domain. </value>
		public INetworkDomain NetworkDomain { get; private set; }
	
		/// <summary>
		/// Gets the vlan.
		/// </summary>
		public IVlan Vlan { get; private set; }		
	}
}
