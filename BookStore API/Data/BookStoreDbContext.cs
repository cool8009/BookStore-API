using BookStore_API.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Data
{
    public class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        //options object comes from options defined in program.cs
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
            //this.Database.EnsureCreatedAsync();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration()); //we apply the roles defined in ./configurations/RoleConfigurations.cs
            modelBuilder.ApplyConfiguration(new AuthorConfiguration()); 
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            //a hasher to hash the password before seeding the user to the db
            //var hasher = new PasswordHasher<IdentityUser>();


            ////Seeding the User to AspNetUsers table
            //modelBuilder.Entity<IdentityUser>().HasData(
            //    new IdentityUser
            //    {
            //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
            //        UserName = "admin@sela.co.il",
            //        Email = "admin@sela.co.il",
            //        NormalizedUserName = "ADMIN@SELA.CO.IL",
            //        NormalizedEmail = "ADMIN@SELA.CO.IL",
            //        PasswordHash = hasher.HashPassword(null, "admin")
            //    }
            //);


            ////Seeding the relation between our user and role to AspNetUserRoles table
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "5da58ebf-8b39-44ca-855c-6f0df1d4ae8e",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);
        }

    }
}
