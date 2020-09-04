using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimeSatellite.Startup))]
namespace AnimeSatellite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
