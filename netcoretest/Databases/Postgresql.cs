using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using netcoretest.Models;

namespace netcoretest.Databases
{
    public class Postgresql : DbContext
    {
        private readonly IMemoryCache _cache;
        public DbSet<User> Users { get; set; } = null!;

        public Postgresql(DbContextOptions<Postgresql> optionsBuilder, IMemoryCache cache) : base(optionsBuilder)
        {
            _cache = cache;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMemoryCache(_cache);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique(true);
        }
    }
}
