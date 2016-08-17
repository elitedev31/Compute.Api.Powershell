// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CaasServerDiskDetails.cs" company="">
//   
// </copyright>
// <summary>
//   The caas server disk details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The caas server disk details.
	/// </summary>
	public class CaasServerDiskDetails
	{
		/// <summary>
		///     Gets or sets the scsi id.
		/// </summary>
		public string ScsiId { get; set; }

		/// <summary>
		///     Gets or sets the speed id.
		/// </summary>
		public string SpeedId { get; set; }
	}
}