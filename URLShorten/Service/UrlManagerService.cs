using URLShorten.Dto;
using URLShorten.Interface;

namespace URLShorten.Service
{
    public class UrlManagerService : IUrlManager
    {
        private static readonly Dictionary<string, ShortUrlDto> UrlDatabase = new();
        public  Task<ShortUrlDto> CreateAsync(string longUrl)
        {
            
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




        #region Utility Methods

        private string GenerateShortUrl()
        {
            long tickes = DateTime.UtcNow.Ticks;
            string base64 = Convert.ToBase64String(BitConverter.GetBytes(tickes));
            base64 = base64.Replace("/", "_").Replace("+", "-").TrimEnd('=');
            return base64;
        }

        #endregion
    }
}
