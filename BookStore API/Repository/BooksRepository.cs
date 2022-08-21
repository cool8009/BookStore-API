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

        public async Task<bool> PurchaseBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null || book.AmountInStock <= 0)
                return false;
 
            book.AmountInStock -= 1;
            await UpdateAsync(book);
            return book != null;
        }
    }
}
