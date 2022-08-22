using System.ComponentModel.DataAnnotations;

namespace BookStore_API.Models.Book
{
    public abstract class BaseBookDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int AmountInStock { get; set; }
        public string ImageUrl{ get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }
    }
}
