using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;

namespace MultimediaSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // TODO: Add any additional configuration code.

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //var json = config.Formatters.JsonFormatter;
            ////http://johnnycode.com/2012/04/10/serializing-circular-references-with-json-net-and-entity-framework/
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
