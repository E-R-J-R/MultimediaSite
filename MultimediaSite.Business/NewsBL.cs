using System.Collections.Generic;
using System.IO;
using System.Linq;
using MultimediaSite.Contracts;
using MultimediaSite.Core.DTO;
using MultimediaSite.Domain;
using MultimediaSite.Domain.Entities;

namespace MultimediaSite.Business
{
    public class NewsBL : INewsBL
    {

        private readonly IMultimediaContext _ctx;
        private readonly ITagBL _tagBL;

        public NewsBL(IMultimediaContext ctx, ITagBL tagBL)
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
                                                    .Select(y => new TagDTO { TagId = y.Tag.TAGID, TagName = y.Tag.TAGNAME })
                                                    .ToList()
                                    })
                                    .Skip(skipRows)
                                    .Take(pageSize)
                                    .ToList();

            return newsList;
        }

        public int InsertNews(List<NewsDTO> newsList)
        {
            foreach(var n in newsList)
            {
                var newsItem = new NEWS();
                newsItem.HEADLINE = n.Headline;
                newsItem.CONTENT = n.Content;
                newsItem.CONTENTTYPE = n.ContentType;
                newsItem.EMBEDCODE = n.EmbedCode;
                newsItem.NEWSDATE = n.NewsDate;
                newsItem.PUBLISHEDDATE = n.PublishedDate;
                newsItem.SOURCENAME = n.SourceName;
                newsItem.SOURCEURL = n.SourceUrl;
                newsItem.IMAGEFILENAME = n.ImageFileName;

                _ctx.NEWS.Add(newsItem);
                _ctx.SaveChanges();

                var newsId = newsItem.NEWSID;

                //Fill tags for the news content
                foreach (var t in n.Tags)
                {
                    var tagMap = new TAGMAP();
                    tagMap.TAGCONTENTID = newsId;
                    tagMap.TAGCONTENTTYPE = "news";
                    tagMap.TAGID = t.TagId;
                    _ctx.TAGMAP.Add(tagMap);
                }

                _ctx.SaveChanges();
            }

            return 1;
        }

        public int DeleteNews(int newsId)
        {
            var entity = new NEWS { NEWSID = newsId };
            _ctx.NEWS.Attach(entity);
            _ctx.NEWS.Remove(entity);

            //Delete existing tags
            var tagMapList = _ctx.TAGMAP.Where(y => y.TAGCONTENTID == newsId).ToList();
            _ctx.TAGMAP.RemoveRange(tagMapList);

            return _ctx.SaveChanges();
        }

        public int UpdateNews(NewsDTO newsUpdate)
        {
            var newsItem = _ctx.NEWS.Single(x => x.NEWSID == newsUpdate.NewsId);
            newsItem.HEADLINE = newsUpdate.Headline;
            newsItem.CONTENT = newsUpdate.Content;
            newsItem.CONTENTTYPE = newsUpdate.ContentType;
            newsItem.EMBEDCODE = newsUpdate.EmbedCode;
            newsItem.NEWSDATE = newsUpdate.NewsDate;
            newsItem.PUBLISHEDDATE = newsUpdate.PublishedDate;
            newsItem.SOURCENAME = newsUpdate.SourceName;
            newsItem.SOURCEURL = newsUpdate.SourceUrl;
            newsItem.IMAGEFILENAME = Path.GetFileName(newsUpdate.ImageFileName);
            _ctx.NEWS.Attach(newsItem);

            //Delete existing tags
            var tagMapList = _ctx.TAGMAP.Where(y => y.TAGCONTENTID == newsItem.NEWSID).ToList();
            _ctx.TAGMAP.RemoveRange(tagMapList);

            //Fill tags for the news content
            foreach (var t in newsUpdate.Tags)
            {
                var tagMap = new TAGMAP();
                tagMap.TAGCONTENTID = newsItem.NEWSID;
                tagMap.TAGCONTENTTYPE = "news";
                tagMap.TAGID = t.TagId;
                _ctx.TAGMAP.Add(tagMap);
                
            }

            return _ctx.SaveChanges(); ;
        }
    }
}
