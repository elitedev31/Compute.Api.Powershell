using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		Represents the specifications for a CaaS virtual machine.
	/// </summary>
	[XmlRoot("MachineSpecification", Namespace = XmlNamespaceConstants.Server)]
	public class MachineSpecification
		: IMachineSpecification
	{
		/// <summary>
		///		Create a new <see cref="MachineSpecification"/>.
		/// </summary>
		public MachineSpecification()
		{
		}

		/// <summary>
		///		The virtual machine's number of CPUs.
		/// </summary>
		[XmlElement("cpuCount", Namespace = XmlNamespaceConstants.Server)]
		public short CpuCount
		{
			get;
			set;
		}

		/// <summary>
		///		The virtual machine's memory size (in MB).
		/// </summary>
		[XmlElement("memoryMb", Namespace = XmlNamespaceConstants.Server)]
		public short MemoryMB
		{
			get;
			set;
		}

		/// <summary>
		///		The size of the virtual machine's OS disk (in GB).
		/// </summary>
		[XmlElement("osStorageGb", Namespace = XmlNamespaceConstants.Server)]
		public short OSStorageGB
		{
			get;
			set;
		}

		/// <summary>
		///		The size of the virtual machine's additional local disks (in GB).
		/// </summary>
		[XmlElement("additionalLocalStorageGb", Namespace = XmlNamespaceConstants.Server)]
		public short AdditionalLocalStorageGB
		{
			get;
			set;
		}

		/// <summary>
		///		Information about the machine's operating system.
		/// </summary>
		[XmlElement("operatingSystem", Namespace = XmlNamespaceConstants.Server)]
		public OperatingSystem OperatingSystem
		{
			get;
			set;
		}

		/// <summary>
		///		Information about the machine's operating system.
		/// </summary>
		IOperatingSystem IMachineSpecification.OperatingSystem
		{
			get
			{
				return OperatingSystem;
			}
		}
	}
}
