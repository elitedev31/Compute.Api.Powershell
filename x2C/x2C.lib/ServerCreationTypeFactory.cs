using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using CSharp411;
using Microsoft.VisualBasic.Devices;
using x2C.lib;
using DiskSpeedType = DD.CBU.Compute.Api.Contracts.Server.DiskSpeedType;

namespace x2C
{
	public static class ServerCreationTypeFactory
	{
		public static ServerCreationType GetServerSpecification()
		{
			// Step 1: Name
			ServerCreationType type = new ServerCreationType();

			type.Name = Environment.MachineName;

			type.Description = string.Format("Imported on {0}", DateTime.Now.ToShortDateString());

			type.CpuCount = Environment.ProcessorCount;

			type.RamCountGb = (new ComputerInfo()).TotalPhysicalMemory / 1024 / 1024 / 1024;

			switch (Environment.OSVersion.Version.Minor)
			{
				case 0:
					if (OSInfo.Edition.StartsWith("Enterprise"))
					{
						if (Environment.Is64BitOperatingSystem)
							type.BaseOsImage = "Win2008 Ent 64-bit 2 CPU";
						else
						{
							type.BaseOsImage = "Win2008 Ent 32-bit 2 CPU";
						}
					}
					else if(OSInfo.Edition.StartsWith("Standard"))
						if (Environment.Is64BitOperatingSystem)
							type.BaseOsImage = "Win2008 Std 64-bit 2 CPU";
						else
						{
							type.BaseOsImage = "Win2008 Std 32-bit 2 CPU";
						}
					else 
						if (Environment.Is64BitOperatingSystem)
							type.BaseOsImage = "Win2008 Ent 64-bit 2 CPU";
						else
						{
							type.BaseOsImage = "Win2008 Ent 32-bit 2 CPU";
						}
					// "Windows server 2008/Vista supported." }
					break;
				case 1:
					if (OSInfo.Edition.StartsWith("Enterprise"))
					{
						if (Environment.Is64BitOperatingSystem)
							type.BaseOsImage = "Win2008 R2 Ent 2 CPU";
						else
						{
							type.BaseOsImage = "Win2008 R2 Ent 2 CPU";
						}
					}
					else if (OSInfo.Edition.StartsWith("Standard"))
						if (Environment.Is64BitOperatingSystem)
							type.BaseOsImage = "Win2008 Std 64-bit 2 CPU";
						else
						{
							type.BaseOsImage = "Win2008 Std 32-bit 2 CPU";
						}
					else
						if (Environment.Is64BitOperatingSystem)
							type.BaseOsImage = "Win2008 R2 DC 64-bit 2 CPU";
						else
						{
							type.BaseOsImage = "Win2008 R2 DC 64-bit 2 CPU";
						}
					// "Windows 7/ 2008 Server R2 supported." 
					break;
				case 2:
					if (OSInfo.Edition.StartsWith("Standard"))
						type.BaseOsImage = "Win2012 Std 2 CPU";
					else
					{
						type.BaseOsImage = "Win2012 DC 2 CPU";
					}
					// "Windows 8 / 2012 Server supported." }
					break;
				case 3:
					if (OSInfo.Edition.StartsWith("Standard"))
						type.BaseOsImage = "Win2012 R2 Std 2 CPU";
					else
					{
						type.BaseOsImage = "Win2012 R2 DC 2 CPU";
					}
					// "Windows 8.1 / 2012 Server R2 supported." }
					break;
			}

			int scsiId = 0;
			type.Disk = new List<DiskSpec>();
			foreach (var disk in DriveInfo.GetDrives().Where(disk => disk.IsReady && disk.DriveType == DriveType.Fixed))
			{
				var diskSizeGb = disk.TotalSize / 1024 / 1024 / 1024;
				type.Disk.Add(new DiskSpec
				{
					ScsiId = scsiId,
					SizeGb = diskSizeGb > 1 ? diskSizeGb : 10,
					DiskSpeed = DiskSpeedType.STANDARD
				});
				scsiId ++; 
			}

			type.Network = new List<NetworkInterfaceSpec>();

			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			foreach (var nic in nics.Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback))
			{
				foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
				{
					if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
					{
						if (ip.Address.IsCompatible())
						{
							type.Network.Add(new NetworkInterfaceSpec
							{
								Ip = ip.Address.ToString(),
								Name = nic.Name
							});
						}
					}
				}
				
			}

			// Establish the VLANs
			List<string> uniqueNetworks = new List<string>();
			foreach (var nic in type.Network)
			{
				string networkAddress = string.Join(".", nic.Ip.Split('.').Take(3));
				if (!uniqueNetworks.Contains(networkAddress))
				{
					uniqueNetworks.Add(networkAddress);
				}
			}

			type.Vlans = new List<Vlan>();
			foreach (string net in uniqueNetworks)
			{
				type.Vlans.Add(new Vlan()
				{
					Address = net + ".0",
					Netmask = "255.255.255.0"
				});
			}

			return type;
		}
	}

	public class Vlan
	{
		public string Address { get; set; }

		public string Netmask { get; set; }

		public bool IsDefault { get; set; }
	}
}
