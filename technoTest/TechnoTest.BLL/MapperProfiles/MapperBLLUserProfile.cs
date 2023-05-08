using AutoMapper;
using TechnoTest.BLL.Models;
using TechnoTest.DAL.Models;

namespace TechnoTest.BLL.MapperProfiles
{
    public class MapperBLLUserProfile : Profile
    {
        public MapperBLLUserProfile() 
        {
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
