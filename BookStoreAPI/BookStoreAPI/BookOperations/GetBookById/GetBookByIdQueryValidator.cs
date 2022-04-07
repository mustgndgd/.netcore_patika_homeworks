using System;
using BookStoreAPI.BookOperations.CreateBook;
using FluentValidation;

namespace BookStoreAPI.BookOperations.GetBookById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {

        public GetBookByIdQueryValidator()
        {
            RuleFor(x => x._bookId).NotEmpty().GreaterThan(0);
        }
    }
}
