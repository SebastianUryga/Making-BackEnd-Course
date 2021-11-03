using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.User;
using Passenger.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Users
{
    public class CreateUserHandelr : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        public CreateUserHandelr(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email, command.Username, command.Password, "user");
            
        }
    }
}
