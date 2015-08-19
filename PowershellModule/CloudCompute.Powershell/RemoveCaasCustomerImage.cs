// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasCustomerImage.cs" company="">
//   
// </copyright>
// <summary>
//   The Remove NAT Rule cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Image;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The Remove NAT Rule cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasCustomerImage", SupportsShouldProcess = true)]
	public class RemoveCaasCustomerImageCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     Gets or sets the server image.
		/// </summary>
		[Parameter(Mandatory = true, ValueFromPipeline = true, 
			HelpMessage = "The server image retrieved by Get-CaasCustomerImages")]
		public ImagesWithDiskSpeedImage ServerImage { get; set; }


		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				if (!ShouldProcess(ServerImage.name)) return;
				Status status =
					Connection.ApiClient.ServerManagementLegacy.ServerImage.RemoveCustomerServerImage(ServerImage.id).Result;

				if (status != null)
				{
					WriteDebug(
						string.Format(
							"{0} resulted in {1} ({2}): {3}", 
							status.operation, 
							status.result, 
							status.resultCode, 
							status.resultDetail));
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
	}
}