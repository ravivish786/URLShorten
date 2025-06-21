using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace URLShorten.Controllers
{
    [ApiController]
    [Route("api/shorten")]
    public class UrlShortenController : ControllerBase
    {
        private static readonly Dictionary<string, string> UrlDatabase = new();

        [HttpPost]
        public IActionResult ShortenUrl([FromBody] string longUrl)
        {
            if (string.IsNullOrWhiteSpace(longUrl))
            {
                return BadRequest("URL cannot be empty.");
            }
            var shortUrl = GenerateShortUrl();
            UrlDatabase[shortUrl] = longUrl;
            return Ok(new { ShortUrl = shortUrl });
        }
        [HttpGet("{shortUrl}")]
        public IActionResult GetLongUrl(string shortUrl)
        {
            if (UrlDatabase.TryGetValue(shortUrl, out var longUrl))
            {
                return Ok(new { LongUrl = longUrl });
            }
            return NotFound("Short URL not found.");
        }
        






        #region Util 

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
