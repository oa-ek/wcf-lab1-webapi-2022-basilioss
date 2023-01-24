using AutoMapper;
using Books.Core.Entities;
using Books.Repositories.Dto.Authors;
using Books.Repositories.Dto.Books;
using Books.Repositories.Dto.Genres;
using Books.Repositories.Dto.Publihers;
using Books.Repository.Dto.UserDto;

namespace Books.API
{
    public class AppAutoMapper : Profile
    {
        public AppAutoMapper()
        {
            CreateMap<BooksReadDto, Book>();
            CreateMap<Book, BooksReadDto>();
            CreateMap<BooksCreateUpdateDto, Book>();
            CreateMap<Book, BooksCreateUpdateDto>();

            CreateMap<GenresReadDto, Genre>();
            CreateMap<Genre, GenresReadDto>();
            CreateMap<GenresCreateUpdateDto, Genre>();
            CreateMap<Genre, GenresCreateUpdateDto>();

            CreateMap<AuthorReadDto, Author>();
            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorCreateUpdateDto, Author>();
            CreateMap<Author, AuthorCreateUpdateDto>();

            CreateMap<UserReadDto, User>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();

            CreateMap<Publisher, PublishersReadDto>();
            CreateMap<PublishersReadDto, Publisher>();
            CreateMap<Publisher, PublishersCreateUpdateDto>();
            CreateMap<PublishersCreateUpdateDto, Publisher>();
        }
    }
}
