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
                cfg.CreateMap<Route, RouteDto>();
                cfg.CreateMap<Vehicle, VehicleDto>();
                cfg.CreateMap<Node,NodeDto>();
                cfg.RecognizePostfixes("Node");
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Driver, DriverDto>();
                cfg.CreateMap<Driver, DriversDetailsDto>();
            })
            .CreateMapper();
        }
    }
}
