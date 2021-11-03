using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commends.User
{
    public class AuthenticatedCommandBase : IAuthenticatedCommand
    {
        public Guid UserId { get ; set ; }
    }
}
