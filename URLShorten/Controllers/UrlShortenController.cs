﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShorten.Dto;
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
        [Route("health")]
        public IActionResult HealthCheck()
        {
            return Ok("Service is running");
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _urlManager.GetAllAsync(cancellationToken);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> GetAsync(string shortUrl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Short URL cannot be empty.");
            }
            var result = await _urlManager.GetAsync(shortUrl, cancellationToken);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet]
        [Route("{shortUrl}/stats")]
        public async Task<IActionResult> GetStatisticsAsync(string shortUrl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Short URL cannot be empty.");
            }
            var result = await _urlManager.GetStatisticsAsync(shortUrl, cancellationToken);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ShortUrlRequest request, CancellationToken cancellationToken = default)
        {
            var result = IsValidUrl(request.Url);
            if (!result.IsValid)
            {
                return BadRequest(result.Message);
            }
            var created  = await _urlManager.CreateAsync(request.Url, cancellationToken);
            if (!created.Success)
            {
                return BadRequest(created.Message);
            }
            //return CreatedAtAction(nameof(GetAsync), new { shortUrl = created.Data.ShortCode }, created.Data);

            // Generate the short URL using the request scheme and host

            var shortUrl = $"{Request.Scheme}://{Request.Host}/api/UrlShorten/{created.Data.ShortCode}";

            Response.Headers.Location = shortUrl;

            return StatusCode(StatusCodes.Status201Created, created.Data);
        }

        [HttpPut]
        [Route("{shortUrl}")]
        public async Task<IActionResult> UpdateAsync(string shortUrl, [FromBody] ShortUrlRequest request, CancellationToken cancellationToken = default)
        {
            var result = IsValidUrl(request.Url);
            if (!result.IsValid)
            {
                return BadRequest(result.Message);
            }
            var updated = await _urlManager.UpdateAsync(shortUrl, request.Url, cancellationToken);
            if (!updated.Success)
            {
                return NotFound(updated.Message);
            }
            return Ok(updated.Data);
        }


        [HttpDelete]
        [Route("{shortUrl}")]
        public async Task<IActionResult> DeleteAsync(string shortUrl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return BadRequest("Short URL cannot be empty.");
            }
            var deleted = await _urlManager.DeleteAsync(shortUrl, cancellationToken);
            if (!deleted.Success)
            {
                return NotFound(deleted.Message);
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
