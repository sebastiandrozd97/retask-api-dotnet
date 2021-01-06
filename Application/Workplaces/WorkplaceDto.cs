using System;

namespace Application.Workplaces
{
  public class WorkplaceDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsOpen { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public Guid ClientId { get; set; }
    public string ClientFirstName { get; set; }
    public string ClientLastName { get; set; }
  }
}