using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>() // Defining the relationship for book author table
                .HasOne(b => b.Book)    // one book
                .WithMany(ba => ba.Book_Authors) // with many authors
                .HasForeignKey(bi => bi.BookId); // define the FK

            modelBuilder.Entity<Book_Author>() // Defining the relationship for book author table
                .HasOne(b => b.Author)    // one Author
                .WithMany(ba => ba.Book_Authors) // with many books
                .HasForeignKey(bi => bi.AuthorId); // define the FK
        }
        public DbSet<Book> Books { get; set;} // Create one for each model you have
        public DbSet<Author> Authors { get; set;}
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
