namespace DD.CBU.Compute.Api.Client.ImportExportImages
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Contracts.Image;
	using DD.CBU.Compute.Api.Contracts.Server;

	/// <summary>
	/// Extension methods for the "import and export of customer images" section of the CaaS API.
	/// </summary>
	public static class ComputeApiClientImportExportExtensions
	{
		/// <summary>
		/// Gets the OVF Packages that have been uploaded to the FTPS account for the supplied organization ID.
		///     An empty list will be returned if no OVF Packages have been uploaded by the organization.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <returns>
		/// The OVF Packages
		/// </returns>
		[Obsolete("Use IComputeApiClient.ImportExportCustomerImage instead")]
		public static async Task<OvfPackages> GetOvfPackages(this IComputeApiClient client)
		{
			return await client.ImportExportCustomerImage.GetOvfPackages();
		}

		/// <summary>
		/// This function identifies the Customer Image Imports that are in progress for the supplied organization ID.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <returns>
		/// The customer image imports currently in progress
		/// </returns>
		[Obsolete("Use IComputeApiClient.ImportExportCustomerImage instead")]
		public static async Task<IEnumerable<ServerImageWithStateType>> GetCustomerImagesImports(
			this IComputeApiClient client)
		{
			return await client.ImportExportCustomerImage.GetCustomerImagesImports();
		}

		/// <summary>
		/// This function identifies the Customer Image Exports that are in progress for the supplied organization ID.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <returns>
		/// The customer image exports currently in progress
		/// </returns>
		[Obsolete("Use IComputeApiClient.ImportExportCustomerImage instead")]
		public static async Task<IEnumerable<ImageExportType>> GetCustomerImagesExports(this IComputeApiClient client)
		{
			return await client.ImportExportCustomerImage.GetCustomerImagesExports();
		}

		/// <summary>
		/// This function identifies the Customer Image Export history for the supplied organization ID.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="count">
		/// The count.
		/// </param>
		/// <returns>
		/// The customer image exports
		/// </returns>
		[Obsolete("Use IComputeApiClient.ImportExportCustomerImage instead")]
		public static async Task<IEnumerable<ImageExportRecord>> GetCustomerImagesExportHistory(
			this IComputeApiClient client, 
			int count = 20)
		{
			return await client.ImportExportCustomerImage.GetCustomerImagesExportHistory(count);
		}

		/// <summary>
		/// Starts the process of importing an OVF Package to become a new Customer Image for the supplied organization ID.
		///     This function takes the full name (including the “.mf” file suffix) of the manifest file identifying the OVF
		///     Package to import as a new Customer Image.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="customerImageName">
		/// 1-75 characters in length.
		///     The permitted character set is (within and excluding the quotes): “a-zA-Z0-9_+=# .,:;()-“.
		///     Note that the “space” character is permitted
		/// </param>
		/// <param name="ovfPackageName">
		/// References a manifest identifying an OVF Package on the organization’s FTPS account.
		///     Maximum length 75 characters.
		///     The permitted character set is (within and excluding the quotes): “a-zA-Z0-9_+=#.,:;()-“.
		///     Note that the “space” character is not permitted
		/// </param>
		/// <param name="networkLocation">
		/// Identifies the target data center location for the Customer Image.
		///     The target data center must reside within the same Geographic Region
		/// </param>
		/// <param name="description">
		/// 0-255 characters in length.
		/// </param>
		/// <returns>
		/// Returns the ServerImageWithState object
		/// </returns>
		[Obsolete("Use IComputeApiClient.ImportExportCustomerImage instead")]
		public static async Task<ServerImageWithStateType> ImportCustomerImage(
			this IComputeApiClient client,
			string customerImageName,
			string ovfPackageName,
			string networkLocation,
			string description)
		{
			return
				await
				client.ImportExportCustomerImage.ImportCustomerImage(
					customerImageName,
					ovfPackageName,
					networkLocation,
					description);
		}

		/// <summary>
		/// Exports the customer image to the FTPS store
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="image">
		/// The image to export.
		/// </param>
		/// <param name="ovfPrefix">
		/// Required; 1-90 characters in length. Used to name each of the constituent files of the
		///     resulting OVF Package. The permitted character set is (within and excluding the
		///     quotes): “a-zA-Z0-9_+=#.,:;()-“. Note that the “space” character is not permitted.
		/// </param>
		/// <returns>
		/// The image export record, with the target names.
		/// </returns>
		[Obsolete("Use IComputeApiClient.ImportExportCustomerImage instead")]
		public static async Task<ImageExportType> ExportCustomerImage(
			this IComputeApiClient client,
			ImagesWithDiskSpeedImage image,
			string ovfPrefix)
		{
			return await client.ImportExportCustomerImage.ExportCustomerImage(image, ovfPrefix);
		}
	}
}