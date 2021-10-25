using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static ISet<Driver> _drivers = new HashSet<Driver>();
        
        public async Task<Driver> GetAsync(Guid userid)
            => await Task.FromResult(_drivers.Single(x => x.UserId == userid));

        public async Task<IEnumerable<Driver>> GetAllAsync()
            => await Task.FromResult(_drivers);

        public async Task AddAsync(Driver driver)
        {
            _drivers.Add(driver);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Driver dirver)
        {
            await Task.CompletedTask;
        }
    }
}
