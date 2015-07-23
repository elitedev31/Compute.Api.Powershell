namespace DD.CBU.Compute.Api.Client.Interfaces.Server
{
	/// <summary>
	/// The ServerLegacyAccessor interface.
	/// </summary>
	public interface IServerLegacyAccessor
	{
		/// <summary>
		/// Gets the server.
		/// </summary>
		IServerAccessor Server { get; }

		/// <summary>
		/// Gets the server image.
		/// </summary>
		IServerImagesAccessor ServerImage { get; }
	}
}
