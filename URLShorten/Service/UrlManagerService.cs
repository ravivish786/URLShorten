using URLShorten.Dto;
using URLShorten.Interface;

namespace URLShorten.Service
{
    public class UrlManagerService : IUrlManager
    {
        public Task<ShortUrlDto> CreateAsync(string longUrl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string shortUrl)
        {
            throw new NotImplementedException();
        }

        public Task<ShortUrlDto?> GetAsync(string shortUrl)
        {
            throw new NotImplementedException();
        }

        public Task<ShortUrlStatisticsDto?> GetStatisticsAsync(string shortUrl)
        {
            throw new NotImplementedException();
        }

        public Task<ShortUrlDto> UpdateAsync(string shortUrl, string longUrl)
        {
            throw new NotImplementedException();
        }
    }
}
