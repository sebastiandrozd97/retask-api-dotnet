using System;
using System.Collections.Generic;
using Domain;

namespace Application.Clients
{
  public class ClientDto
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Workplace> Workplaces { get; set; }
  }
}