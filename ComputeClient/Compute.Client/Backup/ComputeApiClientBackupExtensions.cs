namespace DD.CBU.Compute.Api.Client.Backup
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.Backup;

    /// <summary>
    /// Extension methods for the backup section of the CaaS API.
    /// </summary>
    public static class ComputeApiClientBackupExtensions
    {
        /// <summary>
        /// Enables the backup with a specific service plan.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object</param>
        /// <param name="serverId">The server id</param>
        /// <returns>The status of the request</returns>
        public static async Task<Status> EnableBackup(this ComputeApiClient client, string serverId, BackupServicePlans plan)
        {
            return
                await
                client.ApiPostAsync<NewBackup, Status>(
                    ApiUris.EnableBackup(client.Account.OrganizationId, serverId),
                    NewBackup.Create(plan));
        }

        /// <summary>
        /// Disable the backup service from the server.
        /// <remarks>Note the server MUST not have any clients</remarks>
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object</param>
        /// <param name="serverId">The server id</param>
        /// <returns>The status of the request</returns>
        public static async Task<Status> DisableBackup(this ComputeApiClient client, string serverId)
        {
            return await client.ApiGetAsync<Status>(ApiUris.DisableBackup(client.Account.OrganizationId, serverId));
        }

        /// <summary>
        /// Modify the backup service plan.
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object</param>
        /// <param name="serverId">The server id</param>
        /// <param name="plan">The plan to change to</param>
        /// <returns>The status of the request</returns>
        public static async Task<Status> ChangeBackupPlan(this ComputeApiClient client, string serverId, BackupServicePlans plan)
        {
            return await client.ApiPostAsync<ModifyBackup, Status>(ApiUris.ChangeBackupPlan(client.Account.OrganizationId, serverId), ModifyBackup.Create(plan));
        }

        /// <summary>
        /// List the client types for a specified server
        /// </summary>
        /// <param name="client">The <see cref="ComputeApiClient"/> object</param>
        /// <param name="serverId">The server id</param>
        /// <returns>The status of the request</returns>
        public static async Task<IEnumerable<BackupClientType>> GetBackupClientTypes(this ComputeApiClient client, string serverId)
        {
            var types = await client.ApiGetAsync<BackupClientTypes>(ApiUris.BackupClientTypes(client.Account.OrganizationId, serverId));
            return types.Items;
        }
    }
}
