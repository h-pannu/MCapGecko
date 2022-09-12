using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MCapGecko.Server.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=CMapGecko;trusted_connection=true;");
        }

        public DataContext()
        {
        }

        public DbSet<Coin> Coins { get; set; }
    }
}
