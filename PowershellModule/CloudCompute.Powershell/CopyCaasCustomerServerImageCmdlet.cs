// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasExportCustomerImageCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The "New-CaasImportCustomerImage" Cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Image;

namespace DD.CBU.Compute.Powershell
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The Copy Caas Customer Server Image Cmdlet.
    /// </summary>
    /// <remarks>
    ///     Copies the source customer image to Target
    /// </remarks>
    [Cmdlet(VerbsCommon.Copy, "CaasCustomerServerImage")]
	[OutputType(typeof (ImageExportType))]
	public class CopyCaasCustomerServerImageCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the source customer image.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Source customer image.")]
		public ImagesWithDiskSpeedImage SourceImage { get; set; }

        /// <summary>
		///     Gets or sets the target image name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Target image name")]
        public string TargetImageName { get; set; }

        /// <summary>
		///     Gets or sets Image description
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The target description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the network.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The target data centre location for the customer image.")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     Gets or sets the ovf package prefix.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "A prefix for this copy. Must not contain spaces.")]
		public string OvfPrefix { get; set; }

		/// <summary>
		///     Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
                ImageCopyType record = CopyCustomerImage();

				if (record != null)
				{
					WriteObject(record);
				}
			}
			catch (AggregateException ae)
			{
				ae.Handle(
					e =>
					{
						if (e is ComputeApiException)
						{
							WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
						}
						else
						{
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}
		}

		/// <summary>
		///     Copies the customer image to the specified target.
		/// </summary>
		/// <returns>
		///     The copied image details.
		/// </returns>
		private ImageCopyType CopyCustomerImage()
		{
			return Connection.ApiClient.ServerManagementLegacy.ServerImage.CopyCustomerServerImage(SourceImage.id, TargetImageName, Description, Network.location, OvfPrefix).Result;
		}
	}
}