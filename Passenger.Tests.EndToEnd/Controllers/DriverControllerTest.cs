using Newtonsoft.Json;
using Passenger.Infrastructure.Commends.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class DriverControllerTest : ControllerTestsBase
    {
        [Fact]
        public async Task given_vaild_driver_sholud_be_created()
        {
            var email = "user1@email.com";
            var user = await GetUserAsync(email);
            Assert.Equal(email, user.Email);


            var request = new CreateDriver
            {
                UserId = user.Id,
                Vehicle =
                {
                    Name = "name",
                    Brad = "brand",
                    Seats = 3
                }
            };
            var payload = GetPayLoad(request);
            var response = await _client.PostAsync("driver", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"driver/{request.UserId}", response.Headers.Location.ToString());

        }
    }
}
