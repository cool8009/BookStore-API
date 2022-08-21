using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_API.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get ; set; }

        public double Price { get; set; }
        public int AmountInStock { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }

        public Author Author {get; set; }
}
}
