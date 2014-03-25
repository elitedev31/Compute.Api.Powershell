namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		Provides read-only access to information about specifications for a CaaS virtual machine.
	/// </summary>
	public interface IMachineSpecification
	{
		/// <summary>
		///		The virtual machine's number of CPUs.
		/// </summary>
		short CpuCount
		{
			get;
		}

		/// <summary>
		///		The virtual machine's memory size (in MB).
		/// </summary>
		short MemoryMB
		{
			get;
		}

		/// <summary>
		///		The size of the virtual machine's OS disk (in GB).
		/// </summary>
		short OSStorageGB
		{
			get;
		}

		/// <summary>
		///		The size of the virtual machine's additional local disks (in GB).
		/// </summary>
		short AdditionalLocalStorageGB
		{
			get;
		}

		/// <summary>
		///		Information about the machine's operating system.
		/// </summary>
		IOperatingSystem OperatingSystem
		{
			get;
		}
	}
}