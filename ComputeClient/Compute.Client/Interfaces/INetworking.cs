namespace DD.CBU.Compute.Api.Client.Interfaces
{
	/// <summary>	Interface for networking 2.0 API. </summary>
	public interface INetworking
	{
		/// <summary>	Network Domain related operations </summary>
		INetworkDomain NetworkDomain { get; }

		/// <summary>	VLAN related opertions </summary>
		IVlan Vlan { get; }

		/// <summary>	IP address management. </summary>
		IIpam IpAddressManagement { get; }
	}
}
