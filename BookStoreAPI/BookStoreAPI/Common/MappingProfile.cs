using BookStoreAPI.BookOperations.CreateBook;
using BookStoreAPI.BookOperations.GetBooks;
using AutoMapper;
using BookStoreAPI.BookOperations.GetBookById;

namespace BookStoreAPI.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
