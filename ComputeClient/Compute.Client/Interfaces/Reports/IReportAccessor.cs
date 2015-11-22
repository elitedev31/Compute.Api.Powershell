using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Server;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Api.Client.Interfaces.Reports
{
    /// <summary>
    /// The Reports Interface
    /// </summary>
    public interface IReportAccessor
    {

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report of the sum total usage across the account.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        Task<object> GetSummaryUsage(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report by the specifics of all usage across the account.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        Task<object> GetDetailedUsageReport(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report by identifying the software unit calculation specifics for any Priced Software on virtual servers across the account.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        Task<object> GetSoftwareUnitsUsageReport(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report by identifying the specifics of all Backup usage across the account.
        /// </summary>
        /// <param name="datacenterId">The datacenter Id</param>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        Task<object> GetBackupUsageReport(string datacenterId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Retrieves a CSV-formatted daily usage report of the administrator actions taken across the account.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        Task<object> GetAdministratorLogsReport(DateTime startDate, DateTime endDate);
    }
}
