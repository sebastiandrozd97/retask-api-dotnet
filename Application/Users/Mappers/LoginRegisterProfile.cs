using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Application.Users.Mappers
{
  public class LoginRegisterProfile : Profile
  {
    private readonly IJwtGenerator _jwtGenerator;
    public LoginRegisterProfile(IJwtGenerator jwtGenerator)
    {
      _jwtGenerator = jwtGenerator;

      CreateMap<AppUser, User>()
        .ForMember(d => d.Token, o => o.MapFrom(s => _jwtGenerator.CreateToken(s)));
    }
  }
}