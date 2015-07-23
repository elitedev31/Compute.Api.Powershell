namespace DD.CBU.Compute.Api.Client.Interfaces.Account
{
	using System.Collections.Generic;
	using System.Net;
	using System.Threading.Tasks;

	using DD.CBU.Compute.Api.Contracts.Datacenter;
	using DD.CBU.Compute.Api.Contracts.Directory;
	using DD.CBU.Compute.Api.Contracts.General;
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
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		Task<IEnumerable<DatacenterWithMaintenanceStatusType>> GetDataCentersWithMaintenanceStatuses();

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
	}
}
