using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Xunit;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Passenger.Api;
using Passenger.Infrastructure.Commends.User;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class AccountControllerTest : ControllerTestsBase
    {
        [Fact]
        public async Task given_valid_currnet_and_new_password_it_should_changed()
        {
            var request = new ChangeUserPassword
            {
                CurrentPassword = "secret11",
                NewPassword = "secret12"
            };
            var payload = GetPayLoad(request);
            var responce = await _client.PutAsync("account/password", payload);
            Assert.Equal(HttpStatusCode.NoContent, responce.StatusCode);
        }
    }
}
