using BookStore_API.Contracts;
using BookStore_API.Data;

namespace BookStore_API.Repository
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private readonly BookStoreDbContext _context;

        public BooksRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Book> PurchaseBookAsync(Book book)
        { 
            if (book == null || book.AmountInStock <= 0)
                return null;
 
            book.AmountInStock -= 1;
            var newBook = await UpdateAsync(book);
            return newBook;
        }
    }
}
