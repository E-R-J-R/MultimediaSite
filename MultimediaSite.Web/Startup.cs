using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MultimediaSite.Web.Startup))]

namespace MultimediaSite.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {

        }
    }
}
