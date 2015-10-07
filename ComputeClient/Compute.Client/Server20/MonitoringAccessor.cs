namespace DD.CBU.Compute.Api.Client.Server20
{
    using System;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Interfaces.Server20;
    using DD.CBU.Compute.Api.Contracts.Network20;

    /// <summary>
    /// The server monitoring accessor.
    /// </summary>
    public class MonitoringAccessor : IMonitoringAccessor
    {
        /// <summary>
        /// The _api client.
        /// </summary>
        private readonly IWebApi _apiClient;

        /// <summary>
        /// Initialises a new instance of the <see cref="MonitoringAccessor"/> class.
        /// </summary>
        /// <param name="apiClient">
        /// The api client.
        /// </param>
        public MonitoringAccessor(IWebApi apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Enables server monitoring.
        /// </summary>
        /// <param name="enableServerMonitoring">The monitoring settings.</param>
        /// <returns>The status response</returns>
        public async Task<ResponseType> EnableServerMonitoring(EnableServerMonitoringType enableServerMonitoring)
        {
            return await _apiClient.PostAsync<EnableServerMonitoringType, ResponseType>(
                ApiUris.EnableServerMonitoring(_apiClient.OrganizationId),
                enableServerMonitoring);
        }

        /// <summary>
        /// Changes the service plan.
        /// </summary>
        /// <param name="changeServerMonitoringPlan">The monitoring settings.</param>
        /// <returns>The status response</returns>
        public async Task<ResponseType> ChangeServerMonitoringPlan(ChangeServerMonitoringPlanType changeServerMonitoringPlan)
        {
            return await _apiClient.PostAsync<ChangeServerMonitoringPlanType, ResponseType>(
                ApiUris.ChangeServerMonitoringPlan(_apiClient.OrganizationId),
                changeServerMonitoringPlan);
        }

        /// <summary>
        /// Disables server monitoring.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <returns>The status response</returns>
        public async Task<ResponseType> DisableServerMonitoring(Guid serverId)
        {
            return await _apiClient.PostAsync<DisableServerMonitoringType, ResponseType>(
                ApiUris.DisableServerMonitoring(_apiClient.OrganizationId),
                new DisableServerMonitoringType { id = serverId.ToString() });
        }

        /// <summary>
        /// Gets the monitoring usage report.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The usage report as CSV.</returns>
        public async Task<string> GetMonitoringUsageReport(DateTime startDate, DateTime? endDate = null)
        {
            return await _apiClient.GetAsync<string>(
                ApiUris.GetMonitoringUsageReport(_apiClient.OrganizationId, startDate, endDate));
        }
    }
}
