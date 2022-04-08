using System;
using System.Linq;
using BookStoreAPI.DbOperations;

namespace BookStoreAPI.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
    
        private readonly BookStoreDbContext _context;
        public int _bookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id ==_bookId);
            if (book is not null)
            {
                book.Title = Model.Title;
                book.GenreId = Model.GenreId;
                book.PageCount = Model.PageCount;
                book.PublishDate = Model.PublishDate;
                _context.Update(book);
                _context.SaveChanges();
            }
            
            throw new InvalidOperationException("Book is not found");
        }
    }

    public class UpdateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
