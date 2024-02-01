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
            Database.AutoTransactionBehavior = AutoTransactionBehavior.WhenNeeded;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique(true);
        }
    }
}
