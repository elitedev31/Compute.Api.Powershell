// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasBackupClientCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Remove backup client cmdlet.
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
	///     The Remove backup client cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasBackupClient", SupportsShouldProcess = true)]
	public class RemoveCaasBackupClientCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server to remove the backup client from", 
			ValueFromPipeline = true)]
		public ServerType Server { get; set; }

		/// <summary>
		///     Gets or sets the backup client.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The backup client details to remove")]
		public BackupClientDetailsType BackupClient { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				if (!ShouldProcess(BackupClient.id)) return;
				RemoveBackupClient();
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
		///     Removes a backup client from the server
		/// </summary>
		private void RemoveBackupClient()
		{
			Status status = Connection.ApiClient.Backup.RemoveBackupClient(Server.id, BackupClient).Result;
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
	}
}