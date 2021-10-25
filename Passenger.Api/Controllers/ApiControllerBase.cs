using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commends;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher _commandDispatcher;
        public ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }   
    }
}