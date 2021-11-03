using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Moq;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.Commends.User;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Repositories;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UserControllerTest : ControllerTestsBase
    {
        [Fact]
        public async Task given_vaild_path_should_response_Not_Found()
        {
            var responce = await _client.GetAsync("/");
            //var responce = await _host.GetTestClient().GetAsync("/");
            Assert.Equal(HttpStatusCode.NotFound, responce.StatusCode);
        }
        [Fact]
        public async Task given_vaild_email_user_should_exist()
        {
            var email = "user1@test.com";

            var responce = await _client.GetAsync($"Users/{email}");
            Assert.Equal(HttpStatusCode.OK, responce.StatusCode);

            var responceString = await responce.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responceString);

            Assert.Equal(email, user.Email);
        }
        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email = "user11@email.com",
                Username = "user11",
                Password = "secret11"
            };
            var payload  = GetPayLoad(request);
            var responce = await _client.PostAsync("users",payload);
            Assert.Equal(HttpStatusCode.Created, responce.StatusCode);
            Assert.Equal($"users/{request.Email}", responce.Headers.Location.ToString());

            var user = await GetUserAsync(request.Email);
            Assert.Equal(request.Email, user.Email);
            Assert.Equal(request.Username, user.Username);
        }
        
    }
}
