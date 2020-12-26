using AutoMapper;
using Domain;

namespace Application.Workplaces.Mappers
{
  public class WorkplaceProfile : Profile
  {
    public WorkplaceProfile()
    {
      CreateMap<Workplace, WorkplaceDto>();
    }
  }
}