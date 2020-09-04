using System.Collections.Generic;
using System.Linq;
using MultimediaSite.Contracts;
using MultimediaSite.Domain;

namespace MultimediaSite.Business
{
    public class TagBL : ITagBL
    {
        private readonly IAnimationContext _ctx;

        public TagBL (IAnimationContext ctx)
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
    }
}
