using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AnimeSatellite.Core.DTO;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AnimeSatellite.Core;
using AnimeSatellite.Business;
using AnimeSatellite.Domain;

namespace AnimeSatellite.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BusinessModule());
            builder.RegisterModule(new DomainModule());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            IoC.Container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(IoC.Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(IoC.Container));

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           

            SetApplicationSettings();
        }

        private void SetApplicationSettings()
        {
            ApplicationSettings.NewsImageUrl = System.Configuration.ConfigurationManager.AppSettings["NewsImageUrl"];
            ApplicationSettings.MoviesImageUrl = System.Configuration.ConfigurationManager.AppSettings["MoviesImageUrl"];
            ApplicationSettings.NewsPageSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NewsPageSize"]);
            ApplicationSettings.MoviesPageSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MoviesPageSize"]);
        }
    }
}
