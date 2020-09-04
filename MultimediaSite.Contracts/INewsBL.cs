using System.Collections.Generic;
using MultimediaSite.Core.DTO;

namespace MultimediaSite.Contracts
{
    public interface INewsBL
    {
        List<NewsDTO> GetNewsList(int page, int pageSize, string newsImageUrl);
    }
}
