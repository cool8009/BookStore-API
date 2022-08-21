using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_API.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    { 
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
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
        }

        
    }
}
