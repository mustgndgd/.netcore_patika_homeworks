using System;
using System.Linq;
using AutoMapper;
using BookStoreAPI.Common;
using BookStoreAPI.DbOperations;

namespace BookStoreAPI.BookOperations.GetBookById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int _bookId { get; set; }
        public GetBookByIdQuery(BookStoreDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public BookDetailViewModel Handle()
        {
            var book = _context.Books.First(x => x.Id == _bookId);
            if (book == null)
            {
                throw new ArgumentNullException("Kitap bulunamadı");
            }
            return _mapper.Map<BookDetailViewModel>(book);
            
            //return new BookDetailViewModel
            //{
            //    Title = book.Title,
            //    PageCount = book.PageCount,
            //    Genre = ((GenreEnum)book.GenreId).ToString(),
            //    PublishedDate = book.PublishDate.Date.ToString("yyyy-MM-dd"),
            //};
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }
        public string PublishedDate { get; set; }
    }

}
