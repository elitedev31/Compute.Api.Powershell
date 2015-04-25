// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComputeApiClientBackupExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   Extension methods for the backup section of the CaaS API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Api.Client.Backup
{
	/// <summary>
	/// Extension methods for the backup section of the CaaS API.
	/// </summary>
	public static class ComputeApiClientBackupExtensions
	{
		/// <summary>
		/// Enables the backup with a specific service plan.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="plan">
		/// The enumerated service plan
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<Status> EnableBackup(this IComputeApiClient client, string serverId, ServicePlan plan)
		{
			return
				await
					client.WebApi.ApiPostAsync<NewBackup, Status>(
						ApiUris.EnableBackup(client.Account.OrganizationId, serverId), 
						new NewBackup {servicePlan = plan});
		}

		/// <summary>
		/// Disable the backup service from the server.
		///     <remarks>
		/// Note the server MUST not have any clients
		/// </remarks>
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<Status> DisableBackup(this IComputeApiClient client, string serverId)
		{
			return await client.WebApi.ApiGetAsync<Status>(ApiUris.DisableBackup(client.Account.OrganizationId, serverId));
		}

		/// <summary>
		/// Modify the backup service plan.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="plan">
		/// The plan to change to
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<Status> ChangeBackupPlan(this IComputeApiClient client, string serverId, ServicePlan plan)
		{
			return
				await
					client.WebApi.ApiPostAsync<ModifyBackup, Status>(
						ApiUris.ChangeBackupPlan(client.Account.OrganizationId, serverId), 
						new ModifyBackup {servicePlan = plan});
		}

		/// <summary>
		/// List the client types for a specified server
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<IEnumerable<BackupClientType>> GetBackupClientTypes(this IComputeApiClient client, 
			string serverId)
		{
			BackupClientTypes types =
				await
					client.WebApi.ApiGetAsync<BackupClientTypes>(ApiUris.BackupClientTypes(client.Account.OrganizationId, serverId));
			return types.Items;
		}

		/// <summary>
		/// List the storage policies for a specified server
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<IEnumerable<BackupStoragePolicy>> GetBackupStoragePolicies(this IComputeApiClient client, 
			string serverId)
		{
			BackupStoragePolicies types =
				await
					client.WebApi.ApiGetAsync<BackupStoragePolicies>(ApiUris.BackupStoragePolicies(client.Account.OrganizationId, 
						serverId));
			return types.Items;
		}

		/// <summary>
		/// List the schedule policies for a specified server
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<IEnumerable<BackupSchedulePolicy>> GetBackupSchedulePolicies(this IComputeApiClient client, 
			string serverId)
		{
			BackupSchedulePolicies types =
				await
					client.WebApi.ApiGetAsync<BackupSchedulePolicies>(ApiUris.BackupSchedulePolicies(client.Account.OrganizationId, 
						serverId));
			return types.Items;
		}

		/// <summary>
		/// Gets a list of backup clients.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <returns>
		/// A list of backup clients
		/// </returns>
		public static async Task<IEnumerable<BackupClientDetailsType>> GetBackupClients(
			this IComputeApiClient client, 
			string serverId)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server id must not be null or empty");

			BackupDetails details =
				await
					client.WebApi.ApiGetAsync<BackupDetails>(ApiUris.GetBackupDetails(client.Account.OrganizationId, serverId));
			return details.backupClient;
		}

		/// <summary>
		/// Adds a backup client to a specified server.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="clientType">
		/// The backup client type to add
		/// </param>
		/// <param name="storagePolicy">
		/// The backup storage policy
		/// </param>
		/// <param name="schedulePolicy">
		/// The backup schedule policy
		/// </param>
		/// <param name="alertingType">
		/// The alerting type
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<Status> AddBackupClient(
			this IComputeApiClient client, 
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
					client.WebApi.ApiPostAsync<NewBackupClient, Status>(
						ApiUris.AddBackupClient(client.Account.OrganizationId, serverId), 
						new NewBackupClient
						{
							schedulePolicyName = schedulePolicy.name, 
							storagePolicyName = storagePolicy.name, 
							type = clientType.type, 
							alerting = alertingType
						});
		}

		/// <summary>
		/// Removes the backup client from a specified server.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="backupClient">
		/// The backup client to remove
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<Status> RemoveBackupClient(
			this IComputeApiClient client, 
			string serverId, 
			BackupClientDetailsType backupClient)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server cannot be null or empty");
			Contract.Requires(backupClient != null, "Backup client cannot be null");

			return
				await
					client.WebApi.ApiGetAsync<Status>(
						ApiUris.RemoveBackupClient(client.Account.OrganizationId, serverId, backupClient.id));
		}

		/// <summary>
		/// Modifies the backup client on the specified server.
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="backupClient">
		/// The backup client to modify
		/// </param>
		/// <param name="storagePolicy">
		/// The storage policy to modify
		/// </param>
		/// <param name="schedulePolicy">
		/// The schedule policy to modify
		/// </param>
		/// <param name="alertingType">
		/// The alerting type to modify
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<Status> ModifyBackupClient(
			this IComputeApiClient client, 
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
					client.WebApi.ApiPostAsync<ModifyBackupClient, Status>(
						ApiUris.ModifyBackupClient(client.Account.OrganizationId, serverId, backupClient.id), 
						new ModifyBackupClient
						{
							schedulePolicyName = schedulePolicy.name, 
							storagePolicyName = storagePolicy.name, 
							alerting = alertingType
						});
		}

		/// <summary>
		/// Requests an immediate Backup for a Backup Client
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="backupClient">
		/// The backup client to modify
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<Status> InitiateBackup(
			this IComputeApiClient client, 
			string serverId, 
			BackupClientDetailsType backupClient)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server cannot be null or empty");
			Contract.Requires(backupClient != null, "Backup client cannot be null");

			return
				await
					client.WebApi.ApiGetAsync<Status>(
						ApiUris.InitiateBackup(client.Account.OrganizationId, serverId, backupClient.id));
		}

		/// <summary>
		/// Requests a cancellation for any running job for a backup client
		/// </summary>
		/// <param name="client">
		/// The <see cref="ComputeApiClient"/> object
		/// </param>
		/// <param name="serverId">
		/// The server id
		/// </param>
		/// <param name="backupClient">
		/// The backup client to modify
		/// </param>
		/// <returns>
		/// The status of the request
		/// </returns>
		public static async Task<Status> CancelBackupJob(
			this IComputeApiClient client, 
			string serverId, 
			BackupClientDetailsType backupClient)
		{
			Contract.Requires(!string.IsNullOrWhiteSpace(serverId), "Server cannot be null or empty");
			Contract.Requires(backupClient != null, "Backup client cannot be null");

			return
				await
					client.WebApi.ApiGetAsync<Status>(
						ApiUris.CancelBackupJobs(client.Account.OrganizationId, serverId, backupClient.id));
		}
	}
}