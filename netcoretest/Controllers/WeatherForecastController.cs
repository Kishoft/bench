using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;
using netcoretest.Models;

namespace netcoretest.Controllers
{
    [ApiController]
    [Route("user")]
    public class WeatherForecastController : ControllerBase
    {

        WeatherForecastScopedFactory factory;

        public WeatherForecastController(WeatherForecastScopedFactory factory)
        {
            this.factory = factory;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            using var db = factory.CreateDbContext();
            {
                var result = await db.Users.ToListAsync();
                await db.DisposeAsync();
                return TypedResults.Ok(result);
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] UserDTO userDto)
        {
            using var db = factory.CreateDbContext();
            {
                var user = new User
                {
                    Email = userDto.Email,
                    firstName = userDto.firstName,
                    lastName = userDto.lastName,
                };


                await db.Users.AddAsync(user);
                var result = await db.SaveChangesAsync() > 0;
                await db.DisposeAsync();
                if (result)
                {
                    return TypedResults.Ok();
                }
                else return TypedResults.BadRequest();
            }
        }

    }
}