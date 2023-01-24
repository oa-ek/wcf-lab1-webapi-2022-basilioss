using Books.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Books.Core
{
    public class BooksDbContext : IdentityDbContext<User>
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books);
            builder.Entity<Book>()
                .HasMany(x => x.Genres)
                .WithMany(x => x.Books);
            builder.Entity<User>()
                .HasMany(x => x.Books)
                .WithMany(x => x.Users);
            builder.Seed();
            base.OnModelCreating(builder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}