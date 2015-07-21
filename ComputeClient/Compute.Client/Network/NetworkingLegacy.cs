using DD.CBU.Compute.Api.Client.Interfaces;

namespace DD.CBU.Compute.Api.Client.Network
{
	/// <summary>
	/// The networking legacy.
	/// </summary>
	public class NetworkingLegacy : INetworkingLegacy
	{
		/// <summary>
		/// The _api client.
		/// </summary>
		private IWebApi _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="NetworkingLegacy"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public NetworkingLegacy(IWebApi apiClient)
		{
			_apiClient = apiClient;
		}
	}
}