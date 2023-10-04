using Microsoft.EntityFrameworkCore;
using PalmaTimberMob.Models;

namespace PalmaTimberMob.Brokers
{
    public class SqliteBroker : DbContext
    {
        public SqliteBroker(DbContextOptions<SqliteBroker> opts) : 
            base(opts)
        {
            
        }

        public DbSet<Docket> Dockets { get; set; }
        public DbSet<User> LoggedInUser { get; set; }
        public DbSet<Felling> Fellings { get; set; }
    }
}
