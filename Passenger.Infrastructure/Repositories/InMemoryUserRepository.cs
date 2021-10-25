using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@email.com","user1","zxcv","salt"),
            new User("user2@email.com","user2","secret","salt"),
            new User("user3@email.com","user3","secret","salt")
        };
        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => id == x.Id));
        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => email.ToLowerInvariant() == x.Email));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);
        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }
        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

    }
}
