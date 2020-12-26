using System;
using System.Collections.Generic;
using Domain;

namespace Application.Workplaces
{
  public class WorkplaceDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsOpen { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public ICollection<Workday> Workdays { get; set; }
    public ICollection<WorkdayMaterial> WorkdayMaterials { get; set; }
    public Client Client { get; set; }
  }
}