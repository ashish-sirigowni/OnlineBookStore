using AutoMapper;
using OnlineBookStore.DTOs;
using OnlineBookStore.Entity;

namespace OnlineBookStore.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
