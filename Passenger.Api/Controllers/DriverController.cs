using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.Drivers;
using Passenger.Infrastructure.Commends.User;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Settings;

namespace Passenger.Api.Controllers
{
    public class DriverController : ApiControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        public DriverController(ILogger<UsersController> logger,
            ICommandDispatcher commandDispatcher,
            GeneralSettings settings)
        : base(commandDispatcher)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDriver commad)
        {
            await _commandDispatcher.DispatchAsync(commad);
            return Created($"driver/{commad.UserId}", new object());
        }

    }
}
