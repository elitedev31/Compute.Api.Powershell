using DD.CBU.Compute.Api.Contracts.Server;

namespace x2C
{
	public class DiskSpec
	{
		public int ScsiId { get; set; }

		public long SizeGb { get; set; }

		public DiskSpeedType DiskSpeed { get; set; }
	}
}
