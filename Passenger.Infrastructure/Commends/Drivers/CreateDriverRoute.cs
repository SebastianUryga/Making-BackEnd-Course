
using Passenger.Infrastructure.Commends.User;
using System;

namespace Passenger.Infrastructure.Commends.Drivers
{
    public class CreateDriverRoute : AuthenticatedCommandBase
    {
        public string Name { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
      
    }
}
