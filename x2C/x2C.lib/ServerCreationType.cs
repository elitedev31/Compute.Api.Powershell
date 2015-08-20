using System.Collections.Generic;

namespace x2C
{
	public class ServerCreationType
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public ulong RamCountGb { get; set; }

		public int CpuCount { get; set; }

		public string BaseOsImage { get; set; }

		public List<DiskSpec> Disk { get; set; }

		public List<NetworkInterfaceSpec> Network { get; set; }

		public List<Vlan> Vlans { get; set; }

		public string Password { get; set; }
	}
}
