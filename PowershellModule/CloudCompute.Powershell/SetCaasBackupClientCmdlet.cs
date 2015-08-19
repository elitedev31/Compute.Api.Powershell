// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasBackupClientCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Set backup client cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Backup;
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The Set backup client cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "CaasBackupClient")]
	[OutputType(typeof (ServerType))]
	public class SetCaasBackupClientCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server to modify the backup client", 
			ValueFromPipeline = true)]
		public ServerType Server { get; set; }

		/// <summary>
		/// Gets or sets the backup client.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The backup client details to modify")]
		public BackupClientDetailsType BackupClient { get; set; }

		/// <summary>
		/// Gets or sets the storage policy.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The storage policy to modify")]
		public BackupStoragePolicy StoragePolicy { get; set; }

		/// <summary>
		/// Gets or sets the schedule policy.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The schedule policy to modify")]
		public BackupSchedulePolicy SchedulePolicy { get; set; }

		/// <summary>
		/// Gets or sets the aletring.
		/// </summary>
		[Parameter(HelpMessage = "The alerting type to modify")]
		public AlertingType Aletring { get; set; }

		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				ModifyBackupClient();
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
		private void ModifyBackupClient()
		{
			Status status =
				Connection.ApiClient.Backup.ModifyBackupClient(Server.id, BackupClient, StoragePolicy, SchedulePolicy, Aletring).Result;
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