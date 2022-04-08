using BookStoreAPI.Entities;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.DbOperations
{
    public class BookStoreDbContext:DbContext,IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
