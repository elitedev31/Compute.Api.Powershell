namespace DD.CBU.Compute.Api.Client.Account
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Interfaces.Account;
    using DD.CBU.Compute.Api.Contracts.Datacenter;
    using DD.CBU.Compute.Api.Contracts.Directory;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Organization;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Software;

    /// <summary>
    /// The account accessor.
    /// </summary>
    public class AccountAccessor : IAccountAccessor
	{
		/// <summary>
		/// The _api client.
		/// </summary>
		private readonly IWebApi _apiClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="AccountAccessor"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The api client.
		/// </param>
		public AccountAccessor(IWebApi apiClient)
		{
			this._apiClient = apiClient;
		}

		/// <summary>
		/// The get accounts.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<Account>> GetAccounts()
		{
			Accounts accounts = await _apiClient.GetAsync<Accounts>(ApiUris.Account(_apiClient.OrganizationId));
			return accounts.Items;
		}

        /// <summary>
        /// The get accounts with phone number.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<AccountWithPhoneNumber>> GetAccountsWithPhoneNumber()
        {
            AccountsWithPhoneNumber accounts = await _apiClient.GetAsync<AccountsWithPhoneNumber>(ApiUris.AccountWithPhoneNumber(_apiClient.OrganizationId));
            return accounts.Items;
        }

        /// <summary>
		/// The get administrator account.
		/// </summary>
		/// <param name="username">
		/// The username.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<AccountWithPhoneNumber> GetAdministratorAccount(string username)
		{
			AccountWithPhoneNumber account =
				await
				_apiClient.GetAsync<AccountWithPhoneNumber>(ApiUris.AccountWithPhoneNumber(_apiClient.OrganizationId, username));
			return account;
		}

		/// <summary>
		/// The add sub administrator account.
		/// </summary>
		/// <param name="account">
		/// The account.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> AddSubAdministratorAccount(AccountWithPhoneNumber account)
		{
			return
				await
				_apiClient.PostAsync<AccountWithPhoneNumber, Status>(
					ApiUris.AccountWithPhoneNumber(_apiClient.OrganizationId),
					account);
		}

		/// <summary>
		/// The delete sub administrator account.
		/// </summary>
		/// <param name="username">
		/// The username.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<Status> DeleteSubAdministratorAccount(string username)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.DeleteSubAdministrator(_apiClient.OrganizationId, username));
		}

        /// <summary>
        /// The update administrator phone number.
        /// </summary>
        /// <param name="userName">The User Name</param>
        /// <param name="phoneCountryCode">The Phone Country Code</param>
        /// <param name="phoneNumber">The Phone Number</param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> UpdateAdministratorPhoneNumber(string userName, string phoneCountryCode, string phoneNumber)
        {
            var parameters = new Dictionary<string, string>();
            parameters["phoneCountryCode"] = phoneCountryCode;
            parameters["phoneNumber"] = phoneNumber;

            string postBody = parameters.ToQueryStringWithEmpty();

            return
                await
                _apiClient.PostAsync<Status>(ApiUris.UpdateAdministrator(_apiClient.OrganizationId, userName), postBody);
        }

        /// <summary>
        /// The update administrator password.
        /// </summary>
        /// <param name="userName">The User Name</param>
        /// <param name="password">The Password</param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> ChangePassword(string userName, string password)
        {
            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(password))
                parameters["password"] = password;

            string postBody = parameters.ToQueryString();

            return
                await
                _apiClient.PostAsync<Status>(ApiUris.UpdateAdministrator(_apiClient.OrganizationId, userName), postBody);
        }

        /// <summary>
        /// The update administrator account.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> UpdateAdministratorAccount(AccountWithPhoneNumber account)
		{
			var parameters = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(account.password))
				parameters["password"] = account.password;
			if (!string.IsNullOrEmpty(account.emailAddress))
				parameters["emailAddress"] = account.emailAddress;
			if (!string.IsNullOrEmpty(account.fullName))
				parameters["fullName"] = account.fullName;
			if (!string.IsNullOrEmpty(account.firstName))
				parameters["firstName"] = account.firstName;
			if (!string.IsNullOrEmpty(account.lastName))
				parameters["lastName"] = account.lastName;
			if (!string.IsNullOrEmpty(account.department))
				parameters["department"] = account.department;
			if (!string.IsNullOrEmpty(account.customDefined1))
				parameters["customDefined1"] = account.customDefined1;
			if (!string.IsNullOrEmpty(account.customDefined2))
				parameters["customDefined2"] = account.customDefined2;
            parameters["phoneCountryCode"] = account.phoneCountryCode;
			parameters["phoneNumber"] = account.phoneNumber;

			string postBody = parameters.ToQueryStringWithEmpty();

			if (account.MemberOfRoles.Any())
			{
				IEnumerable<string> roles = account.MemberOfRoles.Select(role => string.Format("role={0}", role.Name));
				string roleParameters = string.Join("&", roles);

				postBody = string.Join("&", postBody, roleParameters);
			}

			return
				await
				_apiClient.PostAsync<Status>(ApiUris.UpdateAdministrator(_apiClient.OrganizationId, account.userName), postBody);
		}

		/// <summary>
		/// The get list of multi geography regions.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<Geo>> GetListOfMultiGeographyRegions()
		{
			Geos regions = await _apiClient.GetAsync<Geos>(ApiUris.MultiGeographyRegions(_apiClient.OrganizationId));
			return regions.Items;
		}

		/// <summary>
		/// The get list of software labels.
		/// </summary>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public async Task<IEnumerable<SoftwareLabel>> GetListOfSoftwareLabels()
		{
			SoftwareLabels labels = await _apiClient.GetAsync<SoftwareLabels>(ApiUris.SoftwareLabels(_apiClient.OrganizationId));
			return labels.Items;
		}

        /// <summary>
        /// The get data centers with maintenance statuses.
        /// </summary>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<DatacenterWithMaintenanceStatusType>> GetDataCentersWithMaintenanceStatuses(IPageableRequest pagingOptions = null)
		{
			DatacentersWithMaintenanceStatus dataCenters = await _apiClient.GetAsync<DatacentersWithMaintenanceStatus>(
                ApiUris.DatacentresWithMaintanence(_apiClient.OrganizationId), pagingOptions);
			return dataCenters.datacenter;
		}

        /// <summary>
        /// The get data center with maintenance status.
        /// </summary>
        /// <param name="locationId">
        /// The identifier of the datacenter.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<DatacenterWithMaintenanceStatusType> GetDataCenterWithMaintenanceStatus(string locationId)
        {
            DatacentersWithMaintenanceStatus dataCenters = await _apiClient.GetAsync<DatacentersWithMaintenanceStatus>(
                ApiUris.DatacentreWithMaintanence(_apiClient.OrganizationId, locationId));
            return dataCenters.datacenter.FirstOrDefault();
        }

        /// <summary>
        /// The designate primary administrator account.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> DesignatePrimaryAdministratorAccount(string username)
		{
			return await _apiClient.GetAsync<Status>(ApiUris.SetPrimaryAdministrator(_apiClient.OrganizationId, username));
		}

        /// <summary>
        /// The get two factor authentication status.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TwoFactorAuthentication> GetTwoFactorAuthenticationStatus()
        {
            return await _apiClient.GetAsync<TwoFactorAuthentication>(ApiUris.TwoFactorAuthenicationStatus(_apiClient.OrganizationId));
        }

        /// <summary>
        /// The set two factor authentication status.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Status> SetTwoFactorAuthenticationStatus(TwoFactorAuthentication status)
        {
            return await _apiClient.PostAsync<Status>(ApiUris.TwoFactorAuthenicationStatus(_apiClient.OrganizationId), status.Enabled ? "true" : "false");
        }
	}
}
