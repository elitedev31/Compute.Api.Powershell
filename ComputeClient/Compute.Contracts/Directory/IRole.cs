namespace DD.CBU.Compute.Api.Contracts.Directory
{
	/// <summary>
	///		Provides read-only access to information about a role in the CaaS API.
	/// </summary>
	public interface IRole
	{
		/// <summary>
		///		The name of the CaaS role.
		/// </summary>
		string Name
		{
			get;
		}
	}
}
