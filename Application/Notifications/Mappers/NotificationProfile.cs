using AutoMapper;
using Domain;

namespace Application.Notifications.Mappers
{
  public class NotificationProfile : Profile
  {
    public NotificationProfile()
    {
      CreateMap<Notification, NotificationDto>()
        .ForMember(d => d.WorkerFirstName, o => o.MapFrom(s => s.Worker.FirstName))
        .ForMember(d => d.WorkerLastName, o => o.MapFrom(s => s.Worker.LastName))
        .ForMember(d => d.Workplace, o => o.MapFrom(s => s.Workplace.Name));
    }
  }
}