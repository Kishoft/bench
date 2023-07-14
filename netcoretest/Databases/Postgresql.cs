using Microsoft.EntityFrameworkCore;
using netcoretest.Models;

namespace netcoretest.Databases
{
    public class Postgresql : DbContext
    {
        public Postgresql(DbContextOptions<Postgresql> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(k => k.Id);
        }
    }
}
