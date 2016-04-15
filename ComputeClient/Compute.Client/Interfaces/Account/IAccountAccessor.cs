namespace DD.CBU.Compute.Api.Client.Interfaces.Account
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.Datacenter;
	using DD.CBU.Compute.Api.Contracts.Directory;
	using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Organization;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Software;

	/// <summary>
	/// The AccountAccessor interface.
	/// </summary>
	public interface IAccountAccessor
	{
		/// <summary>
		/// The get accounts.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<Account>> GetAccounts();

        /// <summary>
		/// The get accounts with phone number.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<AccountWithPhoneNumber>> GetAccountsWithPhoneNumber();

        /// <summary>
        /// The get administrator account.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<AccountWithPhoneNumber> GetAdministratorAccount(string username);

		/// <summary>
		/// The add sub administrator account.
		/// </summary>
		/// <param name="account">
		/// The account.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> AddSubAdministratorAccount(AccountWithPhoneNumber account);

		/// <summary>
		/// The delete sub administrator account.
		/// </summary>
		/// <param name="username">
		/// The username.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<Status> DeleteSubAdministratorAccount(string username);

	    /// <summary>
	    /// The update administrator password.
	    /// </summary>
	    /// <param name="userName">The User Name</param>
	    /// <param name="password">The Password</param>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    Task<Status> ChangePassword(string userName, string password);

	    /// <summary>
	    /// The update administrator phone number.
	    /// </summary>
	    /// <param name="userName">The User Name</param>
	    /// <param name="phoneCountryCode">The Phone Country Code</param>
	    /// <param name="phoneNumber">The Phone Number</param>
	    /// <returns>
	    /// The <see cref="Task"/>.
	    /// </returns>
	    Task<Status> UpdateAdministratorPhoneNumber(string userName, string phoneCountryCode, string phoneNumber);

        /// <summary>
        /// The update administrator account.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Status> UpdateAdministratorAccount(AccountWithPhoneNumber account);

		/// <summary>
		/// The get list of multi geography regions.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<Geo>> GetListOfMultiGeographyRegions();
	
		/// <summary>
		/// The get list of software labels.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<SoftwareLabel>> GetListOfSoftwareLabels();

        /// <summary>
        /// The get data centers with maintenance statuses.
        /// </summary>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<DatacenterWithMaintenanceStatusType>> GetDataCentersWithMaintenanceStatuses(IPageableRequest pagingOptions = null);

        /// <summary>
        /// The get data center with maintenance status.
        /// </summary>
        /// <param name="locationId">
        /// The identifier of the datacenter.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<DatacenterWithMaintenanceStatusType> GetDataCenterWithMaintenanceStatus(string locationId);

        /// <summary>
        /// The designate primary administrator account.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Status> DesignatePrimaryAdministratorAccount(string username);

        /// <summary>
        /// The get two factor authentication status.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TwoFactorAuthentication> GetTwoFactorAuthenticationStatus();
        
        /// <summary>
        /// The set two factor authentication status.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Status> SetTwoFactorAuthenticationStatus(TwoFactorAuthentication status);
    }
}
