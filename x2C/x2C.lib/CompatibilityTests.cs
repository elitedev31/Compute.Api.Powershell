using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using x2C.lib;

namespace x2C
{
	public static class CompatibilityTests
	{
		/// <summary>	Check CPU configuration. </summary>
		/// <returns>	A TestOutcome. </returns>
		public static TestOutcome CheckCpuConfiguration()
		{
			if (Environment.ProcessorCount < 1)
			{
				return new TestOutcome
				{
					Messages = new List<string> { "Not enough CPU" },
					Type = TestingOutcomeType.Fail
				};
			}

			// 32 is too many
			if (Environment.ProcessorCount > 32)
			{
				return new TestOutcome
				{
					Messages = new List<string>{"Too many CPU"},
					Type = TestingOutcomeType.Fail
				};
			}

			// between 16-32
			if (Environment.ProcessorCount > 16 && Environment.ProcessorCount <= 32)
			{
				return new TestOutcome
				{
					Messages = new List<string> { "Only compatible with MCP 2" },
					Type = TestingOutcomeType.Warning
				};
			}

			return new TestOutcome
			{
				Messages = new List<string> { "CPU Configuration OK" },
				Type = TestingOutcomeType.Pass
			};
		}

		/// <summary>	Check ram configuration. </summary>
		/// <returns>	A TestOutcome. </returns>
		public static TestOutcome CheckRamConfiguration()
		{
			ulong ramSize = (new ComputerInfo()).TotalPhysicalMemory / 1024 / 1024 / 1024;

			if (ramSize < 1)
			{
				return new TestOutcome
				{
					Messages = new List<string> { "Memory size is too small for recommendations" },
					Type = TestingOutcomeType.Warning
				};
			}

			if (ramSize > 256)
			{
				return new TestOutcome
				{
					Messages = new List<string> { "RAM size is too large for MCP 1 or 2." },
					Type = TestingOutcomeType.Fail
				};
			}

			if (ramSize > 128 && ramSize <= 256)
			{
				return new TestOutcome
				{
					Messages = new List<string> { "Only compatible with MCP 2" },
					Type = TestingOutcomeType.Warning
				};
			}

			return new TestOutcome
			{
				Messages = new List<string> { string.Format("RAM Configuration OK {0}GB", ramSize) },
				Type = TestingOutcomeType.Pass
			};
		}

		public static TestOutcome CheckDiskCount()
		{
			var driveInfo = System.IO.DriveInfo.GetDrives();

			if (driveInfo.Count(drive => drive.DriveType == DriveType.Fixed && drive.IsReady) < 1)
			{
				return new TestOutcome
				{
					Messages = new List<string> { "Not enough fixed drives" },
					Type = TestingOutcomeType.Fail
				};
			}

			if (driveInfo.Count(drive => drive.DriveType == DriveType.Fixed && drive.IsReady) > 14)
			{
				return new TestOutcome
				{
					Messages = new List<string> { "Too many drives" },
					Type = TestingOutcomeType.Fail
				};
			}

			return new TestOutcome
			{
				Messages = new List<string> { "Drive configuration Ok" },
				Type = TestingOutcomeType.Pass
			};
		}

		public static TestOutcome CheckDisksPartitions()
		{
			var driveInfo = System.IO.DriveInfo.GetDrives();

			List<string> messages = new List<string>();

			foreach (var disk in driveInfo.Where(diskType => diskType.DriveType == DriveType.Fixed && diskType.IsReady))
			{
				if (disk.DriveFormat != "NTFS")
					messages.Add("One of your fixed disks does not use NTFS");

				var totalSizeGb = disk.TotalSize/1024/1024/1024;
				if (totalSizeGb > 1024) 
				{
					return new TestOutcome
					{
						Messages = new List<string> { "One of your drives is larger than 1TB." },
						Type = TestingOutcomeType.Fail
					};
				}
			}
			var combinedTotalGb =
				driveInfo.Where(disk => disk.DriveType == DriveType.Fixed && disk.IsReady).Sum(disk => disk.TotalSize)/1024/1024/
				1024;

			if ( combinedTotalGb > 10240 && combinedTotalGb < 14336)
			// Total size is over 10TB
			{
				return new TestOutcome
				{
					Messages = new List<string> { "Combined size exceeds 10TB, MCP 2 only." },
					Type = TestingOutcomeType.Warning
				};
			}

			if (combinedTotalGb > 14336)
				// Total size is over 14TB
			{
				return new TestOutcome
				{
					Messages = new List<string> { "Combined size of storage cannot exceed 14TB." },
					Type = TestingOutcomeType.Fail
				};
			}

			int removableCount = driveInfo.Count(diskType => diskType.DriveType == DriveType.Removable && diskType.IsReady);
			if (removableCount > 0)
			{
				messages.Add(string.Format("You have {0} removable drives, they will not be migrated.", removableCount));
			}

			int networkAttachedCount = driveInfo.Count(diskType => diskType.DriveType == DriveType.Network && diskType.IsReady);
			if (networkAttachedCount > 0)
			{
				messages.Add(string.Format("You have {0} network attached drives, they will not be migrated.", networkAttachedCount));
			}
			messages.Add("Test complete");
			return new TestOutcome
			{
				Messages = messages,
				Type = TestingOutcomeType.Pass
			};
		}

		public static TestOutcome CheckNetworking()
		{
			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

			if (nics.Count() > 10)
			{
				return new TestOutcome
				{
					Type = TestingOutcomeType.Fail,
					Messages = new List<string> {"Computer has too many network interfaces"}
				};
			}

			if (nics.Count() > 1)
			{
				return new TestOutcome
				{
					Type = TestingOutcomeType.Warning,
					Messages = new List<string> { "Computer has more than 1 network interface. MCP 2 is required" }
				};
			}

			return new TestOutcome
			{
				Type = TestingOutcomeType.Pass,
				Messages = new List<string> { "Network configuration OK" }
			};
		}

		public static TestOutcome CheckNetworkAddressing()
		{
			List<string> messages = new List<string>();
			foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			{
				if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
				{
					messages.AddRange(from ip in ni.GetIPProperties().UnicastAddresses where ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork where !ip.Address.IsCompatible() select string.Format("{0} will not be included", ip.Address));
				}
			}

			return new TestOutcome
			{
				Type = messages.Count > 0 ? TestingOutcomeType.Warning : TestingOutcomeType.Pass,
				Messages = messages
			};
		}

		public static TestOutcome CheckVmwareTools ()
		{
			// Does VMware tools exist?
			const string vmwareToolsPath = "C:\\Program Files\\VMware\\VMware Tools\\VMwareToolboxCmd.exe";
			if (!File.Exists(vmwareToolsPath))
			{
				return new TestOutcome
				{
					Type = TestingOutcomeType.Warning,
					Messages = new List<string>
					{
						"VMware tools is not installed."
					}
				};
			}

			Process pro = Process.Start(vmwareToolsPath, "-v");
			string output = pro.StandardOutput.ReadToEnd();
			int versionNumber;
			int.TryParse(output, out versionNumber);

			if (versionNumber < 1000)
			{
				return new TestOutcome
				{
					Type = TestingOutcomeType.Warning,
					Messages = new List<string> { "VMware tools is too old." }
				};
			}
			else
			{
				return new TestOutcome
				{
					Type = TestingOutcomeType.Pass,
					Messages = new List<string> { "VMware tools is OK." }
				};
			}
		}

		public static TestOutcome CheckOsVersion()
		{
			switch (Environment.OSVersion.Platform)
			{
				case PlatformID.Win32S:
					return new TestOutcome
					{
						Type = TestingOutcomeType.Fail,
						Messages = new List<string> {"Windows 3.1 not supported."}
					};
				case PlatformID.Win32Windows:
					switch (Environment.OSVersion.Version.Minor)
					{
						case 0:
							return new TestOutcome
							{
								Type = TestingOutcomeType.Fail,
								Messages = new List<string> { "Windows 95 not supported." }
							};
						case 10:
							return new TestOutcome
							{
								Type = TestingOutcomeType.Fail,
								Messages = new List<string> { "Windows 98 not supported." }
							};
						case 90:
							return new TestOutcome
							{
								Type = TestingOutcomeType.Fail,
								Messages = new List<string> { "Windows ME not supported." }
							};
					}
					break;

				case PlatformID.Win32NT:
					switch (Environment.OSVersion.Version.Major)
					{
						case 3:
							return new TestOutcome
							{
								Type = TestingOutcomeType.Fail,
								Messages = new List<string> { "Windows NT 3.5 not supported." }
							};
						case 4:
							return new TestOutcome
							{
								Type = TestingOutcomeType.Fail,
								Messages = new List<string> { "Windows NT 4.0 not supported." }
							};
						case 5:
							switch (Environment.OSVersion.Version.Minor)
							{
								case 0:
									return new TestOutcome
									{
										Type = TestingOutcomeType.Fail,
										Messages = new List<string> { "Windows 2000 not supported." }
									};
								case 1:
									return new TestOutcome
									{
										Type = TestingOutcomeType.Fail,
										Messages = new List<string> { "Windows XP not supported." }
									};
								case 2:
									return new TestOutcome
									{
										Type = TestingOutcomeType.Warning,
										Messages = new List<string> { "Windows Server 2003 not supported on MCP 2." }
									};
							}
							break;

						case 6:
							switch (Environment.OSVersion.Version.Minor)
							{
								case 0:
									return new TestOutcome
									{
										Type = TestingOutcomeType.Pass,
										Messages = new List<string> { "Windows server 2008/Vista supported." }
									};
								case 1:
									return new TestOutcome
									{
										Type = TestingOutcomeType.Pass,
										Messages = new List<string> { "Windows 7/ 2008 Server R2 supported." }
									};
								case 2:
									return new TestOutcome
									{
										Type = TestingOutcomeType.Pass,
										Messages = new List<string> { "Windows 8 / 2012 Server supported." }
									};
								case 3:
									return new TestOutcome
									{
										Type = TestingOutcomeType.Pass,
										Messages = new List<string> { "Windows 8.1 / 2012 Server R2 supported." }
									};
							}
							break;
						case 10:
							return new TestOutcome
							{
								Type = TestingOutcomeType.Fail,
								Messages = new List<string> { "Windows 10 not supported." }
							};
					}
					break;

				case PlatformID.WinCE:
					return new TestOutcome
					{
						Type = TestingOutcomeType.Fail,
						Messages = new List<string> { "Windows CE not supported." }
					};
			}

			return new TestOutcome
							{
								Type = TestingOutcomeType.Fail,
								Messages = new List<string> { "OS not supported." }
							};
		}
	}
}
