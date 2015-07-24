namespace DD.CBU.Compute.Api.Client.Server20
{
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Server20;

	/// <summary>
	/// The server management accessor.
	/// </summary>
	public class ServerManagementAccessor : IServerManagementAccessor
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="ServerManagementAccessor"/> class.
		/// </summary>
		/// <param name="webapi">
		/// The webapi.
		/// </param>
		public ServerManagementAccessor(IWebApi webapi)
		{
			Server = new ServerAccessor(webapi);
		}

		/// <summary>
		/// Gets the server.
		/// </summary>
		public IServerAccessor Server { get; private set; }
	}
}
