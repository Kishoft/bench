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
        private readonly IDbContextFactory<Postgresql> db;
        public WeatherForecastController(IDbContextFactory<Postgresql> db)
        {
            this.db = db;
        }

        [HttpGet("/test")]
        public async Task<IResult> Get(int id)
        {
            return TypedResults.NoContent();
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            using (var db = this.db.CreateDbContext())
            {
                var result = await db.Users.AsNoTracking().ToListAsync();
                return TypedResults.Ok(result);
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] UserDTO userDto)
        {
            using (var db = this.db.CreateDbContext())
            {

                var user = new User
                {
                    Email = userDto.Email,
                    firstName = userDto.firstName,
                    lastName = userDto.lastName,
                };

                await db.AddAsync(user);

                if (await db.SaveChangesAsync() > 0)
                {
                    return TypedResults.Ok();
                }
                else return TypedResults.BadRequest();
            }
        }

    }
}