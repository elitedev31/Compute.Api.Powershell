namespace DD.CBU.Compute.Api.Client.Interfaces.Network10
{
	/// <summary>
	/// The NetworkingLegacy interface.
	/// </summary>
	public interface INetworkingLegacy
	{
		/// <summary>
		/// Gets the network.
		/// </summary>
		INetwork Network { get; }

		/// <summary>
		/// Gets the network vip.
		/// </summary>
		INetworkVip NetworkVip { get; }
	}
}
