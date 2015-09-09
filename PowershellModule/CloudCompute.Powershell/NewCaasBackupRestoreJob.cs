using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>	A new caas backup restore job. </summary>
	/// <seealso cref="T:DD.CBU.Compute.Powershell.PsCmdletCaasBase"/>
	[Cmdlet(VerbsCommon.New, "CaasBackupRestoreJob")]
	[OutputType(typeof(Status))]
	public class NewCaasBackupRestoreJob
		: PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the server.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server to restore", ParameterSetName = "restoreByObject")]
		public ServerType Server { get; set; }

		/// <summary>	Gets or sets the identifier of the server. </summary>
		/// <value>	The identifier of the server. </value>
		[Parameter(Mandatory = true, HelpMessage = "The ID of the server to restore", ParameterSetName = "restoreById")]
		public Guid ServerId { get; set; }

		/// <summary>
		///     Gets or sets the backup client.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The backup client to restore, must be a file system client", ParameterSetName = "restoreByObject")]
		public BackupClientDetailsType BackupClient { get; set; }

		/// <summary>	Gets or sets the identifier of the backup client. </summary>
		/// <value>	The identifier of the backup client. </value>
		[Parameter(Mandatory = true, HelpMessage = "The backup client Id to restore, must be a file system client", ParameterSetName = "restoreById")]
		public Guid BackupClientId { get; set; }

		/// <summary>	Gets or sets target server. </summary>
		/// <value>	The target server. </value>
		[Parameter(Mandatory = false, HelpMessage = "The target server to restore onto if out of place restore", ParameterSetName = "restoreByObject")]
		public ServerType TargetServer { get; set; }

		/// <summary>	Gets or sets the identifier of the target server. </summary>
		/// <value>	The identifier of the target server. </value>
		[Parameter(Mandatory = false, HelpMessage = "The ID of the target server to restore onto if out of place restore.", ParameterSetName = "restoreById")]
		public Guid TargetServerId { get; set; }

		/// <summary>	Gets or sets as at date. </summary>
		/// <value>	as at date. </value>
		[Parameter(Mandatory = true, HelpMessage = "The date to restore to.")]
		public DateTime AsAtDate { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				Status jobResult = null;
				switch (ParameterSetName)
				{
					case "restoreById":
						if (TargetServerId == Guid.Empty)
						{
							jobResult =
								Connection.ApiClient.Backup.InPlaceRestore(ServerId.ToString(), BackupClientId.ToString(), AsAtDate).Result;
						}
						else
						{
							jobResult =
								Connection.ApiClient.Backup.OutOfPlaceRestore(ServerId.ToString(), BackupClientId.ToString(), AsAtDate, TargetServerId.ToString()).Result;
						}
							
						break;
					case "restoreByObject":
						if (TargetServer == null)
						{
							jobResult =
								Connection.ApiClient.Backup.InPlaceRestore(Server.id, BackupClient, AsAtDate).Result;
						}
						else
						{
							jobResult =
								Connection.ApiClient.Backup.OutOfPlaceRestore(Server.id, BackupClient, AsAtDate, TargetServer).Result;
						}

						break;
				}

				WriteObject(jobResult);
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
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}
		}
	}
}
