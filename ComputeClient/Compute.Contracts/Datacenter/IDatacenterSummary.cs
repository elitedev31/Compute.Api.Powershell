namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
	/// <summary>
	///		Provides read-only access to summary information about a CaaS data centre.
	/// </summary>
	public interface IDatacenterSummary
	{
		/// <summary>
		///		Is the data centre the default data centre for the caller's organisation?
		/// </summary>
		bool IsDefault
		{
			get;
		}

		/// <summary>
		///		The short location code used as a key to identity the data centre.
		/// </summary>
		string LocationCode
		{
			get;
		}

		/// <summary>
		///		The data centre display name.
		/// </summary>
		string DisplayName
		{
			get;
		}

		/// <summary>
		///		The name of the city in which the data centre is located.
		/// </summary>
		string City
		{
			get;
		}

		/// <summary>
		///		The name of the state in which the data centre is located.
		/// </summary>
		string State
		{
			get;
		}

		/// <summary>
		///		The name of the country in which the data centre is located.
		/// </summary>
		string Country
		{
			get;
		}

		/// <summary>
		///		The access URL for the data centre VPN.
		/// </summary>
		string VpnUrl
		{
			get;
		}

		/// <summary>
		///		The maximum number of CPUs per virtual machine supported by the data centre.
		/// </summary>
		short MaxCpu
		{
			get;
		}

		/// <summary>
		///		The maximum RAM (in MB) per virtual machine supported by the data centre.
		/// </summary>
		int MaxRamMB
		{
			get;
		}
	}
}