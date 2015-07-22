namespace DD.CBU.Compute.Api.Client.Interfaces.Server
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Image;

	/// <summary>
	/// The ServerImagesAccessor interface.
	/// </summary>
	public interface IServerImagesAccessor
	{
		/// <summary>
		/// The get images.
		/// </summary>
		/// <param name="imageId">
		/// The image id.
		/// </param>
		/// <param name="name">
		/// The name.
		/// </param>
		/// <param name="location">
		/// The location.
		/// </param>
		/// <param name="operatingSystemId">
		/// The operating system id.
		/// </param>
		/// <param name="operatingSystemFamily">
		/// The operating system family.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetImages(
		 string imageId,
		 string name,
		 string location,
		 string operatingSystemId,
		 string operatingSystemFamily);

		/// <summary>
		/// The remove customer server image.
		/// </summary>
		/// <param name="imageid">
		/// The imageid.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemoveCustomerServerImage(string imageid);		
	}
}
