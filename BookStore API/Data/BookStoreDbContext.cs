using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Data
{
    public class BookStoreDbContext : DbContext
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
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "George Orwell",
                    HomeLatitude = 26.64300f,
                    HomeLongitude = 84.91426f
                },
                new Author
                {
                    Id = 2,
                    Name = "Suzanne Collins",
                    HomeLatitude = 41.76758f,
                    HomeLongitude = -72.70144f
                },
                new Author
                {
                    Id = 3,
                    Name = "Mark Twain",
                    HomeLatitude = 41.76758f,
                    HomeLongitude = -72.70144f
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Animal Farm",
                    Description = "Animal Farm is a beast fable, in form of " +
                    "satirical allegorical novellaby George Orwell",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Name = "1984",
                    Description = "Nineteen Eighty-Four is a dystopian social science fiction " +
                    "novel and cautionary tale",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 3,
                    Name = "The Hunger Games",
                    Description = "The Hunger Games is a 2008 dystopian novel " +
                    "by the American writer Suzanne Collins",
                    AuthorId = 2
                },
                new Book
                {
                    Id = 4,
                    Name = "Catching Fire",
                    Description = "Catching Fire is a 2009 science fiction young adult novel " +
                    "by the American novelist Suzanne Collins, " +
                    "the second book in The Hunger Games series.",
                    AuthorId = 2
                },
                new Book
                {
                    Id = 6,
                    Name = "The Adventures of Tom Sawyer",
                    Description = "The Adventures of Tom Sawyer is an 1876 novel by " +
                    "Mark Twain about a boy growing up along the Mississippi River.",
                    AuthorId = 3
                }
                

            );

        }

    }
}
