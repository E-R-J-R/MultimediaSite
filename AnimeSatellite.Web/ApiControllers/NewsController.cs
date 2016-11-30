using System.Collections.Generic;
using System.Web.Http;
using AnimeSatellite.Contracts;
using AnimeSatellite.Core.DTO;
using AnimeSatellite.Core;

namespace AnimeSatellite.Web.ApiControllers
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

    }
}
