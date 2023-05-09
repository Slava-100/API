using AutoMapper;
using technoTest.API.Models.User.Request;
using technoTest.API.Models.User.Response;
using technoTest.API.Models.UserGroup.Response;
using technoTest.API.Models.UserState.Response;
using TechnoTest.BLL.Models;
using TechnoTest.DAL.Models;

namespace TechnoTest.API.MapperProfiles
{
    public class MapperApiUserProfile : Profile
    {
        public MapperApiUserProfile() 
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserAddRequestDto, User>();
            CreateMap<UserGroup, UserGroupResponseDto>();
            CreateMap<UserState, UserStateResponseDto>();
        }
    }
}
