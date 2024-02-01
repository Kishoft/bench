using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;
using netcoretest.Models;

namespace netcoretest.Controllers
{
    [ApiController]
    [Route("user")]
    [EnableRateLimiting("fixed")]
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
            var context = db.CreateDbContext();
            var result = await context.Users.AsNoTracking().ToListAsync();
            return TypedResults.Ok(result);
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] UserDTO userDto)
        {
            try
            {
                var user = new User
                {
                    Email = userDto.Email,
                    firstName = userDto.firstName,
                    lastName = userDto.lastName,
                };

            var context = db.CreateDbContext();
                 context.Add(user);

                 context.SaveChanges();
                context.Dispose();
                
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