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
using DD.CBU.Compute.Api.Client.ImportExportImages;
using DD.CBU.Compute.Api.Contracts.Image;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The "New-CaasImportCustomerImage" Cmdlet.
	/// </summary>
	/// <remarks>
	/// Imports a new customer image.
	/// </remarks>
	[Cmdlet(VerbsCommon.New, "CaasExportCustomerImage")]
	[OutputType(typeof (ImageExportType))]
	public class NewCaasExportCustomerImageCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the customer image.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Customer Image.")]
		public ImagesWithDiskSpeedImage CustomerImage { get; set; }

		/// <summary>
		/// Gets or sets the ovf prefix.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "A prefix for this export. Must not contain spaces.")]
		public string OvfPrefix { get; set; }

		/// <summary>
		/// Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				ImageExportType record = ExportCustomerImage();

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
// if (e is HttpRequestException)
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}
		}

		/// <summary>
		/// Exports the customer image to the FTP store.
		/// </summary>
		/// <returns>
		/// The export details.
		/// </returns>
		private ImageExportType ExportCustomerImage()
		{
			return Connection.ApiClient.ExportCustomerImage(CustomerImage, OvfPrefix).Result;
		}
	}
}