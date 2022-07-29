using BookAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAppBackend.Data
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public BooksContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Ratings)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Book>(b =>
            {
                b.HasMany(b => b.Ratings)
                .WithOne(r => r.Book);

                b.HasMany(b => b.Reviews)
                .WithOne(r => r.Book);
            });

            modelBuilder.Seed();
        }
    }
}
