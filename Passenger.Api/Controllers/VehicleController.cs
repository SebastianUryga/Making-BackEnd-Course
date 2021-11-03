using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.User;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Settings;

namespace Passenger.Api.Controllers
{
    public class VehicleController : ApiControllerBase
    {
        private readonly IVehicleProvider _vehicleProvider;
        public VehicleController(ICommandDispatcher commandDispatcher,
           IVehicleProvider vehicleProvider)
        : base(commandDispatcher)
        {
            _vehicleProvider = vehicleProvider;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = await _vehicleProvider.BrowseAsync();

            return Json(vehicles);
        }

    }
}
