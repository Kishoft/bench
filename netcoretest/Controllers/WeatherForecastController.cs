using Microsoft.AspNetCore.Mvc;
using netcoretest.Models;
using netcoretest.Services;

namespace netcoretest.Controllers
{
    [ApiController]
    [Route("user")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly UserService _userService;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            return TypedResults.Ok(await _userService.all());
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] UserDTO user)
        {
            await _userService.create(user);
            return TypedResults.Ok();
        }

    }
}