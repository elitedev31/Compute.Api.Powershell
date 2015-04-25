// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CaasServerDetails.cs" company="">
//   
// </copyright>
// <summary>
//   The caas server details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using DD.CBU.Compute.Api.Contracts.Image;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The caas server details.
	/// </summary>
	public class CaasServerDetails
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the administrator password.
		/// </summary>
		public string AdministratorPassword { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether is started.
		/// </summary>
		public bool IsStarted { get; set; }

		/// <summary>
		/// Gets or sets the network.
		/// </summary>
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		public ImagesWithDiskSpeedImage Image { get; set; }

		/// <summary>
		/// Gets or sets the private ip.
		/// </summary>
		public string PrivateIp { get; set; }

		/// <summary>
		/// Gets or sets the internal disk details.
		/// </summary>
		internal List<CaasServerDiskDetails> InternalDiskDetails { get; set; }

		/// <summary>
		/// Gets the disk details.
		/// </summary>
		public CaasServerDiskDetails[] DiskDetails
		{
			get
			{
				if (InternalDiskDetails != null)
					return InternalDiskDetails.ToArray();
				return null;
			}
		}
	}
}