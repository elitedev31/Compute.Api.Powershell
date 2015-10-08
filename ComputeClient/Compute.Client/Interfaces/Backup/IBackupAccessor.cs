using System;
using DD.CBU.Compute.Api.Contracts.Server;
using ServerType = DD.CBU.Compute.Api.Contracts.Network20.ServerType;

namespace DD.CBU.Compute.Api.Client.Interfaces.Backup
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Contracts.Backup;
	using Contracts.General;

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
            string clientType,
            string storagePolicy,
            string schedulePolicy,
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
	    /// The modify backup client.
	    /// </summary>
	    /// <param name="serverId">
	    /// The server id.
	    /// </param>
	    /// <param name="backupClientId">The Backup Client Id.</param>
	    /// <param name="schedulePolicyName">The Schedule Policy Name</param>
	    /// <param name="alertingType">
	    /// The alerting type.
	    /// </param>
	    /// <param name="storagePolicyName">The Storage Policy Name</param>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    Task<Status> ModifyBackupClient(
	        string serverId,
	        string backupClientId,
	        string storagePolicyName,
	        string schedulePolicyName,
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

		/// <summary>	In place restore. </summary>
		/// <param name="serverId">	   	The server id. </param>
		/// <param name="backupClient">	The backup client. </param>
		/// <param name="asAtDate">	   	The date and time to recover to. </param>
		/// <returns>	A Status message from the API. </returns>
		Task<Status> InPlaceRestore(string serverId, BackupClientDetailsType backupClient, DateTime asAtDate);

		/// <summary>	In place restore. </summary>
		/// <param name="serverId">		 	The server id. </param>
		/// <param name="backupClientId">	Identifier for the backup client. </param>
		/// <param name="asAtDate">		 	The date and time to recover to. </param>
		/// <returns>	A Status message from the API. </returns>
		Task<Status> InPlaceRestore(string serverId, string backupClientId, DateTime asAtDate);

		/// <summary>	Out of place restore. </summary>
		/// <param name="serverId">	   	The server id. </param>
		/// <param name="backupClient">	The backup client. </param>
		/// <param name="asAtDate">	   	The date and time to recover to. </param>
		/// <param name="targetServer">	Target server. </param>
		/// <returns>	A Status message from the API; </returns>
		Task<Status> OutOfPlaceRestore(string serverId, BackupClientDetailsType backupClient, DateTime asAtDate, ServerWithBackupType targetServer);

		/// <summary>	Out of place restore. </summary>
		/// <param name="serverId">		 	The server id. </param>
		/// <param name="backupClientId">	Identifier for the backup client. </param>
		/// <param name="asAtDate">		 	The date and time to recover to. </param>
		/// <param name="targetServerId">	Identifier for the target client. </param>
		/// <returns>	A Status message from the API; </returns>
		Task<Status> OutOfPlaceRestore(string serverId, string backupClientId, DateTime asAtDate, string targetServerId);

		/// <summary>	Out of place restore. </summary>
		/// <param name="serverId">	   	The server id. </param>
		/// <param name="backupClient">	The backup client. </param>
		/// <param name="asAtDate">	   	The date and time to recover to. </param>
		/// <param name="targetServer">	Target server. </param>
		/// <returns>	A Status message from the API; </returns>
		Task<Status> OutOfPlaceRestore(string serverId, BackupClientDetailsType backupClient, DateTime asAtDate, ServerType targetServer);
	}
}
