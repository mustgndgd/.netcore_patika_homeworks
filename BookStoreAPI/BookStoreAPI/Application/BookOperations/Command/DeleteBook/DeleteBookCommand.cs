using System;
using System.Linq;
using AutoMapper;
using BookStoreAPI.BookOperations.CreateBook;
using BookStoreAPI.DbOperations;

namespace BookStoreAPI.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
       
        private readonly BookStoreDbContext _context;
        
        public int Id { get; set; }

        public DeleteBookCommand(BookStoreDbContext context)
            {
                _context = context;
             
            }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id ==Id);
            if (book is null)
                throw new InvalidOperationException("Book already exists");
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
        
    }
}
