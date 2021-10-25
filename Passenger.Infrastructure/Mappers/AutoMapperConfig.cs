using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initializate()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Driver, DriverDto>();
            })
            .CreateMapper();
        }
    }
}
