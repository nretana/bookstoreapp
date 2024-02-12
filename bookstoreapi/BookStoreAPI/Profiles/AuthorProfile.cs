using AutoMapper;
using BookStore.API.Entities;
using BookStore.API.Models.Books;

namespace BookStore.API.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() { 
            CreateMap<Author, AuthorDto>();
        }
    }
}
