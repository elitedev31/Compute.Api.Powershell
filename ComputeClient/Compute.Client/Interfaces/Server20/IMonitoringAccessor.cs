namespace DD.CBU.Compute.Api.Client.Interfaces.Server20
{
    using System;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.Network20;

    /// <summary>
    /// The Monitoring Accessor interface.
    /// </summary>
    public interface IMonitoringAccessor
    {
        /// <summary>
        /// Enables server monitoring.
        /// </summary>
        /// <param name="enableServerMonitoring">The monitoring settings.</param>
        /// <returns>The status response</returns>
        Task<ResponseType> EnableServerMonitoring(EnableServerMonitoringType enableServerMonitoring);

        /// <summary>
        /// Changes the service plan.
        /// </summary>
        /// <param name="changeServerMonitoringPlan">The monitoring settings.</param>
        /// <returns>The status response</returns>
        Task<ResponseType> ChangeServerMonitoringPlan(ChangeServerMonitoringPlanType changeServerMonitoringPlan);

        /// <summary>
        /// Disables server monitoring.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        /// <returns>The status response</returns>
        Task<ResponseType> DisableServerMonitoring(Guid serverId);

        /// <summary>
        /// Gets the monitoring usage report.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The usage report as CSV.</returns>
        Task<string> GetMonitoringUsageReport(DateTime startDate, DateTime? endDate = null);
    }
}
