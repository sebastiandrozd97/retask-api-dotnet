using System;
using System.Collections.Generic;
using Application.Workplaces;
using Domain;

namespace Application.Clients
{
  public class ClientDto
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<WorkplaceDto> Workplaces { get; set; }
  }
}