
namespace x2C
{
	public class DiskSpec
	{
		public int ScsiId { get; set; }

		public long SizeGb { get; set; }

		public DD.CBU.Compute.Api.Contracts.Server.DiskSpeedType DiskSpeed { get; set; }
	}
}
