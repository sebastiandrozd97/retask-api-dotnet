using AutoMapper;
using Domain;

namespace Application.Workdays.Mappers
{
  public class WorkdayProfile : Profile
  {
    public WorkdayProfile()
    {
      CreateMap<Workday, WorkdayDto>()
        .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Worker.FirstName))
        .ForMember(d => d.LastName, o => o.MapFrom(s => s.Worker.LastName));
    }
  }
}