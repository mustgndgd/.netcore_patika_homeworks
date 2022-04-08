using System;
using FluentValidation;

namespace BookStoreAPI.BookOperations.DeleteBook
{
  
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0).NotEmpty();
        }
    }
}
