using BookStoreAPI.Application.GenreOperations.DeleteGenre;
using FluentValidation;

namespace BookStoreAPI.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}