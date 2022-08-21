using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_API.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        //this class helps us configure roles outside of onModelCreating in our dbContext class,
        //which makes it cleaner and more readable. The interface allows it.
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            //this is where configure basic built roles on startup
            //we setup configurations for the table associated with the IdentityRole datatype
            //basically seeding the identity part of the db
            builder.HasData(
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
