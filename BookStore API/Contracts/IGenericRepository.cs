namespace BookStore_API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        //contract, enforcing what's happening
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<bool> Exists(int id);

    }
}
