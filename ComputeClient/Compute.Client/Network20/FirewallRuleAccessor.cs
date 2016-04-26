namespace DD.CBU.Compute.Api.Client.Network20
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using DD.CBU.Compute.Api.Client.Interfaces;
	using DD.CBU.Compute.Api.Client.Interfaces.Network20;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Network20;
	using DD.CBU.Compute.Api.Contracts.Requests;
	using DD.CBU.Compute.Api.Contracts.Requests.Network20;

	/// <summary>Access methods for firewall rule Operations</summary>
	public class FirewallRuleAccessor : IFirewallRuleAccessor
    {
		/// <summary>
		/// The Api.
		/// </summary>
		private readonly IWebApi _api;

        /// <summary>
        /// Initialises a new instance of the <see cref="FirewallRuleAccessor"/> class.
        /// </summary>
        /// <param name="api">
        /// The api.
        /// </param>
        public FirewallRuleAccessor(IWebApi api)
		{
			_api = api;
		}

        /// <summary>
        /// Lists all firewall rules.
        /// </summary>
        /// <param name="options">The filter options.</param>
        /// <returns>The collection of matching firewall rules.</returns>
        public async Task<IEnumerable<FirewallRuleType>> GetFirewallRules(FirewallRuleListOptions options = null)
        {
            var response = await GetFirewallRulesPaginated(options, null);
            return response.items;
        }

        /// <summary>
        /// Lists all firewall rules.
        /// </summary>
        /// <param name="options">The filter options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The async task of <see cref="PagedResponse{FirewallRuleType}"/></returns>
        public async Task<PagedResponse<FirewallRuleType>> GetFirewallRulesPaginated(FirewallRuleListOptions options = null, PageableRequest pagingOptions = null)
        {
            var response = await _api.GetAsync<firewallRules>(ApiUris.GetFirewallRules(_api.OrganizationId), pagingOptions, options);
            return new PagedResponse<FirewallRuleType>
            {
                items = response.firewallRule,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Gets a specific firewall rule.
        /// </summary>
        /// <param name="firewallRuleId">The firewall rule identifier.</param>
        /// <returns>The response details.</returns>
        public async Task<FirewallRuleType> GetFirewallRule(Guid firewallRuleId)
        {
            return await _api.GetAsync<FirewallRuleType>(
                ApiUris.GetFirewallRule(_api.OrganizationId, firewallRuleId));
        }

        /// <summary>
        /// Creates a firewall rule.
        /// </summary>
        /// <param name="createFirewallRule">The firewall rule details.</param>
        /// <returns>The response details.</returns>
        public async Task<ResponseType> CreateFirewallRule(CreateFirewallRuleType createFirewallRule)
        {
            return await _api.PostAsync<CreateFirewallRuleType, ResponseType>(
                ApiUris.CreateFirewallRule(_api.OrganizationId),
                createFirewallRule);
        }

        /// <summary>
        /// Edits a firewall rule.
        /// </summary>
        /// <param name="editFirewallRule">The firewall rule details.</param>
        /// <returns>The response details.</returns>
        public async Task<ResponseType> EditFirewallRule(EditFirewallRuleType editFirewallRule)
        {
            return await _api.PostAsync<EditFirewallRuleType, ResponseType>(
                ApiUris.EditFirewallRule(_api.OrganizationId),
                editFirewallRule);
        }

        /// <summary>
        /// Deletes a firewall rule.
        /// </summary>
        /// <param name="firewallRuleId">The firewall rule identifier.</param>
        /// <returns>The response details.</returns>
        public async Task<ResponseType> DeleteFirewallRule(Guid firewallRuleId)
        {
			return  await _api.PostAsync<DeleteFirewallRuleType, ResponseType>(
			    ApiUris.DeleteFirewallRule(_api.OrganizationId),
				new DeleteFirewallRuleType { id = firewallRuleId.ToString() });
		}

	    /// <summary>
	    /// Creates an ip address list.
	    /// </summary>
	    /// <param name="createIpAddressList">The ip address list details.</param>
	    /// <returns>The response details.</returns>
	    public async Task<ResponseType> CreateIpAddressList(createIpAddressList createIpAddressList)
	    {
            return await _api.PostAsync<createIpAddressList, ResponseType>(
                ApiUris.CreateIpAddressList(_api.OrganizationId),
                createIpAddressList);
        }


        /// <summary>
        /// Lists all ip address list.
        /// </summary>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <param name="options">The filter options.</param>
        /// <returns>The collection of matching ip address list.</returns>
        public async Task<IEnumerable<IpAddressListType>> GetIpAddressLists(Guid networkDomainId, IpAddressListOptions options = null)
        {
            var response = await GetIpAddressListsPaginated(networkDomainId, options, null);
            return response.items;
        }

	    /// <summary>
	    /// Lists all ip address list.
	    /// </summary>
	    /// <param name="networkDomainId">The Network domain id.</param>
	    /// <param name="options">The filter options.</param>
	    /// <param name="pagingOptions">The paging options.</param>
	    /// <returns>The async task of <see cref="PagedResponse{IpAddressListType}"/></returns>
	    public async Task<PagedResponse<IpAddressListType>> GetIpAddressListsPaginated(Guid networkDomainId, IpAddressListOptions options = null, PageableRequest pagingOptions = null)
        {
            var response = await _api.GetAsync<ipAddressLists>(ApiUris.ListIpAddressList(_api.OrganizationId, networkDomainId), pagingOptions, options);
            return new PagedResponse<IpAddressListType>
            {
                items = response.ipAddressList,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Gets the ip address list.
        /// </summary>
        /// <param name="ipAddressListId">The ip address list id.</param>
        /// <returns>The collection of matching ip address list.</returns>
        public async Task<IpAddressListType> GetIpAddressList(Guid ipAddressListId)
        {
            return await _api.GetAsync<IpAddressListType>(ApiUris.GetIpAddressList(_api.OrganizationId, ipAddressListId));
        }

        /// <summary>
	    /// Edits an ip address list.
	    /// </summary>
	    /// <param name="editIpAddressList">The ip address list details.</param>
	    /// <returns>The response details.</returns>
	    public async Task<ResponseType> EditIpAddressList(editIpAddressList editIpAddressList)
        {
            return await _api.PostAsync<editIpAddressList, ResponseType>(
                ApiUris.EditIpAddressList(_api.OrganizationId),
                editIpAddressList);
        }

	    /// <summary>
	    /// Deletes an ip address list.
	    /// </summary>
	    /// <param name="deleteIpAddressList">The ip address list id to be deleted.</param>
	    /// <returns>The response details.</returns>
	    public async Task<ResponseType> DeleteIpAddressList(deleteIpAddressList deleteIpAddressList)
        {
            return await _api.PostAsync<deleteIpAddressList, ResponseType>(
                ApiUris.DeleteIpAddressList(_api.OrganizationId),
                deleteIpAddressList);
        }

        /// <summary>
	    /// Creates an ip address list.
	    /// </summary>
	    /// <param name="createPortList">The ip address list details.</param>
	    /// <returns>The response details.</returns>
	    public async Task<ResponseType> CreatePortList(createPortList createPortList)
        {
            return await _api.PostAsync<createPortList, ResponseType>(
                ApiUris.CreatePortList(_api.OrganizationId),
                createPortList);
        }


        /// <summary>
        /// Lists all ip address list.
        /// </summary>
        /// <param name="networkDomainId">The network domain id.</param>
        /// <param name="options">The filter options.</param>
        /// <returns>The collection of matching ip address list.</returns>
        public async Task<IEnumerable<PortListType>> GetPortLists(Guid networkDomainId, PortListOptions options = null)
        {
            var response = await GetPortListsPaginated(networkDomainId, options, null);
            return response.items;
        }

        /// <summary>
        /// Lists all ip address list.
        /// </summary>
        /// <param name="networkDomainId">The Network domain id.</param>
        /// <param name="options">The filter options.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>The async task of <see cref="PagedResponse{PortListType}"/></returns>
        public async Task<PagedResponse<PortListType>> GetPortListsPaginated(Guid networkDomainId, PortListOptions options = null, PageableRequest pagingOptions = null)
        {
            var response = await _api.GetAsync<portLists>(ApiUris.ListPortList(_api.OrganizationId, networkDomainId), pagingOptions, options);
            return new PagedResponse<PortListType>
            {
                items = response.portList,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Gets the ip address list.
        /// </summary>
        /// <param name="PortListId">The ip address list id.</param>
        /// <returns>The collection of matching ip address list.</returns>
        public async Task<PortListType> GetPortList(Guid PortListId)
        {
            return await _api.GetAsync<PortListType>(ApiUris.GetPortList(_api.OrganizationId, PortListId));
        }

        /// <summary>
	    /// Edits an ip address list.
	    /// </summary>
	    /// <param name="editPortList">The ip address list details.</param>
	    /// <returns>The response details.</returns>
	    public async Task<ResponseType> EditPortList(editPortList editPortList)
        {
            return await _api.PostAsync<editPortList, ResponseType>(
                ApiUris.EditPortList(_api.OrganizationId),
                editPortList);
        }

        /// <summary>
        /// Deletes an ip address list.
        /// </summary>
        /// <param name="deletePortList">The ip address list id to be deleted.</param>
        /// <returns>The response details.</returns>
        public async Task<ResponseType> DeletePortList(DeletePortListType deletePortList)
        {
            return await _api.PostAsync<DeletePortListType, ResponseType>(
                ApiUris.DeletePortList(_api.OrganizationId),
                deletePortList);
        }
    }
}
