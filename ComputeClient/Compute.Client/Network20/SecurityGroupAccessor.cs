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

    /// <summary>	Access methods for VLAN Operations </summary>
    /// <seealso cref="T:DD.CBU.Compute.Api.Client.Interfaces.IVlan"/>
    public class SecurityGroupAccessor : IVlanSecurityGroupAccessor
    {
		/// <summary>
		/// The Api.
		/// </summary>
		private readonly IWebApi _api;

		/// <summary>
		/// Initialises a new instance of the <see cref="VlanAccessor"/> class.
		/// </summary>
		/// <param name="api">
		/// The api.
		/// </param>
		public SecurityGroupAccessor(IWebApi api)
		{
			_api = api;
		}

        /// <summary>
        /// Creates the Security group
        /// </summary>
        /// <param name="securityGroup">Security group</param>
        /// <returns>Response Data</returns>
        public async Task<ResponseType> CreateSecurityGroup(createSecurityGroup securityGroup)
        {
            return await _api.PostAsync<createSecurityGroup, ResponseType>(ApiUris.CreateSecurityGroup(_api.OrganizationId), securityGroup);
        }

        /// <summary>
        /// Edit the security group
        /// </summary>
        /// <param name="securityGroup">Security group</param>
        /// <returns>Response Data</returns>
        public async Task<ResponseType> EditSecurityGroup(editSecurityGroup securityGroup)
        {
            return await _api.PostAsync<editSecurityGroup, ResponseType>(ApiUris.EditSecurityGroup(_api.OrganizationId), securityGroup);
        }

        /// <summary>
        /// Delete the security group
        /// </summary>
        /// <param name="securityGroup">Security group</param>
        /// <returns>Response Data</returns>
        public async Task<ResponseType> DeleteSecurityGroup(DeleteSecurityGroup securityGroup)
        {
            return await _api.PostAsync<DeleteSecurityGroup, ResponseType>(ApiUris.DeleteSecurityGroup(_api.OrganizationId), securityGroup);
        }

        /// <summary>
        /// List Security groups associated with server nics or the vlan
        /// </summary>
        /// <param name="vlanId">Vlan Id</param>
        /// <param name="serverId">Server Id</param>
        /// <param name="pagingOptions">Paging options</param>
        /// <param name="filterOptions">Filter options</param>
        /// <returns>List of Security groups</returns>
        public async Task<PagedResponse<SecurityGroupType>> GetSecurityGroupsPaged(Guid? vlanId, Guid? serverId, PageableRequest pagingOptions = null,
            SecurityGroupListOptions filterOptions = null)
        {
            if(vlanId == null && serverId == null)
                throw new ArgumentException("Both vlanId and serverId cannot be null, atleast provide one");

            var response = await _api.GetAsync<securityGroups>(serverId.HasValue ? ApiUris.GetSecurityGroupForServer(_api.OrganizationId, serverId.Value) :  ApiUris.GetSecurityGroupForVlan(_api.OrganizationId, vlanId.Value), pagingOptions, filterOptions);
            return new PagedResponse<SecurityGroupType>
            {
                items = response.securityGroup,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Add nic to the security group
        /// </summary>
        /// <param name="nicSecurityGroup">Security group and nic details</param>
        /// <returns>Response Data</returns>
        public async Task<ResponseType> AddNicToSecurityGroup(addNicToSecurityGroup nicSecurityGroup)
        {
            return await _api.PostAsync<addNicToSecurityGroup, ResponseType>(ApiUris.AddNicToSecurityGroup(_api.OrganizationId), nicSecurityGroup);
        }

        /// <summary>
        /// Remove nic from the security group
        /// </summary>
        /// <param name="nicSecurityGroup">Security group and nic details</param>
        /// <returns>Response Data</returns>
        public async Task<ResponseType> RemoveNicFromSecurityGroup(removeNicFromSecurityGroup nicSecurityGroup)
        {
            return await _api.PostAsync<removeNicFromSecurityGroup, ResponseType>(ApiUris.RemoveNicFromSecurityGroup(_api.OrganizationId), nicSecurityGroup);
        }
    }
}
