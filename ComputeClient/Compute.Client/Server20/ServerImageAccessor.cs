namespace DD.CBU.Compute.Api.Client.Server20
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Client.Interfaces.Server20;
    using DD.CBU.Compute.Api.Contracts.General;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Api.Contracts.Requests;
    using DD.CBU.Compute.Api.Contracts.Requests.Server20;

    /// <summary>
    /// The server 2.0 image accessor.
    /// </summary>
    public class ServerImageAccessor : IServerImageAccessor
    {
        /// <summary>
        /// The _api client.
        /// </summary>
        private readonly IWebApi _apiClient;

        /// <summary>
        /// Initialises a new instance of the <see cref="ServerAccessor"/> class.
        /// </summary>
        /// <param name="apiClient">
        /// The api client.
        /// </param>
        public ServerImageAccessor(IWebApi apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Get OS Images
        /// </summary>
        /// <param name="filteringOptions">Filtering options</param>
        /// <returns>OS Images</returns>
        public async Task<IEnumerable<OsImageType>> GetOsImages(ServerOsImageListOptions filteringOptions = null)
        {
            var response = await GetOsImagesPaginated(filteringOptions, null);
            return response.items;
        }

        /// <summary>
        /// Get OS Image
        /// </summary>
        /// <param name="imageId">Image Identifier</param>
        /// <returns>OS Image</returns>
        public async Task<OsImageType> GetOsImage(Guid imageId)
        {
            return await _apiClient.GetAsync<OsImageType>(
              ApiUris.GetMcp2OsImage(_apiClient.OrganizationId, imageId));
        }

        /// <summary>
        /// Get OS Images
        /// </summary>
        /// <param name="filteringOptions">Filtering options</param>
        /// <returns>OS Images</returns>
        public async Task<PagedResponse<OsImageType>> GetOsImagesPaginated(ServerOsImageListOptions filteringOptions = null, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<osImages>(
                 ApiUris.GetMcp2OsImages(_apiClient.OrganizationId),
                 pagingOptions,
                 filteringOptions);

            return new PagedResponse<OsImageType>
            {
                items = response.osImage,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Get Customer Images
        /// </summary>
        /// <param name="filteringOptions">Filtering options</param>
        /// <returns>Customer Images</returns>
        public async Task<IEnumerable<CustomerImageType>> GetCustomerImages(ServerOsImageListOptions filteringOptions = null)
        {
            var response = await GetCustomerImagesPaginated(filteringOptions, null);
            return response.items;
        }

        /// <summary>
        /// Get Customer Image
        /// </summary>
        /// <param name="imageId">Image Id</param>
        /// <returns>Customer Image</returns>
        public async Task<CustomerImageType> GetCustomerImage(Guid imageId)
        {
            return await _apiClient.GetAsync<CustomerImageType>(
            ApiUris.GetMcp2CustomerImage(_apiClient.OrganizationId, imageId));
        }

        /// <summary>
        /// Get Customer Images
        /// </summary>
        /// <param name="filteringOptions">Filtering options</param>
        /// <param name="pagingOptions">Paging options</param>
        /// <returns>Customer Images</returns>
        public async Task<PagedResponse<CustomerImageType>> GetCustomerImagesPaginated(ServerOsImageListOptions filteringOptions = null, IPageableRequest pagingOptions = null)
        {
            var response = await _apiClient.GetAsync<customerImages>(
                ApiUris.GetMcp2CustomerImages(_apiClient.OrganizationId),
                pagingOptions,
                filteringOptions);

            return new PagedResponse<CustomerImageType>
            {
                items = response.customerImage,
                totalCount = response.totalCountSpecified ? response.totalCount : (int?)null,
                pageCount = response.pageCountSpecified ? response.pageCount : (int?)null,
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?)null,
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?)null
            };
        }

        /// <summary>
        /// Edit Customer Image Metadata
        /// </summary>
        /// <param name="imageMetadata">Image Metadata</param>
        /// <returns>Response Data</returns>
        public async Task<ResponseType> EditCustomerImageMetadata(ImageMetadataType imageMetadata)
        {
            return await _apiClient.PostAsync<ImageMetadataType, ResponseType>(
            ApiUris.EditMcp2CustomerImageMetadata(_apiClient.OrganizationId), imageMetadata);
        }
    }
}
