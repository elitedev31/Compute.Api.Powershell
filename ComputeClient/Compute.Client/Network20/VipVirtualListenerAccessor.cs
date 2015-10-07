using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.Interfaces.Network20;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Api.Client.Network20
{
    /// <summary>
    /// The VIP Virtual Listener Management type.
    /// </summary>
    public class VipVirtualListenerAccessor : IVipVirtualListenerAccessor
    {
        /// <summary>
        /// The Web Api.
        /// </summary>
        private readonly IWebApi _api;

        /// <summary>
        /// Initializes a new instance of <see cref="VipNodeAccessor"/>
        /// </summary>
        /// <param name="api">The Web Api</param>
        public VipVirtualListenerAccessor(IWebApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Retrieves all of the VirtualListeners on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="VirtualListenerType"/></returns>
        public async Task<IEnumerable<VirtualListenerType>> GetVirtualListeners(VirtualListenerListOptions options = null)
        {
            var response = await GetVirtualListenersPaginated(options, null);
            return response.items;
        }

        /// <summary>
        /// Retrieves all of the VirtualListeners on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions"> The paging Options.</param>
        /// <returns>The async task of <see cref="PagedResponse{VirtualListenerType}"/></returns>
        public async Task<PagedResponse<VirtualListenerType>> GetVirtualListenersPaginated(VirtualListenerListOptions options = null, PageableRequest pagingOptions = null)
        {
            var response = await _api.GetAsync<virtualListeners>(ApiUris.GetVirtualListeners(_api.OrganizationId), pagingOptions, options);
            return new PagedResponse<VirtualListenerType>
            {
                items = response.virtualListener,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Returns details of a single VirtualListener.
        /// </summary>
        /// <param name="virtualListenerId">The VirtualListener id.</param>
        /// <returns>The async task of <see cref="VirtualListenerType"/></returns>
        public async Task<VirtualListenerType> GetVirtualListener(Guid virtualListenerId)
        {
            return await _api.GetAsync<VirtualListenerType>(ApiUris.GetVirtualListener(_api.OrganizationId, virtualListenerId));
        }

        /// <summary>
        /// Creates a VirtualListener on a Network Domain in an MCP 2.0 data center location.
        /// </summary>
        /// <param name="virtualListener">The create virtual listener.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> CreateVirtualListener(createVirtualListener virtualListener)
        {
            return await _api.PostAsync<createVirtualListener, ResponseType>(ApiUris.CreateVirtualListener(_api.OrganizationId), virtualListener);
        }

        /// <summary>
        /// Updates the mutable properties of a VirtualListener.
        /// </summary>
        /// <param name="virtualListener">The edit virtualListener.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> EditVirtualListener(editVirtualListener virtualListener)
        {
            return await _api.PostAsync<editVirtualListener, ResponseType>(ApiUris.EditVirtualListener(_api.OrganizationId), virtualListener);
        }

        /// <summary>
        /// Deletes a VirtualListener.
        /// </summary>
        /// <param name="virtualListenerId">The VirtualListener id.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        public async Task<ResponseType> DeleteVirtualListener(Guid virtualListenerId)
        {
            return
                await
                    _api.PostAsync<DeleteVirtualListener, ResponseType>(ApiUris.DeleteVirtualListener(_api.OrganizationId),
                        new DeleteVirtualListener { id = virtualListenerId.ToString() });
        }
    }
}