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
    public class DriverController : ApiControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(ICommandDispatcher commandDispatcher,
           IDriverService driverService, GeneralSettings settings)
        : base(commandDispatcher)
        {
            _driverService = driverService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var drivers = await _driverService.BrowseAsync();
            
            return Json(drivers);
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var driver = await _driverService.GetAsync(userId);
            if (driver == null)
            {
                return NotFound();
            }
            return Json(driver);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDriver commad)
        {
            await DispatchAsync(commad);
            return Created($"driver/{commad.UserId}", new object());
        }

    }
}
