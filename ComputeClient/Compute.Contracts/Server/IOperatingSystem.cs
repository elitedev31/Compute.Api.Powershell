namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		Provides read-only access to information about a well-known operating system for CaaS virtual machines.
	/// </summary>
	public interface IOperatingSystem
	{
		/// <summary>
		///		The operating system type.
		/// </summary>
		OperatingSystemType OperatingSystemType
		{
			get;
		}

		/// <summary>
		///		The operating system display-name.
		/// </summary>
		string DisplayName
		{
			get;
		}
	}
}