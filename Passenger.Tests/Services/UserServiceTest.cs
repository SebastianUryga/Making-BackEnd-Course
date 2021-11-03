using AutoMapper;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Testes.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task Test()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();
            var encrypter = new Encrypter();
            var userservice = new UserService(userRepositoryMock.Object,encrypter,mapperMock.Object);
            await userservice.RegisterAsync(Guid.NewGuid(),"user@email.com", "user", "secret","user");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
            await Assert.ThrowsAsync<Exception>(async delegate { await userservice.RegisterAsync(Guid.NewGuid(),"user@email.com", "", "222","user"); });
        }
    }
}
