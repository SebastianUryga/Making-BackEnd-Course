using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.User;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        public LoginHandler(IUserService userService,IJwtHandler jwtHandler,
            IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }
        public async Task HandleAsync(Login command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            _cache.SetJwr(command.TokenId, jwt);
        }
    }
}
