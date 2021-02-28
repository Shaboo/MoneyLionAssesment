using Microsoft.EntityFrameworkCore;
using MoneyLionAssesment.Models;

namespace MoneyLionAssesment.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }

        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
    }
}
