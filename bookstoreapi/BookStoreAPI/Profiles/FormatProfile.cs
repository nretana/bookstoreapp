using AutoMapper;
using BookStore.API.Entities;
using BookStore.API.Models.Books;

namespace BookStore.API.Profiles
{
    public class FormatProfile : Profile
    {
        public FormatProfile()
        {
            CreateMap<Format, FormatDto>();
        }
    }
}
