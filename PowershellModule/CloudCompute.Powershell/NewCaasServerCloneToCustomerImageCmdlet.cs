// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasServerCloneToCustomerImageCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The set server state cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasServerCloneToCustomerImage")]
	public class NewCaasServerCloneToCustomerImageCmdlet : PsCmdletCaasServerBase
	{
		/// <summary>
		/// Customer Image name
		/// </summary>
		[Parameter(Mandatory = true, 
			HelpMessage =
				"Set the customer image name. Note that the Customer Image name is required to be unique in a given data center.")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Set the customer image description")]
		public string Description { get; set; }

		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			try
			{
				Status status = Connection.ApiClient.ServerCloneToCustomerImage(Server.id, Name, Description).Result;
				if (status != null)
					WriteDebug(
						string.Format(
							"{0} resulted in {1} ({2}): {3}", 
							status.operation, 
							status.result, 
							status.resultCode, 
							status.resultDetail));
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

			base.ProcessRecord();
		}
	}
}