using System.Collections.Generic;
using System.Web.Http;
using AnimeSatellite.Core;
using AnimeSatellite.Core.DTO;
using AnimeSatellite.Contracts;

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

             return value;
        }

        
    }
}