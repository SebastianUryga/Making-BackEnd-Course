using Autofac;
using Passenger.Infrastructure.Services;
using System.Linq;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
