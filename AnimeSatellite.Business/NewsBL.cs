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

        public NewsBL(IAnimationContext ctx)
        {
            _ctx = ctx;
        }

        public List<NewsDTO> GetNewsList(int page, int pageSize, string newsImageUrl)
        {
            var skipRows = (page - 1) * pageSize;

            var newsList = _ctx.NEWS.AsNoTracking()
                                    .OrderByDescending(x => x.NEWSDATE)
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
                                        ImageFileName = newsImageUrl + x.IMAGEFILENAME
                                    })
                                    .Skip(skipRows)
                                    .Take(pageSize)
                                    .ToList();

            return newsList;
        }
    }
}
