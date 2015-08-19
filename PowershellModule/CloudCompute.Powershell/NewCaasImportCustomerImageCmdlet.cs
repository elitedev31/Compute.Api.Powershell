// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasImportCustomerImageCmdlet.cs" company="">
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
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The "New-CaasImportCustomerImage" Cmdlet.
	/// </summary>
	/// <remarks>
	/// Imports a new customer image.
	/// </remarks>
	[Cmdlet(VerbsCommon.New, "CaasImportCustomerImage")]
	[OutputType(typeof (ServerImageWithStateType))]
	public class NewCaasImportCustomerImageCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the customer image name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Customer Image name.")]
		public string CustomerImageName { get; set; }

		/// <summary>
		/// Gets or sets the ovf package.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "An OVF Package on the organization’s FTPS account")]
		public OvfPackageType OvfPackage { get; set; }

		/// <summary>
		/// Gets or sets the network.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The target data centre location for the customer image.")]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[Parameter(HelpMessage = "The description")]
		public string Description { get; set; }

		/// <summary>
		/// Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				ServerImageWithStateType serverImage = ImportCustomerImage();

				if (serverImage != null)
				{
					WriteObject(serverImage);
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
		/// The import customer image.
		/// </summary>
		/// <returns>
		/// The <see cref="ServerImageWithStateType"/>.
		/// </returns>
		private ServerImageWithStateType ImportCustomerImage()
		{
			return
				Connection.ApiClient.ImportExportCustomerImage.ImportCustomerImage(CustomerImageName, OvfPackage.name, Network.location, Description).Result;
		}
	}
}