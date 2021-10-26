using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Passenger.Infrastructure.Commends;
using Passenger.Infrastructure.Commends.User;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Settings;

namespace Passenger.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        public UsersController(ILogger<UsersController> logger,
            IUserService userService, ICommandDispatcher commandDispatcher,
            GeneralSettings settings)
        :base(commandDispatcher)
        {
            _logger = logger;
            _userService = userService;
        }

        [Authorize]
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if(user == null)
            {
                return NotFound();
            }
            return new JsonResult(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser commad)
        {
            await _commandDispatcher.DispatchAsync(commad);
            return Created($"users/{commad.Email}", new object());
        }
        
    }
}
