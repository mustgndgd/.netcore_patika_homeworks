using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStoreAPI.Common;
using BookStoreAPI.DbOperations;

namespace BookStoreAPI.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> booksViewModelList = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                booksViewModelList.Add(_mapper.Map<BooksViewModel>(book));
                
                //booksViewModelList.Add(new BooksViewModel
                //{
                //    Title = book.Title,
                //    PageCount = book.PageCount,
                //    Genre = ((GenreEnum)book.GenreId).ToString(),
                //    PublishedDate = book.PublishDate.Date.ToString("yyyy-MM-dd"),

                //});
            }
            return booksViewModelList;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }
        public string PublishedDate { get; set; }
    }
}
