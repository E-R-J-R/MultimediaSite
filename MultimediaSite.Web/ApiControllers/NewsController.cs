﻿using System.Collections.Generic;
using System.Web.Http;
using MultimediaSite.Contracts;
using MultimediaSite.Core.DTO;
using MultimediaSite.Core;

namespace MultimediaSite.Web.ApiControllers
{
    public class NewsController : ApiController
    {
        private readonly INewsBL _newsBL;

        public NewsController(INewsBL newsBL)
        {
            _newsBL = newsBL;
        }

        //[Route("api/news/getnews/")]
        [HttpGet]
        public List<NewsDTO> GetNews(int page)
        {
            return _newsBL.GetNewsList(page, ApplicationSettings.NewsPageSize, ApplicationSettings.NewsImageUrl);
        }

        [HttpPost]
        public int InsertNews([FromBody]List<NewsDTO> newsList)
        {
            return _newsBL.InsertNews(newsList);
        }

        [HttpPost]
        public int DeleteNews(int newsId)
        {
            return _newsBL.DeleteNews(newsId);
        }

        [HttpPost]
        public int UpdateNews([FromBody]NewsDTO newsItem)
        {
            return _newsBL.UpdateNews(newsItem);
        }

    }
}
