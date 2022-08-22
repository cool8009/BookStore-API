using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_API.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    { 
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Name = "Animal Farm",
                    Description = "Animal Farm is a beast fable, in form of " +
                    "satirical allegorical novellaby George Orwell",
                    AmountInStock = 10,
                    Price = 50,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/91LUbAcpACL.jpg",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Name = "1984",
                    Description = "Nineteen Eighty-Four is a dystopian social science fiction " +
                    "novel and cautionary tale",
                    AmountInStock = 10,
                    Price = 50,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71kxa1-0mfL.jpg",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 3,
                    Name = "The Hunger Games",
                    Description = "The Hunger Games is a 2008 dystopian novel " +
                    "by the American writer Suzanne Collins",
                    AmountInStock = 10,
                    Price = 50,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61i8nC90deL.jpg",
                    AuthorId = 2
                },
                new Book
                {
                    Id = 4,
                    Name = "Catching Fire",
                    Description = "Catching Fire is a 2009 science fiction young adult novel " +
                    "by the American novelist Suzanne Collins, " +
                    "the second book in The Hunger Games series.",
                    AmountInStock = 10,
                    Price = 50,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a2/Catching_Fire_%28Suzanne_Collins_novel_-_cover_art%29.jpg",
                    AuthorId = 2
                },
                new Book
                {
                    Id = 6,
                    Name = "The Adventures of Tom Sawyer",
                    Description = "The Adventures of Tom Sawyer is an 1876 novel by " +
                    "Mark Twain about a boy growing up along the Mississippi River.",
                    AmountInStock = 10,
                    Price = 50,
                    ImageUrl = "https://mpd-biblio-covers.imgix.net/9781429959278.jpg",
                    AuthorId = 3
                }


            );
        }

        
    }
}
