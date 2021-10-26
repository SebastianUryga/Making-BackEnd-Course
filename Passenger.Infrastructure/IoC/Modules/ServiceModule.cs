using Autofac;
using Passenger.Infrastructure.Services;
using System.Linq;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                .As<IEncrypter>()
                .SingleInstance();

            builder.RegisterType<JwtHandler>()
                .As<IJwtHandler>()
                .SingleInstance();
        }
    }
}
