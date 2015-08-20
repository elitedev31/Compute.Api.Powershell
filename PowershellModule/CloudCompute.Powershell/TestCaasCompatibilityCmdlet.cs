using System.Collections.Generic;
using System.Management.Automation;
using x2C;
using x2C.lib;

namespace DD.CBU.Compute.Powershell
{
	[Cmdlet(VerbsDiagnostic.Test, "CaasCompatibility")]
	[OutputType(typeof(TestOutcomeResult[]))]
	public class TestCaasCompatibilityCmdlet : PSCmdlet
	{
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			List<TestOutcomeResult> results = new List<TestOutcomeResult>() 
			{
				new TestOutcomeResult("CPU", CompatibilityTests.CheckCpuConfiguration()),
				new TestOutcomeResult("RAM", CompatibilityTests.CheckRamConfiguration()),
				new TestOutcomeResult("Disk",  CompatibilityTests.CheckDiskCount()),
				new TestOutcomeResult("Parition", CompatibilityTests.CheckDisksPartitions()),
				new TestOutcomeResult("Networking", CompatibilityTests.CheckNetworking()),
				new TestOutcomeResult("IP", CompatibilityTests.CheckNetworkAddressing()),
				new TestOutcomeResult("VMWare",  CompatibilityTests.CheckVmwareTools()),
				new TestOutcomeResult("OS", CompatibilityTests.CheckOsVersion())
			};

			WriteObject(results.ToArray());
		}
	}
}
