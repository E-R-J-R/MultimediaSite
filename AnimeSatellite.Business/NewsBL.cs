using System.Collections.Generic;
using System.Linq;
using AnimeSatellite.Contracts;
using AnimeSatellite.Core.DTO;
using AnimeSatellite.Domain;

namespace AnimeSatellite.Business
{
    public class NewsBL : INewsBL
    {

        private readonly IAnimationContext _ctx;
        private readonly ITagBL _tagBL;

        public NewsBL(IAnimationContext ctx, ITagBL tagBL)
        {
            _ctx = ctx;
            _tagBL = tagBL;
        }

        public List<NewsDTO> GetNewsList(int page, int pageSize, string newsImageUrl)
        {
            var skipRows = (page - 1) * pageSize;

            var newsList = _ctx.NEWS.AsNoTracking()
                                    .OrderByDescending(x => x.NEWSDATE).ThenBy(x => x.NEWSID)
                                    .Select(x => new NewsDTO
                                    {
                                        NewsId = x.NEWSID,
                                        Headline = x.HEADLINE,
                                        Content = x.CONTENT,
                                        ContentType = x.CONTENTTYPE,
                                        EmbedCode = x.EMBEDCODE,
                                        NewsDate = x.NEWSDATE,
                                        PublishedDate = x.PUBLISHEDDATE,
                                        SourceName = x.SOURCENAME,
                                        SourceUrl = x.SOURCEURL,
                                        ImageFileName = newsImageUrl + x.IMAGEFILENAME,
                                        Tags = _ctx.TAGMAP
                                                   .Join(_ctx.TAG,
                                                         map => map.TAGID,
                                                         tag => tag.TAGID,
                                                         (map, tag) => new { TagMap = map, Tag = tag })
                                                    .Where(y => y.TagMap.TAGCONTENTID == x.NEWSID && y.TagMap.TAGCONTENTTYPE == "news")
                                                    .Select(y => y.Tag.TAGNAME)
                                                    .ToList()
                                    })
                                    .Skip(skipRows)
                                    .Take(pageSize)
                                    .ToList();

            return newsList;
        }
    }
}
