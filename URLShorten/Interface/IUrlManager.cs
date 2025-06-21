using URLShorten.Dto;

namespace URLShorten.Interface
{
    public interface IUrlManager
    {
        Task<ShortUrlDto> CreateAsync(string longUrl);
        Task<ShortUrlDto> UpdateAsync(string shortUrl, string longUrl);
        Task<bool> DeleteAsync(string shortUrl);
        Task<ShortUrlDto?> GetAsync(string shortUrl);
        Task<ShortUrlStatisticsDto?> GetStatisticsAsync(string shortUrl);
    }
}
