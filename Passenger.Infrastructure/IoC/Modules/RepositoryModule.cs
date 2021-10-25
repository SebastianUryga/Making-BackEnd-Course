using Autofac;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
