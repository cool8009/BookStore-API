using BookStore_API.Contracts;
using BookStore_API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Repository
{
    public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
    {
        private readonly BookStoreDbContext _context;

        public AuthorsRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Author> GetDetails(int id)
        {
            //go to the db, go to authors table, include the list of books, while you're fetching
            //the first author with a matching id
            return await _context.Authors.Include(q => q.Books)
                .FirstOrDefaultAsync(q => q.Id == id);


        }
    }
}
