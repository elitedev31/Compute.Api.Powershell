// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasBackupPlanCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set backup service plan cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The set backup service plan cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "CaasBackupPlan")]
	[OutputType(typeof (ServerType))]
	public class SetCaasBackupPlanCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
		public ServerType Server { get; set; }

		/// <summary>
		///     Gets or sets the backup service plan.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The service plan of the backup")]
		public ServicePlan BackupServicePlan { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				Status status = Connection.ApiClient.Backup.ChangeBackupPlan(Server.id, BackupServicePlan).Result;

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

			WriteObject(Server);
		}
	}
}