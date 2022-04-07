using System;
using System.Linq;
using AutoMapper;
using BookStoreAPI.DbOperations;
using FluentValidation.Results;

namespace BookStoreAPI.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookModel Model { get; set; }

        public CreateBookCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Book already exists");

            book = _mapper.Map<Book>(Model);
            
            //book = new Book
            //{
            //    Title = Model.Title,
            //    GenreId = Model.GenreId,
            //    PageCount = Model.PageCount,
            //    PublishDate = Model.PublishDate,
            //};
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
    
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
