using AutoMapper;
using Domain;

namespace Application.Workplaces.Mappers
{
  public class WorkplaceProfile : Profile
  {
    public WorkplaceProfile()
    {
      CreateMap<Workplace, WorkplaceDto>()
        .ForMember(d => d.ClientFirstName, o => o.MapFrom(s => s.Client.FirstName))
        .ForMember(d => d.ClientLastName, o => o.MapFrom(s => s.Client.LastName));
    }
  }
}