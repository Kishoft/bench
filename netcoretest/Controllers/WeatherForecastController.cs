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
        private readonly Postgresql db;


        public WeatherForecastController(Postgresql db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            var result = await db.Users.AsNoTracking().ToListAsync();
            return TypedResults.Ok(result);
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] UserDTO userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                firstName = userDto.firstName,
                lastName = userDto.lastName,
            };
            await db.Users.AddAsync(user);
            if (await db.SaveChangesAsync() > 0)
            {
                return TypedResults.Ok();
            }
            else return TypedResults.BadRequest();
        }

    }
}