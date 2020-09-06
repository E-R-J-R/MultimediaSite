using System.Collections.Generic;
using MultimediaSite.Core.DTO;

namespace MultimediaSite.Contracts
{
    public interface IMovieBL
    {
        List<MovieDTO> GetMovieList(int page, int pageSize, string movieImageUrl);
    }
}
