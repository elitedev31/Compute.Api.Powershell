// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasAccountPrimaryAdministratorCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set caas account primary administrator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The set caas account primary administrator.
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "CaasAccountPrimaryAdministrator")]
	public class SetCaasAccountPrimaryAdministrator : PsCmdletCaasBase
	{
		/// <summary>
		///     The account username to be primary administrator
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The account username to be primary administrator")]
		public string Username { get; set; }

		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			try
			{
				Status status = Connection.ApiClient.Account.DesignatePrimaryAdministratorAccount(Username).Result;

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