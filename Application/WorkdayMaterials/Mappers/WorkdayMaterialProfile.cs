using AutoMapper;
using Domain;

namespace Application.WorkdayMaterials.Mappers
{
  public class WorkdayMaterialProfile : Profile
  {
    public WorkdayMaterialProfile()
    {
      CreateMap<WorkdayMaterial, WorkdayMaterialDto>()
        .ForMember(d => d.WorkerFirstName, o => o.MapFrom(s => s.Worker.FirstName))
        .ForMember(d => d.WorkerLastName, o => o.MapFrom(s => s.Worker.LastName))
        .ForMember(d => d.Workplace, o => o.MapFrom(s => s.Workplace.Name));
    }
  }
}