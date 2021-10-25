using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRrepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRrepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRrepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email,string username ,string password)
        {
            var user = await _userRrepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: {email} allready exists");
            }
            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            await _userRrepository.AddAsync(user);
        }
    }
}
