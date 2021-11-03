using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Route("driver/routes")]
    public class DriverRouteController : ApiControllerBase
    {
        private readonly IDriverRouteService _driverRouteService;
        public DriverRouteController(ICommandDispatcher commandDispatcher,
           IDriverRouteService driverRouteService)
        : base(commandDispatcher)
        {
            _driverRouteService = driverRouteService;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateDriverRoute commad)
        {
            await DispatchAsync(commad);

            return NoContent();
        }
        [Authorize]
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteDriverRoute command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
    }
}
