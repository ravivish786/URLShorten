using Microsoft.EntityFrameworkCore;

namespace URLShorten.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ShortUrl> ShortUrls { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
