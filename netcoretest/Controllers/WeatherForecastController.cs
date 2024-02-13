using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;
using netcoretest.Models;

namespace netcoretest.Controllers
{
    [ApiController]
    [Route("user")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("test")]
        public async Task<IResult> Get()
        {
            return TypedResults.NoContent();
        }

        [HttpGet]
        [EnableRateLimiting("concurrent")]
        public async Task<IResult> Get([FromServices] Postgresql db)
        {
            var result = await db.Users.AsNoTracking().ToListAsync();
            return TypedResults.Ok(result);
        }

        [HttpPost]
        [EnableRateLimiting("concurrent")]
        public async Task<IResult> Post([FromBody] UserDTO userDto, [FromServices] Postgresql db)
        {
            try
            {
                var user = new User
                {
                    Email = userDto.Email,
                    firstName = userDto.firstName,
                    lastName = userDto.lastName,
                };

                await db.Users.AddAsync(user);

                await db.SaveChangesAsync();

                return TypedResults.Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return TypedResults.BadRequest();
            }

        }
    }
}