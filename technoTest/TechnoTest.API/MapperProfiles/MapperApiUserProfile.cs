using AutoMapper;
using technoTest.API.Models.User.Request;
using technoTest.API.Models.User.Response;
using TechnoTest.BLL.Models;

namespace TechnoTest.API.MapperProfiles
{
    public class MapperApiUserProfile : Profile
    {
        public MapperApiUserProfile() 
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserAddRequestDto, User>();
        }
    }
}
