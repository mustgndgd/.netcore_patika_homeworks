using BookStoreAPI.BookOperations.CreateBook;
using BookStoreAPI.BookOperations.GetBooks;
using AutoMapper;
using BookStoreAPI.Application.GenreOperations.GetGenres;
using BookStoreAPI.BookOperations.GetBookById;
using BookStoreAPI.Entities;
using BookStoreAPI.Application.GenreOperations.GetGenreDetail;
using BookStoreAPI.Application.UserOperations.Commands.Create;

namespace BookStoreAPI.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateUserModel, User>();            
        }
    }
}
