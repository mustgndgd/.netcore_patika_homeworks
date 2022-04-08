using System;
using System.Linq;
using AutoMapper;
using BookStoreAPI.BookOperations.CreateBook;
using BookStoreAPI.BookOperations.DeleteBook;
using BookStoreAPI.BookOperations.GetBookById;
using BookStoreAPI.BookOperations.GetBooks;
using BookStoreAPI.BookOperations.UpdateBook;
using BookStoreAPI.DbOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
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
            GetBookByIdQuery query = new GetBookByIdQuery(_context, _mapper);
            query._bookId = id;
            GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel book)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = book;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command); //fluent validation using part
            command.Handle();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatebook)
        {

            UpdateBookCommand command = new UpdateBookCommand(_context);
            command._bookId = id;
            command.Model = updatebook;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.Id = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
