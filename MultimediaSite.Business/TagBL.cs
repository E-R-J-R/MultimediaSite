using System.Collections.Generic;
using System.Linq;
using MultimediaSite.Contracts;
using MultimediaSite.Domain;
using MultimediaSite.Core.DTO;

namespace MultimediaSite.Business
{
    public class TagBL : ITagBL
    {
        private readonly IMultimediaContext _ctx;

        public TagBL (IMultimediaContext ctx)
        {
            _ctx = ctx;
        }

        public List<string>  GetContentTags (int tagContentId, string tagContentType)
        {
            var tags = _ctx.TAGMAP.AsNoTracking()
                           .Join(_ctx.TAG,
                                 map => map.TAGID,
                                 tag => tag.TAGID,
                                 (map, tag) => new { TagMap = map, Tag = tag })
                            .Where(x => x.TagMap.TAGCONTENTID == tagContentId && x.TagMap.TAGCONTENTID == tagContentId)
                            .Select(X => X.Tag.TAGNAME)
                            .ToList();

            return tags;
                                
        }

        public List<TagDTO> GetTagList()
        {
            return _ctx.TAG.AsNoTracking()
                       .Select(x => new TagDTO {
                           TagId = x.TAGID,
                           TagName = x.TAGNAME
                       })
                       .ToList();
        }
    }
}
