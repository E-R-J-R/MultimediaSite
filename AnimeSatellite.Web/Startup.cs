using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AnimeSatellite.Web.Startup))]

namespace AnimeSatellite.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {

        }
    }
}
