using AutoMapper;
using BookStore.API.Entities.Account;
using BookStore.API.Models.Account.Request;
using BookStore.API.Models.Account.Response;

namespace BookStore.API.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile() {

            CreateMap<User, UserAccountResponseDto>();

            CreateMap<SignUpRequestDto, User>()
                                    .ForMember(dest => dest.UserName, 
                                       src => src.MapFrom(p => p.Email));
            
        }
    }
}
