using System.ComponentModel.DataAnnotations;

namespace URLShorten.Dto
{
    public class ShortUrlRequest
    {
        [Required]
        public string Url { get; set; } = null!;
    }

}
