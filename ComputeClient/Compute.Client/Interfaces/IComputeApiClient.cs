namespace DD.CBU.Compute.Api.Client.Interfaces
{
	using System;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Client.Interfaces.Account;
	using DD.CBU.Compute.Api.Client.Interfaces.Backup;
	using DD.CBU.Compute.Api.Client.Interfaces.ImportExportImages;
	using DD.CBU.Compute.Api.Client.Interfaces.Network;
	using DD.CBU.Compute.Api.Client.Interfaces.Network20;
	using DD.CBU.Compute.Api.Client.Interfaces.Server;
	using DD.CBU.Compute.Api.Client.Interfaces.Server20;
	using DD.CBU.Compute.Api.Contracts.Directory;
    using DD.CBU.Compute.Api.Client.Interfaces.Infrastructure;
    using DD.CBU.Compute.Api.Client.Interfaces.Reports;

    /// <summary>
    /// The interface of the CaaS API Client
    /// </summary>
    public interface IComputeApiClient : IDisposable, IDeprecatedComputeApiClient
    {   
        /// <summary>
        /// The web API that requests directly from the REST API.
        /// </summary>
        IWebApi WebApi { get; }      

	    /// <summary>
	    /// The login async.
	    /// </summary>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    Task<IAccount> Login();

		/// <summary>
		/// Gets the account accessor
		/// </summary>
		IAccountAccessor Account { get; }

        /// <summary>
		/// Gets the Infrastructure accessor.
		/// </summary>
		IInfrastructureAccessor Infrastructure { get; }

        /// <summary>	Gets the networking 2.0 methods. </summary>
        INetworkingAccessor Networking { get; }

		/// <summary>	Gets the networking legacy 1.0 methods </summary>
		INetworkingLegacyAccessor NetworkingLegacy { get; }

		/// <summary>
		/// Gets the server legacy.
		/// </summary>
		IServerManagementLegacyAccessor ServerManagementLegacy { get; }

		/// <summary>
		/// Gets the server management.
		/// </summary>
		IServerManagementAccessor ServerManagement { get; }

		/// <summary>
		/// Gets the import and export customer images accessor
		/// </summary>
		IImportExportCustomerImageAccessor ImportExportCustomerImage { get; }

		/// <summary>
		/// Gets the backup.
		/// </summary>
		IBackupAccessor Backup { get; }

        /// <summary>
        /// Gets the Reports
        /// </summary>
        IReportAccessor Reports { get; }
    }
}