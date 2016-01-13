namespace DD.CBU.Compute.Api.Client.Interfaces.ImportExportImages
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Image;
    using DD.CBU.Compute.Api.Contracts.Server;

    /// <summary>
    /// The ImportExportCustomerImageAccessor interface.
    /// </summary>
    public interface IImportExportCustomerImageAccessor
	{
		/// <summary>
		/// The get ovf packages.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<OvfPackages> GetOvfPackages();

		/// <summary>
		/// The get customer images imports.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<ServerImageWithStateType>> GetCustomerImagesImports();

		/// <summary>
		/// The get customer images exports.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<ImageExportType>> GetCustomerImagesExports();

		/// <summary>
		/// The get customer images export history.
		/// </summary>
		/// <param name="count">
		/// The count.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<ImageExportRecord>> GetCustomerImagesExportHistory(int count = 20);

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
		Task<ServerImageWithStateType> ImportCustomerImage(
			string customerImageName,
			string ovfPackageName,
			string networkLocation,
			string description);

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
		Task<ImageExportType> ExportCustomerImage(
			ImagesWithDiskSpeedImage image,
			string ovfPrefix);

        /// <summary>
        /// Copies an OVP package from a remote geo.
        /// </summary>
        /// <param name="newRemoteOvfCopy">
        /// The copy request.
        /// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
        Task<Status> RemoteOvfPackageCopy(NewRemoteOvfCopy newRemoteOvfCopy);
    }
}
