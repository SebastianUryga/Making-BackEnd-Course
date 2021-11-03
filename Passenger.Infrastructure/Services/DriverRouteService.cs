using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRouteManager _routeManager;
        private readonly IMapper _mapper;
        public DriverRouteService(IDriverRepository driverRepository,
            IUserRepository userRepository, IRouteManager routeManager,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _driverRepository = driverRepository;
            _routeManager = routeManager;
            _mapper = mapper;
        }
        public async Task AddAsync(Guid userId, string name, double startLongitude, double startLatitude,
            double endLongitude, double endLatitude)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Driver with '{userId}' was not found.");
            }
            var startAddress = await _routeManager.GetAddressAsync(startLatitude, startLongitude);
            var endAddress = await _routeManager.GetAddressAsync(endLatitude, endLongitude);
            var start = Node.Create(startAddress, startLongitude, startLatitude);
            var end = Node.Create(endAddress, endLongitude, endLatitude);
            var distance = _routeManager.CalculateDistance(startLatitude, startLongitude,
            endLatitude, endLongitude);
            driver.AddRoute(name,start,end, distance);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Driver with '{userId}' was not found.");
            }
            driver.DeleteRoute(name);
        }
    }
}
