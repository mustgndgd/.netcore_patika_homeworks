using FluentValidation;

namespace BookStoreAPI.Application.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}