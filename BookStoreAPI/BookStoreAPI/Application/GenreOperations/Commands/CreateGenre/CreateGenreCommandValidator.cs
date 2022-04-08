using System;
using BookStoreAPI.Application.GenreOperations.CreateGenre;
using FluentValidation;

namespace BookStoreAPI.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}