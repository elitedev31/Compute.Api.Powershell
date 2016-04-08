namespace DD.CBU.Compute.Api.Client.Tagging
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.General;
    using Contracts.Network20;
    using Contracts.Requests;
    using Contracts.Requests.Tagging;
    using Interfaces;
    using Interfaces.Tagging;

    /// <summary>The tagging accessor.</summary>
    public class TaggingAccessor : ITaggingAccessor
    {
        /// <summary>
        /// The _api client.
        /// </summary>
        private readonly IWebApi _apiClient;

        /// <summary>Initializes a new instance of the <see cref="TaggingAccessor"/> class.</summary>
        /// <param name="apiClient">The api client.</param>
        public TaggingAccessor(IWebApi apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>The create tag key.</summary>
        /// <param name="createTagKey">The create tag key.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> CreateTagKey(CreateTagKeyType createTagKey)
        {
            return await _apiClient.PostAsync<CreateTagKeyType, ResponseType>(ApiUris.CreateTagKey(_apiClient.OrganizationId), createTagKey);
        }

        /// <summary>The get tag keys.</summary>
        /// <param name="tagKeyListOptions">The tag key list options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IEnumerable<TagKeyType>> GetTagKeys(TagKeyListOptions tagKeyListOptions = null)
        {
            var tagkeys = await GetTagKeysPaginated(tagKeyListOptions);
            return tagkeys.items;
        }

        /// <summary>The get tag keys paginated.</summary>
        /// <param name="tagKeyListOptions">The tag key list options.</param>
        /// <param name="paginngOptions">The paginng options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PagedResponse<TagKeyType>> GetTagKeysPaginated(TagKeyListOptions tagKeyListOptions = null, IPageableRequest paginngOptions = null)
        {
            var response = await _apiClient.GetAsync<TagKeys>(ApiUris.ListTagKeys(_apiClient.OrganizationId));
            return new PagedResponse<TagKeyType>
            {
                items = response.tagKey, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>The get tag key.</summary>
        /// <param name="tagKeyId">The tag key id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<TagKeyType> GetTagKey(Guid tagKeyId)
        {
            return await _apiClient.GetAsync<TagKeyType>(ApiUris.GetTagKey(_apiClient.OrganizationId, tagKeyId));
        }

        /// <summary>The edit tag key.</summary>
        /// <param name="editTagKey">The edit tag key.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> EditTagKey(EditTagKeyType editTagKey)
        {
            return await _apiClient.PostAsync<EditTagKeyType, ResponseType>(ApiUris.EditTagKey(_apiClient.OrganizationId), editTagKey);
        }

        /// <summary>The delete tag key.</summary>
        /// <param name="deleteTagKey">The delete tag key.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> DeleteTagKey(DeleteTagKeyType deleteTagKey)
        {
            return await _apiClient.PostAsync<DeleteTagKeyType, ResponseType>(ApiUris.DeleteTagKey(_apiClient.OrganizationId), deleteTagKey);
        }

        /// <summary>The apply tags.</summary>
        /// <param name="applyTags">The apply tags.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> ApplyTags(ApplyTags applyTags)
        {
            return await _apiClient.PostAsync<ApplyTags, ResponseType>(ApiUris.ApplyTags(_apiClient.OrganizationId), applyTags);
        }

        /// <summary>The get tags.</summary>
        /// <param name="tagListOptions">The tag list options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IEnumerable<TagType>> GetTags(TagListOptions tagListOptions = null)
        {
            var tags = await GetTagsPaginated(tagListOptions);
            return tags.items;
        }

        /// <summary>The get tags paginated.</summary>
        /// <param name="tagListOptions">The tag list options.</param>
        /// <param name="paginngOptions">The paginng options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PagedResponse<TagType>> GetTagsPaginated(TagListOptions tagListOptions = null, IPageableRequest paginngOptions = null)
        {
            var response = await _apiClient.GetAsync<Tags>(ApiUris.ListTagKeys(_apiClient.OrganizationId));
            return new PagedResponse<TagType>
            {
                items = response.tag, 
                totalCount = response.totalCountSpecified ? response.totalCount : (int?) null, 
                pageCount = response.pageCountSpecified ? response.pageCount : (int?) null, 
                pageNumber = response.pageNumberSpecified ? response.pageNumber : (int?) null, 
                pageSize = response.pageSizeSpecified ? response.pageSize : (int?) null
            };
        }

        /// <summary>The remove tags.</summary>
        /// <param name="removeTags">The remove tags.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<ResponseType> RemoveTags(RemoveTagsType removeTags)
        {
            return await _apiClient.PostAsync<RemoveTagsType, ResponseType>(ApiUris.RemoveTag(_apiClient.OrganizationId), removeTags);
        }
    }
}