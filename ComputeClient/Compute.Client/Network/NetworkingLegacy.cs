using DD.CBU.Compute.Api.Client.Interfaces;

namespace DD.CBU.Compute.Api.Client.Network
{
	public class NetworkingLegacy : INetworkingLegacy
	{
		private ComputeApiClient _client;

		public NetworkingLegacy(ComputeApiClient computeApiClient)
		{
			_client = computeApiClient;
		}
	}
}