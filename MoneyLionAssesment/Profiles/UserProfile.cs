using AutoMapper;
using MoneyLionAssesment.DTO.User;
using MoneyLionAssesment.Models;

namespace MoneyLionAssesment.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}
