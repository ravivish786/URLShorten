using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShorten.Interface;

namespace URLShorten.Controllers
{
    [ApiController]
    [Route("api/shorten")]
    public class UrlShortenController : ControllerBase
    {
        private readonly IUrlManager _urlManager;

        public UrlShortenController(IUrlManager urlManager)
        {
            _urlManager = urlManager;
        }

        [HttpGet]
        [Route("{shortUrl}")]
        public async Task<IActionResult> GetAsync(string shortUrl)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Short URL cannot be empty.");
            }
            var result = await _urlManager.GetAsync(shortUrl);
            if (result == null)
            {
                return NotFound("Short URL not found.");
            }
            //return Ok(result);
            return Redirect(result.Url);
        }

        [HttpGet]
        [Route("{shortUrl}/stats")]
        public async Task<IActionResult> GetStatisticsAsync(string shortUrl)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Short URL cannot be empty.");
            }
            var stats = await _urlManager.GetStatisticsAsync(shortUrl);
            if (stats == null)
            {
                return NotFound("Short URL not found.");
            }
            return Ok(stats);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] string Url)
        {
            var result = IsValidUrl(Url);
            if (!result.IsValid)
            {
                return BadRequest(result.Message);
            }
            var created  = await _urlManager.CreateAsync(Url);
            if (created == null)
            {
                return BadRequest("Failed to create short URL.");
            }
            return CreatedAtAction(nameof(GetAsync), new { shortUrl = created.ShortCode }, result);
        }

        [HttpPut]
        [Route("{shortUrl}")]
        public async Task<IActionResult> UpdateAsync(string shortUrl, [FromBody] string Url)
        {
            var result = IsValidUrl(Url);
            if (!result.IsValid)
            {
                return BadRequest(result.Message);
            }
            var updated = await _urlManager.UpdateAsync(shortUrl, Url);
            if (updated == null)
            {
                return NotFound("Short URL not found.");
            }
            return Ok(updated);
        }


        [HttpDelete]
        [Route("{shortUrl}")]
        public async Task<IActionResult> DeleteAsync(string shortUrl)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Short URL cannot be empty.");
            }
            var deleted = await _urlManager.DeleteAsync(shortUrl);
            if (!deleted)
            {
                return NotFound("Short URL not found.");
            }
            return NoContent();
        }







        #region Util Methods

        // check is short url is valid
        private ValidationResponse IsValidUrl(string Url)
        {
 
            if (string.IsNullOrWhiteSpace(Url))
            {
                return new ValidationResponse
                {
                    IsValid = false,
                    Message = "URL cannot be empty."
                };
            }
            // Check if the URL starts with http:// or https://
            if (!Url.StartsWith("http://") && !Url.StartsWith("https://"))
            {
                return new ValidationResponse
                {
                    IsValid = false,
                    Message = "URL must start with http:// or https://"
                };
            }
            // Check if the URL contains a valid domain
            try
            {
                var uri = new Uri(Url);
                var status =  uri.HostNameType != UriHostNameType.Unknown;

                return new ValidationResponse
                {
                    IsValid = status,
                    Message = status ? "Valid URL" : "Invalid URL"
                };
            }
            catch
            {
                return new ValidationResponse
                {
                    IsValid = false,
                    Message = "Invalid URL format."
                };
            }
        }

        #endregion  



        class ValidationResponse
        {
            public bool IsValid { get; set; }
            public string Message { get; set; }
        }
    }

}
