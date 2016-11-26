using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AnimeSatellite.Core.DTO;

namespace AnimeSatellite.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            SetApplicationSettings();
        }

        private void SetApplicationSettings()
        {
            ApplicationSettings.NewsImageUrl = System.Configuration.ConfigurationManager.AppSettings["NewsImageUrl"];
        }
    }
}
