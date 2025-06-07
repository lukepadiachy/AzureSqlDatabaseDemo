using AzureSqlDatabaseDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureSqlDatabaseDemo.Data
{
    public class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
    }
}
