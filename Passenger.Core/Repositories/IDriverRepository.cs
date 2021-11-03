using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IDriverRepository : IRepository
    {
        Task<Driver> GetAsync(Guid userid);
        Task<IEnumerable<Driver>> BrowseAsync();
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver dirver);

    }
}
