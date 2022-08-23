using BookStore_API.Data;

namespace BookStore_API.Contracts
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        public Task<Book> PurchaseBookAsync(Book book);
    }
}
