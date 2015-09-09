using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.Interfaces.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Vip;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Api.Client.Network20
{
    /// <summary>
    /// The NetworkDomainVip type.
    /// </summary>
    public class NetworkDomainVipAccessor : INetworkDomainVipAccessor
    {
        /// <summary>
        /// The Web Api.
        /// </summary>
        private readonly IWebApi _api;

        /// <summary>
        /// Initializes a new instance of <see cref="NetworkDomainVipAccessor"/>
        /// </summary>
        /// <param name="api">The Web Api</param>
        public NetworkDomainVipAccessor(IWebApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Creates a Pool on a Network Domain in an MCP 2.0 data center location.
        /// </summary>
        /// <param name="pool">The create pool.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> CreatePool(createPool pool)
        {
            return await _api.PostAsync<createPool, ResponseType>(ApiUris.CreatePool(_api.OrganizationId), pool);
        }

        /// <summary>
        /// Retrieves all of the Pools on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="PoolType"/></returns>
        public async Task<IEnumerable<PoolType>> GetPools(PoolListOptions options = null)
        {
            var pools = await _api.GetAsync<pools>(ApiUris.GetPools(_api.OrganizationId));
            return pools.pool;
        }

        /// <summary>
        /// Retrieves all of the Pools on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions"> The paging Options.</param>
        /// <returns>The async task of <see cref="pools"/></returns>
        public async Task<pools> GetPoolsPaginated(PoolListOptions options = null, PageableRequest pagingOptions = null)
        {
            return await _api.GetAsync<pools>(ApiUris.GetPools(_api.OrganizationId));
        }

        /// <summary>
        /// Returns details of a single Pool.
        /// </summary>
        /// <param name="poolId">The Pool id.</param>
        /// <returns>The async task of <see cref="PoolType"/></returns>
        public async Task<PoolType> GetPool(Guid poolId)
        {
            return await _api.GetAsync<PoolType>(ApiUris.GetPool(_api.OrganizationId, poolId));
        }

        /// <summary>
        /// Updates the mutable properties of a Pool.
        /// </summary>
        /// <param name="pool">The edit pool.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> EditPool(editPool pool)
        {
            return await _api.PostAsync<editPool, ResponseType>(ApiUris.EditPool(_api.OrganizationId), pool);
        }

        /// <summary>
        /// Deletes a Pool.
        /// </summary>
        /// <param name="poolId">The Pool id.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> DeletePool(Guid poolId)
        {
            return
                await
                    _api.PostAsync<DeletePoolType, ResponseType>(ApiUris.DeletePool(_api.OrganizationId),
                        new DeletePoolType { id = poolId.ToString() });
        }

        /// <summary>
        /// Adds a Node, combined with Port information to the identified Pool as a new Pool Member.
        /// </summary>
        /// <param name="poolMember">The Pool Member</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> AddPoolMember(addPoolMember poolMember)
        {
            return
                await
                    _api.PostAsync<addPoolMember, ResponseType>(ApiUris.AddPoolMember(_api.OrganizationId), poolMember);
        }

        /// <summary>
        /// Retrieves the Pool Members on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of a collection of <see cref="PoolMemberType"/></returns>
        public async Task<IEnumerable<PoolMemberType>> GetPoolMembers(PoolMemberListOptions options = null)
        {
            var poolMembers = await _api.GetAsync<poolMembers>(ApiUris.GetPoolMembers(_api.OrganizationId));
            return poolMembers.poolMember;
        }

        /// <summary>
        /// Retrieves the Pool Members on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options.</param>
        /// <param name="pagingOptions">The Paging options.</param>
        /// <returns>The async task of <see cref="poolMembers"/></returns>
        public async Task<poolMembers> GetPoolMembersPaginated(PoolMemberListOptions options = null, PageableRequest pagingOptions = null)
        {
            return await _api.GetAsync<poolMembers>(ApiUris.GetPoolMembers(_api.OrganizationId));
        }

        /// <summary>
        /// Returns details of a single Pool Member.
        /// </summary>
        /// <param name="poolMemberId">The Pool Member id.</param>
        /// <returns>The async task of <see cref="PoolMemberType"/></returns>
        public async Task<PoolMemberType> GetPoolMember(Guid poolMemberId)
        {
            return await _api.GetAsync<PoolMemberType>(ApiUris.GetPoolMember(_api.OrganizationId, poolMemberId));
        }

        /// <summary>
        /// Updates the status of a Pool Member.
        /// </summary>
        /// <param name="poolMember">The edit pool member.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> EditPoolMember(editPoolMember poolMember)
        {
            return await _api.PostAsync<editPoolMember, ResponseType>(ApiUris.EditPool(_api.OrganizationId), poolMember);
        }

        /// <summary>
        /// Deletes a Pool Member.
        /// </summary>
        /// <param name="poolMemberId">The Pool Member id.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> DeletePoolMember(Guid poolMemberId)
        {
            return
                await
                    _api.PostAsync<DeletePoolMemberType, ResponseType>(ApiUris.DeletePool(_api.OrganizationId),
                        new DeletePoolMemberType { id = poolMemberId.ToString() });
        }
    }
}