using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.Drivers;
using Passenger.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _driverService;
        public CreateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task HandleAsync(CreateDriver command)
        {
            var driver = await _driverService.GetAsync(command.UserId);
            if(driver != null)
            {
                throw 
            }
        }
    }
}
