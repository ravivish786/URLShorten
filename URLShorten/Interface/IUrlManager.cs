using URLShorten.Dto;

namespace URLShorten.Interface
{
    public interface IUrlManager
    {
        Task<Result<List<ShortUrlDto>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<ShortUrlDto>> CreateAsync(string longUrl, CancellationToken cancellationToken);
        Task<Result<ShortUrlDto>> UpdateAsync(string shortUrl, string longUrl, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteAsync(string shortUrl, CancellationToken cancellationToken);
        Task<Result<ShortUrlDto>> GetAsync(string shortUrl, CancellationToken cancellationToken);
        Task<Result<ShortUrlStatisticsDto>> GetStatisticsAsync(string shortUrl, CancellationToken cancellationToken);
    }
}
