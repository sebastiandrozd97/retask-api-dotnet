using AutoMapper;
using Domain;

namespace Application.Clients.Mappers
{
  public class ClientProfile : Profile
  {
    public ClientProfile()
    {
      CreateMap<Client, ClientDto>();
    }
  }
}