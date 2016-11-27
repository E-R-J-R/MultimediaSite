using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace AnimeSatellite.Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
        }

    }
}
