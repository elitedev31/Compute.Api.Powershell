using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Api.Client.Interfaces.Network20
{
    /// <summary>
    /// The NetworkDomainVip interface.
    /// </summary>
    public interface IVipPoolAccessor
    {
        /// <summary>
        /// Creates a Pool on a Network Domain in an MCP 2.0 data center location.
        /// </summary>
        /// <param name="pool">The create pool.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> CreatePool(createPool pool);

        /// <summary>
        /// Retrieves all of the Pools on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="PoolType"/></returns>
        Task<IEnumerable<PoolType>> GetPools(PoolListOptions options = null);

        /// <summary>
        /// Retrieves all of the Pools on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions"> The paging Options.</param>
        /// <returns>The async task of <see cref="PagedResponse{PoolType}"/></returns>
        Task<PagedResponse<PoolType>> GetPoolsPaginated(PoolListOptions options = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// Returns details of a single Pool.
        /// </summary>
        /// <param name="poolId">The Pool id.</param>
        /// <returns>The async task of <see cref="PoolType"/></returns>
        Task<PoolType> GetPool(Guid poolId);

        /// <summary>
        /// Updates the mutable properties of a Pool.
        /// </summary>
        /// <param name="pool">The edit pool.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> EditPool(EditPoolType pool);

        /// <summary>
        /// Deletes a Pool.
        /// </summary>
        /// <param name="poolId">The Pool id.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> DeletePool(Guid poolId);

        /// <summary>
        /// Adds a Node, combined with Port information to the identified Pool as a new Pool Member.
        /// </summary>
        /// <param name="poolMember">The Pool Member</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> AddPoolMember(addPoolMember poolMember);

        /// <summary>
        /// Retrieves the Pool Members on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of a collection of <see cref="PoolMemberType"/></returns>
        Task<IEnumerable<PoolMemberType>> GetPoolMembers(PoolMemberListOptions options = null);

        /// <summary>
        /// Retrieves the Pool Members on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options.</param>
        /// <param name="pagingOptions">The Paging options.</param>
        /// <returns>The async task of <see cref="PagedResponse{PoolMemberType}"/></returns>
        Task<PagedResponse<PoolMemberType>> GetPoolMembersPaginated(PoolMemberListOptions options = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// Returns details of a single Pool Member.
        /// </summary>
        /// <param name="poolMemberId">The Pool Member id.</param>
        /// <returns>The async task of <see cref="PoolMemberType"/></returns>
        Task<PoolMemberType> GetPoolMember(Guid poolMemberId);

        /// <summary>
        /// Updates the status of a Pool Member.
        /// </summary>
        /// <param name="poolMember">The edit pool member.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> EditPoolMember(editPoolMember poolMember);

        /// <summary>
        /// Removes a Pool Member.
        /// </summary>
        /// <param name="poolMemberId">The Pool Member id.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> RemovePoolMember(Guid poolMemberId);
    }
}
