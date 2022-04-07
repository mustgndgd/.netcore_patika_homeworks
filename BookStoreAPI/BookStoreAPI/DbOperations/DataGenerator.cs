using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreAPI.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider ServiceProvider)
        {
            using (var context = new BookStoreDbContext(ServiceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange
                (
                    new Book
                    {
                        Title = "The Lord of the Rings 1",
                        GenreId = 1,
                        PageCount = 300,
                        PublishDate = new DateTime(1995, 11, 4),
                    },
                    new Book
                    {
                        Title = "The Lord of the Rings 2",
                        GenreId = 2,
                        PageCount = 934,
                        PublishDate = new DateTime(1997, 12, 11),
                    },

                    new Book
                    {
                        Title = "The Lord of the Rings 3",
                        GenreId = 2,
                        PageCount = 456,
                        PublishDate = new DateTime(1999, 1, 5),
                    }
                );
                context.SaveChanges();
                
            }
        }
    }
}
