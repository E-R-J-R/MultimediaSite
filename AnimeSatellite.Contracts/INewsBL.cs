using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimeSatellite.Core.DTO;

namespace AnimeSatellite.Contracts
{
    public interface INewsBL
    {
        List<NewsDTO> GetNewsList();
    }
}
