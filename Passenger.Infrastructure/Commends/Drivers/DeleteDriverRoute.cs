using Passenger.Infrastructure.Commends.User;
using System;

namespace Passenger.Infrastructure.Commends.Drivers
{
    public class DeleteDriverRoute : AuthenticatedCommandBase
    {
        public string Name { get; set; }
    }
}
