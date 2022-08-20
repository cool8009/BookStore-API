using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Models.Author
{
    public abstract class BaseAuthorDto
    {
        [Required]
        public string Name { get; set; }

        public float HomeLatitude { get; set; }
        public float HomeLongitude { get; set; }
    }
}
