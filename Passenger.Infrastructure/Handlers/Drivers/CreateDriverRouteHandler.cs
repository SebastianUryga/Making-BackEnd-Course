using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.Drivers;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class CreateDriverRouteHandler : ICommandHandler<CreateDriverRoute>
    {
        private readonly IDriverRouteService _driverRouteService;
        public CreateDriverRouteHandler(IDriverRouteService driverRouteService)
        {
            _driverRouteService = driverRouteService;
        }
        public async Task HandleAsync(CreateDriverRoute command)
        {
            await _driverRouteService.AddAsync(command.UserId,command.Name,
                command.StartLongitude,command.StartLongitude,
                command.EndLongitude,command.EndLatitude);
        }
    }
}
