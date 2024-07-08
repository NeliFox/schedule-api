using System.Data;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace ScheduleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MySqlConnection _dbConnection;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, MySqlConnection dbConnection)
        {

            _dbConnection = dbConnection;
            _logger = logger;
        }

       

         [HttpGet]
    public async Task<IActionResult> testing()
    {
            // DotNetEnv.Env.Load();
            // var message = Environment.GetEnvironmentVariable("MESSAGE");
       try
        {
            UserRepository userRepository = new UserRepository();
            userRepository.GetUsers();
            return Ok("Connection to the database was successful!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Connection to the database failed: {ex.Message}");
        }
    }
    }
}
