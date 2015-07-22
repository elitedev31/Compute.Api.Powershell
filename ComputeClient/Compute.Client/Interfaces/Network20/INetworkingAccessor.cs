namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
	/// <summary>	Interface for networking 2.0 API. </summary>
	public interface INetworkingAccessor
	{
		/// <summary>	Network Domain related operations </summary>
		INetworkDomainAccessor NetworkDomain { get; }

		/// <summary>	VLAN related opertions </summary>
		IVlanAccessor Vlan { get; }

		/// <summary>	IP address management. </summary>
		IIpamAccessor IpAddressManagement { get; }
	}
}
