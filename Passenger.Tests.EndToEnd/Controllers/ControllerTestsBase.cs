using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.DTO;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly WebApplicationFactory<Startup> factory;

        protected readonly HttpClient _client;
        protected readonly TestServer _server;
        protected readonly IHost _host;

        public ControllerTestsBase()
        {
            factory = new WebApplicationFactory<Startup>();
            /* _host = new HostBuilder()
                 .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                 .ConfigureWebHost(web => web.UseStartup<Startup>().UseTestServer()).StartAsync().Result;
             _server = new TestServer(new WebHostBuilder()
                 .UseStartup<Startup>()
                 .ConfigureServices(services => services.AddAutofac()));
            */
            //_client = _server.CreateClient();
            //_client = _host.GetTestClient();
            _client = factory.CreateClient();
        }
        protected async Task<UserDto> GetUserAsync(string email)
        {
            var responce = await _client.GetAsync($"Users/{email}");
            var responceString = await responce.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responceString);

        }
        protected static StringContent GetPayLoad(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
