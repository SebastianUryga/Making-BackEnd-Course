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
        public AccountController(ICommandDispatcher commandDispathcer)
            :base(commandDispathcer)
        {
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> PutAsync([FromBody] ChangeUserPassword commad)
        {
            await DispatchAsync(commad);
            return NoContent();
        }

    }
}