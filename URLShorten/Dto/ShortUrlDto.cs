namespace URLShorten.Dto
{
    public class ShortUrlDto
    {
        public int Id { get; set; }
        public string? Url { get; set; } = null;
        public string? ShortCode { get; set; } = null;
        public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
