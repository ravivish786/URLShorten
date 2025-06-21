namespace URLShorten.Dto
{
    public class ShortUrlStatisticsDto
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? ShortCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int AccessCount { get; set; }

        public List<GraphDataDto> GraphData { get; set; } = new List<GraphDataDto>();
    }


    public class GraphDataDto
    {
        public string Date { get; set; } = string.Empty;
        public int Hits { get; set; }
    }

}
