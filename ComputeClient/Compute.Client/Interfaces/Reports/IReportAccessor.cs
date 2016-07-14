namespace DD.CBU.Compute.Api.Client.Interfaces.Reports
{
    using System;
    using System.Threading.Tasks;

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
        Task<string> GetSummaryUsage(DateTime startDate, DateTime endDate);

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

        /// <summary>
        /// Returns a report detailing the DRS server pairs that were in existance for the supplied organizationId during the specified date range.
        /// </summary>
        /// <param name="startDate">The Start Date</param>
        /// <param name="endDate">The End Date</param>
        /// <returns>The CSV formatted result</returns>
        Task<object> GetDrsPairsUsageReport(DateTime startDate, DateTime endDate);
    }
}