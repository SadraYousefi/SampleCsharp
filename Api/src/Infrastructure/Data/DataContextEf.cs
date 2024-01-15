using Microsoft.EntityFrameworkCore;
using Api.core.Entities;
namespace Api.Infrastructure.Data
{

    public class DataContextEf : DbContext
    {
        private readonly IConfiguration _config;

        public DataContextEf(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnectionString"));
            }
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(b => b.UserId)
                .IsRequired();
        }
    }
}