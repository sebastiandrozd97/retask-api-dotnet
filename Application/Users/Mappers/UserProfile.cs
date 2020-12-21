using AutoMapper;
using Domain;

namespace Application.Users.Mappers
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<AppUser, UserDto>();
    }
  }
}