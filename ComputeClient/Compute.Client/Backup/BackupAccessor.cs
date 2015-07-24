namespace DD.CBU.Compute.Api.Client.Backup
{
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Backup;
	using DD.CBU.Compute.Api.Contracts.Backup;
	using DD.CBU.Compute.Api.Contracts.General;

	/// <summary>
	/// The backup accessor.
	/// </summary>
	public class BackupAccessor : IBackupAccessor
	{
		/// <summary>
		/// The _api client.
		/// </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="BackupAccessor"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public BackupAccessor(IWebApi apiClient)
		{
			this._apiClient = apiClient;
		}

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
		public async Task<Status> EnableBackup(string serverId, ServicePlan plan)
		{
			return
				await
				_apiClient.PostAsync<NewBackup, Status>(
					ApiUris.EnableBackup(_apiClient.OrganizationId, serverId),
					new NewBackup
						{
							servicePlan = plan
						});
		}

		/// <summary>
		/// The disable backup.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> DisableBackup(string serverId)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.DisableBackup(_apiClient.OrganizationId, serverId));
		}

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
		public async Task<Status> ChangeBackupPlan(string serverId, ServicePlan plan)
		{
			return
				await
				_apiClient.PostAsync<ModifyBackup, Status>(
					ApiUris.ChangeBackupPlan(_apiClient.OrganizationId, serverId),
					new ModifyBackup
					{
						servicePlan = plan
					});
		}

		/// <summary>
		/// The get backup client types.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<BackupClientType>> GetBackupClientTypes(string serverId)
		{
			BackupClientTypes types =
				await _apiClient.GetAsync<BackupClientTypes>(ApiUris.BackupClientTypes(_apiClient.OrganizationId, serverId));
			return types.Items;
		}

		/// <summary>
		/// The get backup storage policies.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<BackupStoragePolicy>> GetBackupStoragePolicies(string serverId)
		{
			BackupStoragePolicies types =
				await _apiClient.GetAsync<BackupStoragePolicies>(ApiUris.BackupStoragePolicies(_apiClient.OrganizationId, serverId));
			return types.Items;

		}

		/// <summary>
		/// The get backup schedule policies.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<BackupSchedulePolicy>> GetBackupSchedulePolicies(string serverId)
		{
			BackupSchedulePolicies types =
				await
				_apiClient.GetAsync<BackupSchedulePolicies>(ApiUris.BackupSchedulePolicies(_apiClient.OrganizationId, serverId));
			return types.Items;
		}

		/// <summary>
		/// The get backup clients.
		/// </summary>
		/// <param name="serverId">
		/// The server id.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<BackupClientDetailsType>> GetBackupClients(string serverId)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server id must not be null or empty");
			BackupDetails details =
				await _apiClient.GetAsync<BackupDetails>(ApiUris.GetBackupDetails(_apiClient.OrganizationId, serverId));
			return details.backupClient;
		}

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
		public async Task<Status> AddBackupClient(
			string serverId,
			BackupClientType clientType,
			BackupStoragePolicy storagePolicy,
			BackupSchedulePolicy schedulePolicy,
			AlertingType alertingType)
		{
			Contract.Requires(!string.IsNullOrEmpty(serverId), "Server id cannot be null or empty");
			Contract.Requires(clientType != null, "Client type cannot be null");
			Contract.Requires(storagePolicy != null, "Storage policy cannot be null");
			Contract.Requires(schedulePolicy != null, "Schedule policy cannot be null");

			return
				await
				_apiClient.PostAsync<NewBackupClient, Status>(
					ApiUris.AddBackupClient(_apiClient.OrganizationId, serverId),
					new NewBackupClient
						{
							schedulePolicyName = schedulePolicy.name,
							storagePolicyName = storagePolicy.name,
							type = clientType.type,
							alerting = alertingType
						});
		}

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
		public async Task<Status> RemoveBackupClient(string serverId, BackupClientDetailsType backupClient)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server cannot be null or empty");
			Contract.Requires(backupClient != null, "Backup client cannot be null");

			return
				await _apiClient.GetAsync<Status>(ApiUris.RemoveBackupClient(_apiClient.OrganizationId, serverId, backupClient.id));
		}

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
		public async Task<Status> ModifyBackupClient(
			string serverId,
			BackupClientDetailsType backupClient,
			BackupStoragePolicy storagePolicy,
			BackupSchedulePolicy schedulePolicy,
			AlertingType alertingType)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server cannot be null or empty");
			Contract.Requires(backupClient != null, "Backup client cannot be null");

			return
				await
				_apiClient.PostAsync<ModifyBackupClient, Status>(
					ApiUris.ModifyBackupClient(_apiClient.OrganizationId, serverId, backupClient.id),
					new ModifyBackupClient
						{
							schedulePolicyName = schedulePolicy.name,
							storagePolicyName = storagePolicy.name,
							alerting = alertingType
						});
		}

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
		public async Task<Status> InitiateBackup(string serverId, BackupClientDetailsType backupClient)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server cannot be null or empty");
			Contract.Requires(backupClient != null, "Backup client cannot be null");

			return
				await _apiClient.GetAsync<Status>(ApiUris.InitiateBackup(_apiClient.OrganizationId, serverId, backupClient.id));
		}

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
		public async Task<Status> CancelBackupJob(string serverId, BackupClientDetailsType backupClient)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server cannot be null or empty");
			Contract.Requires(backupClient != null, "Backup client cannot be null");

			return
				await _apiClient.GetAsync<Status>(ApiUris.CancelBackupJobs(_apiClient.OrganizationId, serverId, backupClient.id));
		}
	}
}
