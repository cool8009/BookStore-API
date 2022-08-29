using BookStore_API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Contracts
{
    public interface IAuthorsRepository : IGenericRepository<Author>
    {
        //implementing specific rules
        //we inherit everything from IGenericRepo, but we specify the data type this time
        //therefore creating a specific repo for author with all of the capabilities defined in IGP<T>
        Task<Author> GetDetails(int id);
        Task<List<Author>> SearchAsync(string text);
        
    }
}
