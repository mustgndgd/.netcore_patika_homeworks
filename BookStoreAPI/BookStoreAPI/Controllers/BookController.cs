using System;
using System.Linq;
using AutoMapper;
using BookStoreAPI.BookOperations.CreateBook;
using BookStoreAPI.BookOperations.GetBookById;
using BookStoreAPI.BookOperations.GetBooks;
using BookStoreAPI.BookOperations.UpdateBook;
using BookStoreAPI.DbOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
                query._bookId = id;
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
       
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel book)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context,_mapper);
                command.Model = book;
                command.Handle();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
       
       
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatebook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command._bookId = id;
                command.Model = updatebook;
                command.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
      
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return BadRequest();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
