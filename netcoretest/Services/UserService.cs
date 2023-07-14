using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;
using netcoretest.Models;

namespace netcoretest.Services
{
    public class UserService
    {
        private readonly Postgresql db;
        public UserService(Postgresql db) {  this.db = db; }
        public async Task<bool> create(UserDTO userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                firstName = userDto.firstName, 
                lastName = userDto.lastName,
            };
            await db.Users.AddAsync(user);
            return await db.SaveChangesAsync() > 0 ;

        }
        public async Task<List<User>> all()
        {
            return await db.Users.AsQueryable().ToListAsync();
        }
    }
}
