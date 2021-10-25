using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
