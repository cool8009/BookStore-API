using BookStore_API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Data
{
    public class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        //options object comes from options defined in program.cs
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration()); //we apply the roles defined in ./configurations/RoleConfigurations.cs
            modelBuilder.ApplyConfiguration(new AuthorConfiguration()); 
            modelBuilder.ApplyConfiguration(new BookConfiguration()); 
        }

    }
}
