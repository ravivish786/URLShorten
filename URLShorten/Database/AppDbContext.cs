using Microsoft.EntityFrameworkCore;

namespace URLShorten.Database
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<UrlStatistics> UrlStatistics { get; set; }

    }
}
