using System.Collections.Generic;
using System.Linq;
using MultimediaSite.Contracts;
using MultimediaSite.Core.DTO;
using MultimediaSite.Domain;

namespace MultimediaSite.Business
{
    public class MovieBL : IMovieBL
    {
        private readonly IAnimationContext _ctx;

        public MovieBL(IAnimationContext ctx)
        {
            _ctx = ctx;
        }

        public List<MovieDTO> GetMovieList (int page, int pageSize, string movieImageUrl)
        {
            var skipRows = (page - 1) * pageSize;

            var movieList = _ctx.MOVIE.AsNoTracking()
                                .OrderByDescending(x => x.RELEASEDATE).ThenBy(x => x.MOVIEID)
                                .Select(x => new MovieDTO
                                {
                                    MovieId = x.MOVIEID,
                                    Title = x.TITLE,
                                    Synopsis = x.SYNOPSIS,
                                    Length = x.LENGTH,
                                    ReleaseDate = x.RELEASEDATE,
                                    Producer = x.PRODUCER,
                                    ImageFileName = movieImageUrl + x.IMAGEFILENAME,
                                    Links = _ctx.MOVIELINK
                                                .Where(y => y.MOVIEID == x.MOVIEID)
                                                .Select(y => new MovieLinkDTO
                                                {
                                                    MovieLinkId = y.MOVIELINKID,
                                                    MovieId = y.MOVIEID,
                                                    LinkUrl = y.LINKURL,
                                                    LinkType = y.LINKTYPE,
                                                    AutoPlay = y.AUTOPLAY,
                                                    FullScreen = y.FULLSCREEN,
                                                    EmbedCode = y.EMBEDCODE
                                                }).OrderBy(y => y.MovieLinkId).ToList()
                                 })
                                 .Skip(skipRows)
                                 .Take(pageSize)
                                 .ToList();

            return movieList;
                                
        }
    }
}
