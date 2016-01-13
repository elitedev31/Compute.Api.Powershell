namespace DD.CBU.Compute.Api.Client.ImportExportImages
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Interfaces.ImportExportImages;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Image;
    using DD.CBU.Compute.Api.Contracts.Server;

    /// <summary>
    /// The import export customer image accessor.
    /// </summary>
    public class ImportExportCustomerImageAccessor : IImportExportCustomerImageAccessor
	{
		/// <summary>
		/// The _api client.
		/// </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="ImportExportCustomerImageAccessor"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public ImportExportCustomerImageAccessor(IWebApi apiClient)
		{
			_apiClient = apiClient;
		}

		/// <summary>
		/// The get ovf packages.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<OvfPackages> GetOvfPackages()
		{
			return
				await
					_apiClient.GetAsync<OvfPackages>(
						ApiUris.GetOvfPackages(_apiClient.OrganizationId));
		}

		/// <summary>
		/// The get customer images imports.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<ServerImageWithStateType>> GetCustomerImagesImports()
		{
			ServerImagesWithState imports =
				await
					_apiClient.GetAsync<ServerImagesWithState>(
						ApiUris.GetCustomerImageImports(_apiClient.OrganizationId));
			return imports.serverImageWithState;
		}

		/// <summary>
		/// The get customer images exports.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<ImageExportType>> GetCustomerImagesExports()
		{
			ImageExports result =
				await
					_apiClient.GetAsync<ImageExports>(
						ApiUris.GetCustomerImageExports(_apiClient.OrganizationId));
			return result.imageExport;
		}

		/// <summary>
		/// The get customer images export history.
		/// </summary>
		/// <param name="count">
		/// The count.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<ImageExportRecord>> GetCustomerImagesExportHistory(int count = 20)
		{
			ImageExportHistory result =
				await
				_apiClient.GetAsync<ImageExportHistory>(ApiUris.GetCustomerImageExportHistory(_apiClient.OrganizationId, count));
			return result.imageExportRecord;
		}

		/// <summary>
		/// The import customer image.
		/// </summary>
		/// <param name="customerImageName">
		/// The customer image name.
		/// </param>
		/// <param name="ovfPackageName">
		/// The ovf package name.
		/// </param>
		/// <param name="networkLocation">
		/// The network location.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<ServerImageWithStateType> ImportCustomerImage(
			string customerImageName,
			string ovfPackageName,
			string networkLocation,
			string description)
		{
			return
				await
				_apiClient.PostAsync<NewImageImport, ServerImageWithStateType>(
					ApiUris.ImportCustomerImage(_apiClient.OrganizationId),
					new NewImageImport
						{
							name = customerImageName,
							location = networkLocation,
							ovfPackage = ovfPackageName,
							description = description
						});
		}

		/// <summary>
		/// The export customer image.
		/// </summary>
		/// <param name="image">
		/// The image.
		/// </param>
		/// <param name="ovfPrefix">
		/// The ovf prefix.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<ImageExportType> ExportCustomerImage(ImagesWithDiskSpeedImage image, string ovfPrefix)
		{
			return
				await
				_apiClient.PostAsync<NewImageExport, ImageExportType>(
					ApiUris.ExportCustomerImage(_apiClient.OrganizationId),
					new NewImageExport
						{
							ovfPackagePrefix = ovfPrefix,
							imageId = image.id
						});
        }

        /// <summary>
        /// Copies an OVF package from a remote geo.
        /// </summary>
        /// <param name="newRemoteOvfCopy">
        /// The copy request.
        /// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
        public async Task<Status> CopyOvfPackageFromRemoteGeo(NewRemoteOvfCopy newRemoteOvfCopy)
        {
            return await
                this._apiClient.PostAsync<NewRemoteOvfCopy, Status>(
                    ApiUris.RemoteOvfPackageCopy(this._apiClient.OrganizationId),
                    newRemoteOvfCopy);
        }

        /// <summary>
        /// Gets OVF package copies currently in progress.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<OvfRemoteCopyType>> GetRemoteOvfPackageCopyInProgress()
        {
            var result = await _apiClient.GetAsync<OvfRemoteCopies>(
                ApiUris.GetRemoteOvfPackageCopyInProgress(_apiClient.OrganizationId));
            return result.ovfCopy ?? new OvfRemoteCopyType[0];
        }

        /// <summary>
        /// Gets OVF package copy history.
        /// </summary>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<CopyRemoteOvfPackageRecordType>> GetRemoteOvfPackageCopyHistory(int count = 20)
        {
            var result = await _apiClient.GetAsync<CopyRemoteOvfPackageHistory>(
                ApiUris.GetRemoteOvfPackageCopyHistory(_apiClient.OrganizationId, count));
            return result.copyRemoteOvfPackageRecord ?? new CopyRemoteOvfPackageRecordType[0];
        }
    }
}
