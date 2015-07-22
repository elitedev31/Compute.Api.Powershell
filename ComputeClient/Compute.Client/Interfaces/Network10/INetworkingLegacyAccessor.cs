namespace DD.CBU.Compute.Api.Client.Interfaces.Network10
{
	/// <summary>
	/// The NetworkingLegacy interface.
	/// </summary>
	public interface INetworkingLegacyAccessor
	{
		/// <summary>
		/// Gets the network.
		/// </summary>
		INetworkAccessor Network { get; }

		/// <summary>
		/// Gets the network vip.
		/// </summary>
		INetworkVipAccessor NetworkVip { get; }
	}
}
