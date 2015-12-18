namespace DD.CBU.Compute.Api.Client.Interfaces.Server20
{
    using System.Collections.Generic;
    using System.Threading.Tasks; 
    using System;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests.Server20;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Requests;

    /// <summary>
    /// The ServerAccessor interface.
    /// </summary>
    public interface IServerImageAccessor
    {          
        /// <summary>
        /// Get the OS images supported on this data center
        /// </summary>
        /// <param name="imageId">
        /// The image Id
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>	
        Task<OsImageType> GetOsImage(Guid imageId);

        /// <summary>
        /// The get OS images supported on this data center
        /// </summary>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>	
        Task<PagedResponse<OsImageType>> GetOsImages(ServerOsImageListOptions filteringOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>
        /// Get the customer images supported on this data center
        /// </summary>
        /// <param name="imageId">
        /// The image Id
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>	
        Task<CustomerImageType> GetCustomerImage(Guid imageId);

        /// <summary>
        /// The get customer images supported on this data center
        /// </summary>
        /// <param name="filteringOptions">
        /// The filtering options.
        /// </param>
        /// <param name="pagingOptions">
        /// The paging options.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>	
        Task<PagedResponse<CustomerImageType>> GetCustomerImages(ServerCustomerImageListOptions filteringOptions = null, IPageableRequest pagingOptions = null);

        /// <summary>
        /// Edit the customer image metadata
        /// </summary>
        /// <param name="imageMetadata">
        /// The image metadata
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>	
        Task<ResponseType> EditCustomerImageMetadata(ImageMetadataType imageMetadata);
    }
}
