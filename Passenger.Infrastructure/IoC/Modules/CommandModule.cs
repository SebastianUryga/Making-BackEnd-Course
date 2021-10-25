using Autofac;
using Passenger.Infrastructure.Commends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
