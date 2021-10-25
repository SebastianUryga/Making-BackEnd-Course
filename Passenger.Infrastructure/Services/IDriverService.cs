using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService : IService
    {
        Task<DriverDto> GetAsync(Guid userId);
        Task CreateAsync(Guid userId, string brand, string name, int seats);
    }
}
