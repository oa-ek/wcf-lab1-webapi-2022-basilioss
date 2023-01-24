using Books.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public static class BooksDbContextExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string MODER_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = MODER_ROLE_ID,
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER"
                });

            string ADMIN_ID = Guid.NewGuid().ToString();
            string MODER_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper()
            };

            var moder = new User
            {
                Id = MODER_ID,
                UserName = "moder@gmail.com",
                Email = "moder@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "moder@gmail.com".ToUpper(),
                NormalizedUserName = "moder@gmail.com".ToUpper()
            };

            var user = new User
            {
                Id = USER_ID,
                UserName = "user@gmail.com",
                Email = "user@gmails.com",
                EmailConfirmed = true,
                NormalizedEmail = "user@gmail.com".ToUpper(),
                NormalizedUserName = "user@gmail.com".ToUpper()
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin$pass1");
            moder.PasswordHash = hasher.HashPassword(moder, "moder$pass1");
            user.PasswordHash = hasher.HashPassword(user, "user$pass1");

            builder.Entity<User>().HasData(admin, moder, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODER_ROLE_ID,
                    UserId = MODER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });

            builder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = " J.K. Rowling"
                },
                new Author
                {
                    Id = 2,
                    Name = "J.R.R. Tolkien"
                });
            builder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Scholastic Inc"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Houghton Mifflin Harcourt"
                });
            builder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    GenreName = "Fantasy"
                },
                new Genre
                {
                    Id = 2,
                    GenreName = "Fiction"
                },
                new Genre
                {
                    Id = 3,
                    GenreName = "Adventure"
                },
                new Genre
                {
                    Id = 4,
                    GenreName = "Classics"
                },
                new Genre
                {
                    Id = 5,
                    GenreName = "Novels"
                },
                new Genre
                {
                    Id = 6,
                    GenreName = "Young Adult"
                });
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Description = "Harry Potter has no idea how famous he is. That's because he's being raised by his miserable aunt and uncle who are terrified Harry will learn that he's really a wizard, just as his parents were. But everything changes when Harry is summoned to attend an infamous school for wizards, and he begins to discover some clues about his illustrious birthright. From the surprising ...",
                    PageCount = 309,
                    PublishDate = new DateTime(2003, 9, 1),
                    IconPath = @"Images\1.jpg"
                },
                new Book
                {
                    Id = 2, 
                    Title = "The Lord of the Rings",
                    Description = "Sumptuous slipcased edition of Tolkien’s classic epic tale of adventure, fully illustrated in colour for the first time by the author himself. Limited to a worldwide first printing of just 5,000 copies, this deluxe volume is quarterbound in leather and includes many special features unique to this edition. Since it was first published in 1954, The Lord of the Rings has bee ...",
                    PageCount = 1216,
                    PublishDate = new DateTime(2005, 8, 12),
                    IconPath = @"Images\33.jpg"
                });
        }
    }
}
