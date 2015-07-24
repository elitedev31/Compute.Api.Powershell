namespace DD.CBU.Compute.Api.Client.Server
{
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Server;

	/// <summary>
	/// The server legacy accessor.
	/// </summary>
	public class ServerManagementLegacyAccessor : IServerManagementLegacyAccessor
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="ServerManagementLegacyAccessor"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public ServerManagementLegacyAccessor(IWebApi apiClient)
		{
			this.Server = new ServerAccessor(apiClient);
			this.ServerImage = new ServerImagesAccessor(apiClient);		
		}

		/// <summary>
		/// Gets the server.
		/// </summary>
		public IServerAccessor Server { get; private set; }

		/// <summary>
		/// Gets the server image.
		/// </summary>
		public IServerImagesAccessor ServerImage { get; private set; }
	}
}
