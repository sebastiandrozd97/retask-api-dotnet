using System;
using System.Collections.Generic;

namespace Domain
{
  public class Client
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public virtual ICollection<Workplace> Workplaces { get; set; }
  }
}