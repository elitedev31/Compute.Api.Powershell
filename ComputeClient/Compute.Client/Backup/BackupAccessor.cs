using System;
using DD.CBU.Compute.Api.Contracts.Server;
using ServerType = DD.CBU.Compute.Api.Contracts.Network20.ServerType;

namespace DD.CBU.Compute.Api.Client.Backup
{
	using System.Collections.Generic;
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
			return
				await _apiClient.GetAsync<Status>(ApiUris.CancelBackupJobs(_apiClient.OrganizationId, serverId, backupClient.id));
		}

		/// <summary>	In place restore. </summary>
		/// <param name="serverId">	   	The server id. </param>
		/// <param name="backupClient">	The backup client. </param>
		/// <param name="asAtDate">	   	The date and time to recover to. </param>
		/// <returns>	A Status message from the API. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Backup.IBackupAccessor.InPlaceRestore(BackupClientDetailsType,DateTime)"/>
		public async Task<Status> InPlaceRestore(string serverId, BackupClientDetailsType backupClient, DateTime asAtDate)
		{
			return await InPlaceRestore(serverId, backupClient.id, asAtDate);
		}

		/// <summary>	In place restore. </summary>
		/// <param name="serverId">		 	The server id. </param>
		/// <param name="backupClientId">	Identifier for the backup client. </param>
		/// <param name="asAtDate">		 	The date and time to recover to. </param>
		/// <returns>	A Status message from the API. </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Backup.IBackupAccessor.InPlaceRestore(string,string,DateTime)"/>
		public async Task<Status> InPlaceRestore(string serverId, string backupClientId, DateTime asAtDate)
		{
			return
				await
					_apiClient.PostAsync<RestoreBackup, Status>(ApiUris.RestoreBackup(_apiClient.OrganizationId, serverId, backupClientId),
						new RestoreBackup
						{
							asAtDate = asAtDate,
							asAtDateSpecified = true
						});
		}

		/// <summary>	Out of place restore. </summary>
		/// <param name="serverId">	   	The server id. </param>
		/// <param name="backupClient">	The backup client. </param>
		/// <param name="asAtDate">	   	The date and time to recover to. </param>
		/// <param name="targetServer">	Target client. </param>
		/// <returns>	A Status message from the API; </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Backup.IBackupAccessor.OutOfPlaceRestore(string,BackupClientDetailsType,DateTime,BackupClientDetailsType)"/>
		public async Task<Status> OutOfPlaceRestore(string serverId, BackupClientDetailsType backupClient, DateTime asAtDate, ServerWithBackupType targetServer)
		{
			return await this.OutOfPlaceRestore(serverId, backupClient.id, asAtDate, targetServer.id);
		}

		/// <summary>	Out of place restore. </summary>
		/// <param name="serverId">		 	The server id. </param>
		/// <param name="backupClientId">	Identifier for the backup client. </param>
		/// <param name="asAtDate">		 	The date and time to recover to. </param>
		/// <param name="targetServerId">	Identifier for the target client. </param>
		/// <returns>	A Status message from the API; </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Backup.IBackupAccessor.OutOfPlaceRestore(string,string,DateTime,string)"/>
		public async Task<Status> OutOfPlaceRestore(string serverId, string backupClientId, DateTime asAtDate, string targetServerId)
		{
			return
				await
					_apiClient.PostAsync<RestoreBackup, Status>(ApiUris.RestoreBackup(_apiClient.OrganizationId, serverId, backupClientId),
						new RestoreBackup
						{
							asAtDate = asAtDate,
							asAtDateSpecified = true,
							targetServerId = targetServerId
						});
		}

		/// <summary>	Out of place restore. </summary>
		/// <param name="serverId">	   	The server id. </param>
		/// <param name="backupClient">	The backup client. </param>
		/// <param name="asAtDate">	   	The date and time to recover to. </param>
		/// <param name="targetServer">	Target server. </param>
		/// <returns>	A Status message from the API; </returns>
		/// <seealso cref="M:DD.CBU.Compute.Api.Client.Interfaces.Backup.IBackupAccessor.OutOfPlaceRestore(string,BackupClientDetailsType,DateTime,ServerType)"/>
		public async Task<Status> OutOfPlaceRestore(string serverId, BackupClientDetailsType backupClient, DateTime asAtDate, ServerType targetServer)
		{
			return await this.OutOfPlaceRestore(serverId, backupClient.id, asAtDate, targetServer.id);
		}
	}
}
