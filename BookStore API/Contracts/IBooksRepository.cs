using BookStore_API.Data;

namespace BookStore_API.Contracts
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        public Task<bool> PurchaseBookAsync(int id);
    }
}
