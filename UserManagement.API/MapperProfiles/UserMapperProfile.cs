using AutoMapper;
using UserManagement.DAL.Models;
using UserManagement.ViewModels.User;

namespace UserManagement.API.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserAddModel>().ReverseMap();
            CreateMap<User, UserUpdateModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
