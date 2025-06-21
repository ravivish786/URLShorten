using URLShorten.Dto;

namespace URLShorten.Interface
{
    public interface IUrlManager
    {
        Task<Result<ShortUrlDto>> CreateAsync(string longUrl);
        Task<Result<ShortUrlDto>> UpdateAsync(string shortUrl, string longUrl);
        Task<Result<bool>> DeleteAsync(string shortUrl);
        Task<Result<ShortUrlDto>> GetAsync(string shortUrl);
        Task<Result<ShortUrlStatisticsDto>> GetStatisticsAsync(string shortUrl);
    }
}
