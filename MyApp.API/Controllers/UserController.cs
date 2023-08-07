using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Contracts;
using MyApp.Application.Services.Interfaces;
using Serilog;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            _logger.LogInformation("API.Controller -> GetAllUsersAsync");
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
