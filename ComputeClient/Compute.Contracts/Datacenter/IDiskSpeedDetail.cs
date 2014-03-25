namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
	/// <summary>
	///		Provides read-only access to detailed information about a disk speed specification.
	/// </summary>
	public interface IDiskSpeedDetail
	{
		/// <summary>
		///		Is the disk speed available at the parent data centre?
		/// </summary>
		bool IsAvailable
		{
			get;
		}

		/// <summary>
		///		Is the disk speed the default disk speed at the parent data centre?
		/// </summary>
		bool IsDefault
		{
			get;
		}

		/// <summary>
		///		The disk speed Id.
		/// </summary>
		string Id
		{
			get;
		}

		/// <summary>
		///		A display name for the disk speed.
		/// </summary>
		string DisplayName
		{
			get;
		}

		/// <summary>
		///		An abbreviated name for the disk speed.
		/// </summary>
		string Abbreviation
		{
			get;
		}

		/// <summary>
		///		A description of the disk speed.
		/// </summary>
		string Description
		{
			get;
		}
	}
}