namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Network20;

    /// <summary>
    /// The VlanAccessor interface.
    /// </summary>
    public interface IVlanSecurityGroupAccessor
    {        		
		/// <summary>
		/// Create Security Group
		/// </summary>
		/// <param name="securityGroup">Details regarding the security group</param>
		/// <returns>Response Data</returns>
		Task<ResponseType> CreateSecurityGroup(createSecurityGroup securityGroup);

        /// <summary>
		/// Edit Security Group
		/// </summary>
		/// <param name="securityGroup">Details regarding the security group</param>
		/// <returns>Response Data</returns>
		Task<ResponseType> EditSecurityGroup(editSecurityGroup securityGroup);


        /// <summary>
        /// Delete Security Group
        /// </summary>
        /// <param name="securityGroup">Details regarding the security group</param>
        /// <returns>Response Data</returns>
        Task<ResponseType> DeleteSecurityGroup(DeleteSecurityGroup securityGroup);

        /// <summary>
        /// Get the list of security groups associated with either the server or the vlan
        /// </summary>
        /// <param name="vlanId">Security group associated with the vlan</param>
        /// <param name="serverId">Groups associated with the Nics on the server, only provide wither vlan or serverid</param>
        /// <param name="pagingOptions">Paging options</param>
        /// <param name="filterOptions">Filter Options</param>
        /// <returns></returns>
        Task<PagedResponse<SecurityGroupType>> GetSecurityGroupsPaged(Guid? vlanId, Guid? serverId, PageableRequest pagingOptions = null, SecurityGroupListOptions filterOptions = null);

        /// <summary>
		/// Add Nic to Security Group
		/// </summary>
		/// <param name="nicSecurityGroup">Details regarding the security group and the nic</param>
		/// <returns>Response Data</returns>
		Task<ResponseType> AddNicToSecurityGroup(addNicToSecurityGroup nicSecurityGroup);

        /// <summary>
        /// Remove Nic from Security Group
        /// </summary>
        /// <param name="nicSecurityGroup">Details regarding the security group and the nic</param>
        /// <returns>Response Data</returns>
        Task<ResponseType> RemoveNicFromSecurityGroup(removeNicFromSecurityGroup nicSecurityGroup);
    }
}
