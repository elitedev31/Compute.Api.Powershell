namespace DD.CBU.Compute.Api.Client.Server
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Server;
	using DD.CBU.Compute.Api.Contracts.General;
	using DD.CBU.Compute.Api.Contracts.Image;

	/// <summary>
	/// The server images accessor.
	/// </summary>
	public class ServerImagesAccessor : IServerImagesAccessor
	{
		/// <summary>
		/// The _api client.
		/// </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="ServerImagesAccessor"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public ServerImagesAccessor(IWebApi apiClient)
		{
			this._apiClient = apiClient;
		}

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
		public async Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetImages(
			string imageId,
			string name,
			string location,
			string operatingSystemId,
			string operatingSystemFamily)
		{
			ImagesWithDiskSpeed imagesWithDiskSpeed =
				await
				_apiClient.GetAsync<ImagesWithDiskSpeed>(
					ApiUris.ImagesWithDiskSpeed(
						_apiClient.OrganizationId,
						ServerImageType.OS,
						imageId,
						name,
						location,
						operatingSystemId,
						operatingSystemFamily));

			if (imagesWithDiskSpeed == null)
				return null;
			if (imagesWithDiskSpeed.image == null)
				return null;

			return imagesWithDiskSpeed.image;
		}

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
		public async Task<IReadOnlyList<ImagesWithDiskSpeedImage>> GetCustomerServerImages(
			string imageId,
			string name,
			string location,
			string operatingSystemId,
			string operatingSystemFamily)
		{
			ImagesWithDiskSpeed imagesWithDiskSpeed =
				await
				_apiClient.GetAsync<ImagesWithDiskSpeed>(
					ApiUris.ImagesWithDiskSpeed(
						_apiClient.OrganizationId,
						ServerImageType.CUSTOMER,
						imageId,
						name,
						location,
						operatingSystemId,
						operatingSystemFamily));

			if (imagesWithDiskSpeed.image == null)
				return null;

			return imagesWithDiskSpeed.image;
		}

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
	    public async Task<ImageCopyType> CopyCustomerServerImage(
            string imageId,
            string targetImageName,
            string targetImageDescription,
            string targetLocation,
            string ovfPackagePrefix)
        {
            return await _apiClient.PostAsync<NewImageCopy, ImageCopyType>(
                                        ApiUris.CopyCustomerServerImage(_apiClient.OrganizationId),
                                        new NewImageCopy
                                        {
                                            sourceImageId = imageId,
                                            targetImageName = targetImageName,
                                            targetImageDescription = targetImageDescription,
                                            targetLocation = targetLocation,
                                            ovfPackagePrefix = ovfPackagePrefix
                                        });
        }

        /// <summary>
        /// The remove customer server image.
        /// </summary>
        /// <param name="imageId">
        /// The image Id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> RemoveCustomerServerImage(string imageId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.RemoveCustomerServerImage(_apiClient.OrganizationId, imageId));
		}
	}
}
