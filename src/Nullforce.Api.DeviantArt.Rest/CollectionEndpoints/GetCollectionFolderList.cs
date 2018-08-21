using Flurl;

namespace Nullforce.Api.DeviantArt.Rest.CollectionEndpoints
{
    /// <summary>
    /// Fetch collection folders
    /// 
    /// You can preload up to 5 deviations from each folder by passing ext_preload parameter. It is mainly useful to reduce number of requests to API.
    /// </summary>
    public class GetCollectionFolderList : PagedRestBase<GetCollectionFolderList>, IMatureContent<GetCollectionFolderList>
    {
        public const int MaxOffset = 50_000;
        public const int MaxLimit = 50;

        public GetCollectionFolderList(string apiBaseUrl)
            : base(maxOffset: MaxOffset, maxLimit: MaxLimit)
        {
            _uri = apiBaseUrl.AppendPathSegment("/collections/folders");
        }

        public GetCollectionFolderList WithUsername(string username)
        {
            _uri = _uri.SetQueryParam("username", username);
            return this;
        }

        public GetCollectionFolderList WithCalculateSize(bool calculateSize = true)
        {
            _uri = _uri.SetQueryParam("calculate_size", calculateSize ? "true" : "false");
            return this;
        }

        public GetCollectionFolderList WithExtendedPreload(bool extendedPreload = true)
        {
            _uri = _uri.SetQueryParam("ext_preload", extendedPreload ? "true" : "false");
            return this;
        }

        public GetCollectionFolderList WithMatureContent(bool allowMature = true)
        {
            _uri = _uri.SetQueryParam("mature_content", allowMature ? "true" : "false");
            return this;
        }
    }
}
