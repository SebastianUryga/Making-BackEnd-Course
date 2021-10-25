using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Passenger.Core.Domain;


namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DaliyRoute> DaliyRoutes { get; protected set; }

    }
}
