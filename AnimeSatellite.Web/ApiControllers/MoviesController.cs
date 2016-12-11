using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AnimeSatellite.Contracts;
using AnimeSatellite.Core.DTO;
using AnimeSatellite.Core;

namespace AnimeSatellite.Web.ApiControllers
{
    public class MoviesController : ApiController
    {
        private readonly IMovieBL _movieBl;
        
        public MoviesController(IMovieBL movieBl)
        {
            _movieBl = movieBl;
        }   

        [HttpGet]
        public List<MovieDTO> GetMovies(int page)
        {
            return _movieBl.GetMovieList(page, ApplicationSettings.MoviesPageSize, ApplicationSettings.MoviesImageUrl);
        } 
    }
}
