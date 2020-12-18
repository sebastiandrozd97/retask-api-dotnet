using Application.User;
using AutoMapper;
using Domain;

namespace Application.Workdays
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Workday, WorkdayDto>()
        .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Worker.FirstName))
        .ForMember(d => d.LastName, o => o.MapFrom(s => s.Worker.LastName));
    }
  }
}