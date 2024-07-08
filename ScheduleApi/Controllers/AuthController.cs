using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ScheduleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-all-users")]
        public dynamic testing()
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                return userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Connection to the database failed: {ex.Message}");
            }
        }

    }
}