using AutoMapper;
using BookStore_API.Data;
using BookStore_API.Models.Author;
using BookStore_API.Models.Book;
using BookStore_API.Models.Users;

namespace BookStore_API.Configurations
{
    public class MapperConfig : Profile
    {
        //helps create maps between data types, helps eliminate convertions from dto to model
        public MapperConfig()
        {
            //reversemap helps us map both ways
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, GetAuthorDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
        }

    }
}
