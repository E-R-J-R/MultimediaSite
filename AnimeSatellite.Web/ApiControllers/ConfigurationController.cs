using System.Linq;
using System.Web.Http;
using AnimeSatellite.Core.DTO;
using AnimeSatellite.Domain;

namespace AnimeSatellite.Web.ApiControllers
{
    public class ConfigurationController : ApiController
    {

        [Route("api/configuration/getconfig/{key}")]
        [HttpGet]
        public string GetConfig(string key)
        {
            var value = string.Empty;

            switch (key)
            {
                case nameof(ApplicationSettings.NewsImageUrl):
                    value = ApplicationSettings.NewsImageUrl;
                    break;
                default:
                    value = "";
                    break;
            }

            using (var ctx = new AnimationContext())
            {
                var newsList = ctx.NEWS.FirstOrDefault();
            }

             return value;
        }

        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}