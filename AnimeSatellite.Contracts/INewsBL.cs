using System.Collections.Generic;
using AnimeSatellite.Core.DTO;

namespace AnimeSatellite.Contracts
{
    public interface INewsBL
    {
        List<NewsDTO> GetNewsList(int page, int pageSize, string newsImageUrl);
    }
}
