using BookStore_API.Models.Book;

namespace BookStore_API.Models.Author
{
    public class AuthorDto : BaseAuthorDto
    {
        public int Id { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
