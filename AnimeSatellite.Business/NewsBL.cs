using System.Collections.Generic;
using AnimeSatellite.Contracts;
using AnimeSatellite.Core.DTO;

namespace AnimeSatellite.Business
{
    public class NewsBL : INewsBL
    {
        public List<NewsDTO> GetNewsList()
        {
            return new List<NewsDTO>();
        }
    }
}
