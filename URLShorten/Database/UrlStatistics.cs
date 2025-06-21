namespace URLShorten.Database
{
    public class UrlStatistics
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; }

        public int Hits { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
