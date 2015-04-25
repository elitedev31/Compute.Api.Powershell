// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasBackupJobCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The New-Backup now job cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Globalization;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Backup;
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The New-Backup now job cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasBackupJob")]
	[OutputType(typeof (ServerWithBackupType))]
	public class NewCaasBackupJobCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server to modify the backup client", 
			ValueFromPipeline = true)]
		public ServerWithBackupType Server { get; set; }

		/// <summary>
		/// Gets or sets the backup client.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The backup client details to modify")]
		public BackupClientDetailsType BackupClient { get; set; }

		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				RunBackupNow();
				WriteObject(Server);
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
		/// Modify a backup client
		/// </summary>
		private void RunBackupNow()
		{
			Status status = Connection.ApiClient.InitiateBackup(Server.id, BackupClient).Result;
			if (status != null)
			{
				WriteDebug(
					string.Format(CultureInfo.CurrentCulture, 
						"{0} resulted in {1} ({2}): {3}", 
						status.operation, 
						status.result, 
						status.resultCode, 
						status.resultDetail));
			}
		}
	}
}