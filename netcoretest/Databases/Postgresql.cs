using Microsoft.EntityFrameworkCore;
using netcoretest.Models;

namespace netcoretest.Databases
{
    public class Postgresql : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public Postgresql(DbContextOptions<Postgresql> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique(true);
        }
        private static readonly Func<Postgresql, IAsyncEnumerable<User>> _queryGetAllUsersAsync =
        EF.CompileAsyncQuery((Postgresql db) => db.Users);


        private static readonly Func<Postgresql, User, IAsyncResult> _queryAddUserAsync =
        EF.CompileAsyncQuery((Postgresql db, User user) => db.Users.Add(user));

        public IAsyncEnumerable<User> GetAll() => _queryGetAllUsersAsync(this);
        public IAsyncResult Add(User user) => _queryAddUserAsync(this, user);


    }
}
