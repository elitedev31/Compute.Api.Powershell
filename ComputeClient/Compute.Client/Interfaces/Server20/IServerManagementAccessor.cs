namespace DD.CBU.Compute.Api.Client.Interfaces.Server20
{
	/// <summary>
	/// The ServerManagementAccessor interface.
	/// </summary>
	public interface IServerManagementAccessor
	{
		/// <summary>
		/// Gets the server.
		/// </summary>
		IServerAccessor Server { get; }
	}
}
