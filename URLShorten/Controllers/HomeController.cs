using Microsoft.AspNetCore.Mvc;

namespace URLShorten.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content("✅ URL Shortener API is running.\nUse /api/url to shorten URLs.");
        }
    }
}
