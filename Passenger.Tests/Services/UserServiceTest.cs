using AutoMapper;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var userservice = new UserService(userRepositoryMock.Object,encrypterMock.Object,mapperMock.Object);
            await userservice.RegisterAsync("user@email.com", "user", "secret");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
            await Assert.ThrowsAsync<Exception>(async delegate { await userservice.RegisterAsync("user@email.com", "", "222"); });
        }
    }
}
