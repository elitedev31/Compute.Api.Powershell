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
    /// The VIP Node Management interface.
    /// </summary>
    public interface IVipNodeAccessor
    {
        /// <summary>
        /// Creates a Node on a Network Domain in an MCP 2.0 data center location.
        /// </summary>
        /// <param name="node">The create node.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> CreateNode(CreateNodeType node);

        /// <summary>
        /// Retrieves all of the Nodes on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <returns>The async task of collection of <see cref="NodeType"/></returns>
        Task<IEnumerable<NodeType>> GetNodes(NodeListOptions options = null);

        /// <summary>
        /// Retrieves all of the Nodes on a particular Network Domain at an MCP 2.0 data center.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <param name="pagingOptions"> The paging Options.</param>
        /// <returns>The async task of <see cref="PagedResponse{NodeType}"/></returns>
        Task<PagedResponse<NodeType>> GetNodesPaginated(NodeListOptions options = null, PageableRequest pagingOptions = null);

        /// <summary>
        /// Returns details of a single Node.
        /// </summary>
        /// <param name="nodeId">The Node id.</param>
        /// <returns>The async task of <see cref="NodeType"/></returns>
        Task<NodeType> GetNode(Guid nodeId);

        /// <summary>
        /// Updates the mutable properties of a Node.
        /// </summary>
        /// <param name="node">The edit node.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> EditNode(EditNodeType node);

        /// <summary>
        /// Deletes a Node.
        /// </summary>
        /// <param name="nodeId">The Node id.</param>
        /// <returns>The async task of <see cref="ResponseType"/></returns>
        Task<ResponseType> DeleteNode(Guid nodeId);
    }
}