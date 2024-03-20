using AutoMapper;
using MallorcaTeslas.Application.Dtos.Users;
using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Models;

namespace MallorcaTeslas.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<RegisterUserRequest, User>()
            .ForMember(dest => dest.Password,
                       opt => opt.Ignore());
        CreateMap<PagedItems<User>, PagedItems<UserDto>>();
    }
}