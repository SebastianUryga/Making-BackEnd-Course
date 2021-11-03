using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.DTO
{
    public class DriversDetailsDto : DriverDto
    {
        public IEnumerable<RouteDto> Routes { get; set; }
    }
}
