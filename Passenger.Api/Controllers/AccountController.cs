using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.User;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        public AccountController(ICommandDispatcher commandDispathcer,
            IJwtHandler jwtHandler) :base(commandDispathcer)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken("user1@email.com", "admin");
            return Json(token);
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> PutAsync([FromBody] ChangeUserPassword commad)
        {
            await _commandDispatcher.DispatchAsync(commad);
            return NoContent();
        }

    }
}