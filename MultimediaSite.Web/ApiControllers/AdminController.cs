using System.Web.Http;
using MultimediaSite.Core.DTO;
using MultimediaSite.Contracts;

namespace AnimeSatellite.Web.ApiControllers
{
    public class AdminController : ApiController
    {
        private readonly INewsBL _newsBl;

        public AdminController(INewsBL newsBl)
        {
            _newsBl = newsBl;
        }

    }
}
