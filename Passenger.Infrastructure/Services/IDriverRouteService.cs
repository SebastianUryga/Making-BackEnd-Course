using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverRouteService : IService
    {
        Task AddAsync(Guid userId, string name, 
            double startLongitude, double startLatitude,
            double endLogitude, double endLatitude);
        Task DeleteAsync(Guid userId, string name);
    }
}
