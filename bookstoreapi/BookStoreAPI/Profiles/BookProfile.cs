using AutoMapper;
using BookStore.API.Entities;
using BookStore.API.Models.Books;

namespace BookStore.API.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() {
            CreateMap<Book, BookDto>();

        }
    }
}
