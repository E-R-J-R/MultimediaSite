using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaSite.Core.DTO;

namespace MultimediaSite.Contracts
{
    public interface IMovieBL
    {
        List<MovieDTO> GetMovieList(int page, int pageSize, string movieImageUrl);
    }
}
