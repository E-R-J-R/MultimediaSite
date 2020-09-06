using MultimediaSite.Core.DTO;
using MultimediaSite.Contracts;
using System.Web.Http;
using System.Collections.Generic;

namespace AnimeSatellite.Web.ApiControllers
{
    public class TagController : ApiController
    {
        private readonly ITagBL _tagBL;

        public TagController (ITagBL tagBL)
        {
            _tagBL = tagBL;
        }

        [HttpGet]
        public List<TagDTO> GetTagList()
        {
           return _tagBL.GetTagList();
        }
    }
}
