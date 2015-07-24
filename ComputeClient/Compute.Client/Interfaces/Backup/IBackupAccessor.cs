namespace DD.CBU.Compute.Api.Client.Interfaces.Backup
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.Backup;
	using DD.CBU.Compute.Api.Contracts.General;

	/// <summary>
	/// The BackupAccessor interface.
	/// </summary>
	public interface IBackupAccessor
	{
		/// <summary>
		/// The enable backup.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="plan">
		/// The plan.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> EnableBackup(string serverId, ServicePlan plan);

		/// <summary>
		/// The disable backup.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> DisableBackup(string serverId);

		/// <summary>
		/// The change backup plan.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="plan">
		/// The plan.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ChangeBackupPlan(string serverId, ServicePlan plan);

		/// <summary>
		/// The get backup client types.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<BackupClientType>> GetBackupClientTypes(string serverId);

		/// <summary>
		/// The get backup storage policies.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<BackupStoragePolicy>> GetBackupStoragePolicies(string serverId);

		/// <summary>
		/// The get backup schedule policies.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<BackupSchedulePolicy>> GetBackupSchedulePolicies(string serverId);

		/// <summary>
		/// The get backup clients.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<BackupClientDetailsType>> GetBackupClients(string serverId);

		/// <summary>
		/// The add backup client.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="clientType">
		/// The client type.
		/// </param>
		/// <param name="storagePolicy">
		/// The storage policy.
		/// </param>
		/// <param name="schedulePolicy">
		/// The schedule policy.
		/// </param>
		/// <param name="alertingType">
		/// The alerting type.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> AddBackupClient(
			string serverId,
			BackupClientType clientType,
			BackupStoragePolicy storagePolicy,
			BackupSchedulePolicy schedulePolicy,
			AlertingType alertingType);

		/// <summary>
		/// The remove backup client.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="backupClient">
		/// The backup client.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> RemoveBackupClient(string serverId, BackupClientDetailsType backupClient);

		/// <summary>
		/// The modify backup client.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="backupClient">
		/// The backup client.
		/// </param>
		/// <param name="storagePolicy">
		/// The storage policy.
		/// </param>
		/// <param name="schedulePolicy">
		/// The schedule policy.
		/// </param>
		/// <param name="alertingType">
		/// The alerting type.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> ModifyBackupClient(
			string serverId,
			BackupClientDetailsType backupClient,
			BackupStoragePolicy storagePolicy,
			BackupSchedulePolicy schedulePolicy,
			AlertingType alertingType);

		/// <summary>
		/// The initiate backup.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="backupClient">
		/// The backup client.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> InitiateBackup(string serverId, BackupClientDetailsType backupClient);

		/// <summary>
		/// The cancel backup job.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <param name="backupClient">
		/// The backup client.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> CancelBackupJob(string serverId, BackupClientDetailsType backupClient);
	}
}
