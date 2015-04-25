// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasAccountCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The remove account cmdlet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The remove account cmdlet
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasAccount", SupportsShouldProcess = true)]
	public class RemoveCaasAccountCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// The username to be deleted
		/// </summary>
		[Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, 
			HelpMessage = "The account username to be deleted")]
		public string Username { get; set; }

		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			try
			{
				if (!ShouldProcess(Username)) return;
				Status status = Connection.ApiClient.DeleteSubAdministratorAccount(Username).Result;

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
		}
	}
}