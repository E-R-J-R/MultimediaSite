using System.Collections.Generic;
using System.Web.Http;
using MultimediaSite.Core;
using MultimediaSite.Core.DTO;
using MultimediaSite.Contracts;

namespace MultimediaSite.Web.ApiControllers
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