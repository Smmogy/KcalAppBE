using Microsoft.EntityFrameworkCore;
using EntityFramework.Exceptions.PostgreSQL;
namespace KcalAppBE.Models
{
    public class MainDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Consumables> Consumables { get; set; }

        public MainDbContext() { }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(b => b.AddFilter((category, level) => level > LogLevel.Information)));
            optionsBuilder.UseExceptionProcessor();
            optionsBuilder.UseNpgsql();
        }

        public void UpdateDatabase()
        {
            Console.WriteLine("Updating database!");
            Database.Migrate();
        }
    }
}
