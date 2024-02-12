using AutoMapper;
using BookStore.API.Entities;
using BookStore.API.Models.Books;

namespace BookStore.API.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile() {
            CreateMap<Genre, GenreDto>();
        }
    }
}
