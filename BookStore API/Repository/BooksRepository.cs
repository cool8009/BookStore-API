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
    }
}
