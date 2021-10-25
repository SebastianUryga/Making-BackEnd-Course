using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DaliyRoute> DaliyRoutes { get; protected set; }

        protected Driver()
        {

        }
        public Driver(Guid userid)
        {
            UserId = userid;
        }
    }
}
