namespace DD.CBU.Compute.Api.Client.Interfaces
{
	public interface INetworking
	{
		/// <summary>	Network Domain related operations </summary>
		INetworkDomain NetworkDomain { get; }

		/// <summary>	VLAN related opertions </summary>
		IVlan Vlan { get; }
	}
}
