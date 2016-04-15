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
		/// The get customer server images.
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
		Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetCustomerServerImages(
			string imageId,
			string name,
			string location,
			string operatingSystemId,
			string operatingSystemFamily);

	    /// <summary>
	    /// The copy customer image
	    /// </summary>
	    /// <param name="imageId">
	    /// The source image id.
	    /// </param>
	    /// <param name="targetImageName">Target Image Name</param>
	    /// <param name="targetImageDescription">Target Image Description</param>
	    /// <param name="targetLocation">Target Location</param>
	    /// <param name="ovfPackagePrefix">OVF Package Prefix</param>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>	
	    Task<ImageCopyType> CopyCustomerServerImage(
	        string imageId,
	        string targetImageName,
	        string targetImageDescription,
	        string targetLocation,
	        string ovfPackagePrefix);

        /// <summary>
        /// Returns all the customer images being copied.
        /// </summary>
        /// <returns>list of images being copied</returns>
        Task<IReadOnlyList<ImageCopyType>> GetCustomerServerImageBeingCopied();

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

	    /// <summary>
	    /// The clean failed customer server image.
	    /// </summary>
	    /// <param name="imageid">
	    /// The imageid.
	    /// </param>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    Task<Status> CleanFailedCustomerServerImage(string imageid);
    }
}
