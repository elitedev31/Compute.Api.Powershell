namespace DD.CBU.Compute.Api.Client.Interfaces.Tagging
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.General;
    using Contracts.Network20;
    using Contracts.Requests;
    using Contracts.Requests.Tagging;

    /// <summary>The TaggingAccessor interface.</summary>
    public interface ITaggingAccessor
    {
        /// <summary>The create tag key.</summary>
        /// <param name="createTagKey">The create tag key.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> CreateTagKey(createTagKeyType createTagKey);

        /// <summary>The get tag keys.</summary>
        /// <param name="tagKeyListOptions">The tag key list options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<IEnumerable<TagKeyType>> GetTagKeys(TagKeyListOptions tagKeyListOptions = null);

        /// <summary>The get tag keys paginated.</summary>
        /// <param name="tagKeyListOptions">The tag key list options.</param>
        /// <param name="paginngOptions">The paginng options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PagedResponse<TagKeyType>> GetTagKeysPaginated(TagKeyListOptions tagKeyListOptions = null, IPageableRequest paginngOptions = null);

        /// <summary>The get tag key.</summary>
        /// <param name="tagKeyId">The tag key id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<TagKeyType> GetTagKey(Guid tagKeyId);

        /// <summary>The edit tag key.</summary>
        /// <param name="editTagKey">The edit tag key.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> EditTagKey(EditTagKeyType editTagKey);

        /// <summary>The delete tag key.</summary>
        /// <param name="deleteTagKey">The delete tag key.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> DeleteTagKey(deleteTagKeyType deleteTagKey);

        /// <summary>The apply tags.</summary>
        /// <param name="applyTags">The apply tags.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> ApplyTags(applyTags applyTags);

        /// <summary>The get tags.</summary>
        /// <param name="tagListOptions">The tag list options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<IEnumerable<TagType>> GetTags(TagListOptions tagListOptions = null);

        /// <summary>The get tags paginated.</summary>
        /// <param name="tagListOptions">The tag list options.</param>
        /// <param name="paginngOptions">The paginng options.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PagedResponse<TagType>> GetTagsPaginated(TagListOptions tagListOptions = null, IPageableRequest paginngOptions = null);

        /// <summary>The remove tags.</summary>
        /// <param name="removeTags">The remove tags.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<ResponseType> RemoveTags(RemoveTagsType removeTags);
    }
}