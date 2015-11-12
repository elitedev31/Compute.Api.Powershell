using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.Interfaces.Reports;

namespace DD.CBU.Compute.Api.Client.Reports
{
    /// <summary>
    /// The Report type.
    /// </summary>
    public class ReportAccessor: IReportAccessor
    {
        /// <summary>
        /// The _api client.
        /// </summary>
        private readonly IWebApi _apiClient;

        /// <summary>
        /// Initialises a new instance of the <see cref="ReportAccessor"/> class.
        /// </summary>
        /// <param name="apiClient">
        /// The api client.
        /// </param>
        public ReportAccessor(IWebApi apiClient)
        {
            this._apiClient = apiClient;
        }

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report of the sum total usage across the account.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        public async Task<object> GetSummaryUsage(DateTime startDate, DateTime endDate)
        {
            var data = 
                await
                    _apiClient.GetAsync<object>(ApiUris.SummaryUsageReport(_apiClient.OrganizationId, startDate, endDate));
            return data;
        }

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report by the specifics of all usage across the account.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        public async Task<object> GetDetailedUsageReport(DateTime startDate, DateTime endDate)
        {
            var data =
                await
                    _apiClient.GetAsync<object>(ApiUris.DetailedUsageReport(_apiClient.OrganizationId, startDate, endDate));
            return data;
        }

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report by identifying the software unit calculation specifics for any Priced Software on virtual servers across the account.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        public async Task<object> GetSoftwareUnitsUsageReport(DateTime startDate, DateTime endDate)
        {
            var data =
                await
                    _apiClient.GetAsync<object>(ApiUris.SoftwareUnitsReport(_apiClient.OrganizationId, startDate, endDate));
            return data;
        }

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report by identifying the specifics of all Backup usage across the account.
        /// </summary>
        /// <param name="datacenterId">The datacenter Id</param>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        public async Task<object> GetBackupUsageReport(Guid datacenterId, DateTime startDate, DateTime endDate)
        {
            var data =
                await
                    _apiClient.GetAsync<object>(ApiUris.BackupUsageReport(_apiClient.OrganizationId, datacenterId.ToString(), startDate, endDate));
            return data;
        }

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report of the administrator actions taken across the account.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        public async Task<object> GetAdministratorLogsReport(DateTime startDate, DateTime endDate)
        {
            var data =
                await
                    _apiClient.GetAsync<object>(ApiUris.AdminLogReport(_apiClient.OrganizationId, startDate, endDate));
            return data;
        }
    }
}