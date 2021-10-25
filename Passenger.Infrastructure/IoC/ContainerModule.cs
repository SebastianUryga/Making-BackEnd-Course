using Autofac;
using Microsoft.Extensions.Configuration;
using Passenger.Infrastructure.IoC.Modules;
using Passenger.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.IoC
{
    public class ContainerModule : Module
    {
        private readonly IConfiguration _configuration;
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initializate())
                .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>(); ;
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingModule(_configuration));
        }
    }
}
