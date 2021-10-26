using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRrepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IEncrypter encrypter, IMapper mapper)
        {
            _userRrepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRrepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRrepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception($"User with email: '{email}' does not exist.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(string email,string username ,string password)
        {
            var user = await _userRrepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: {email} allready exists");
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(email, username, hash, salt);
            await _userRrepository.AddAsync(user);
        }
    }
}
