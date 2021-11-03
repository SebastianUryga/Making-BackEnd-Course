using Newtonsoft.Json;
using Passenger.Infrastructure.Commends.Drivers;
using Passenger.Infrastructure.Commends.User;
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
            var email = "admin1@test.com";
            var user = await GetUserAsync(email);
            Assert.Equal(email, user.Email);
            
            var request = new CreateDriver
            {
                UserId = user.Id,
                Vehicle = new CreateDriver.DriverVehicle
                {
                    Brand  = "BMW",
                    Name = "i8",
                    Seats = 3
                }
            };
            var payload = GetPayLoad(request);
            var response = await _client.PostAsync("Driver", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"driver/{request.UserId}", response.Headers.Location.ToString());

        }
    }
}
