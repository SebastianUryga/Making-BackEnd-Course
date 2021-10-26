using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository,
            IUserRepository userRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver =  await _driverRepository.GetAsync(userId);
            return _mapper.Map<Driver, DriverDto>(driver);
        }
        public async Task CreateAsync(Guid userId, string brand, string name, int seats)
        {
            var user = await _userRepository.GetAsync(userId);
            if(user == null)
            {
                throw new Exception($"Can not create Driver. There is no users with id: {userId}.");
            }
            var driver = await _driverRepository.GetAsync(userId);
            if (user != null)
            {
                throw new Exception($"Driver with UserId {userId} allready exist.");
            }
            driver = new Driver(userId);
            //driver.Vehicle = Vehicle.Create(brand, name, seats);
            await _driverRepository.AddAsync(driver);
        }
    }
}
