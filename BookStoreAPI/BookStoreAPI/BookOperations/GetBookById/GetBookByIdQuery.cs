using System;
using System.Linq;
using BookStoreAPI.Common;
using BookStoreAPI.DbOperations;

namespace BookStoreAPI.BookOperations.GetBookById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;

        public GetBookByIdQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public BookViewModel Handle(int id)
        {
            var book = _context.Books.First(x => x.Id == id);
            if (book == null)
            {
                throw new ArgumentNullException("Kitap bulunamadı");
            }

            return new BookViewModel
            {
                Title = book.Title,
                PageCount = book.PageCount,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishedDate = book.PublishDate.Date.ToString("yyyy-MM-dd"),
            };
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }
        public string PublishedDate { get; set; }
    }

}
