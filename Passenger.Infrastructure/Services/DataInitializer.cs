using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IDriverRouteService _driverRouteService;
        private readonly ILogger<IDataInitializer> _logger;

        public DataInitializer(IUserService userService,
             IDriverService driverService , IDriverRouteService driverRouteService,
             ILogger<IDataInitializer> logger)
        {
            _userService = userService;
            _driverService = driverService;
            _driverRouteService = driverRouteService;

            _logger = logger;
        }
        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for (var i=1 ;i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                tasks.Add(_userService.RegisterAsync(userId,
                    $"{username}@test.com",username,"secret","user"));
                tasks.Add(_driverService.CreateAsync(userId));
                tasks.Add(_driverService.SetVehicleAsync(userId, "BMW", "i8"));
                tasks.Add(_driverRouteService.AddAsync(userId,$"default route{i}",30,40,31,40));
                tasks.Add(_driverRouteService.AddAsync(userId,$"job route{i}",3,4,1,0));

            }
            for (var i = 1; i <= 3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                tasks.Add(_userService.RegisterAsync(userId,
                    $"{username}@test.com", username, "secret","admin"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data wad initialized.");
        }
    }
}
