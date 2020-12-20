using System;
using System.Collections.Generic;

namespace Domain
{
  public class Workplace
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsOpen { get; set; }
    public virtual ICollection<Workday> Workdays { get; set; }
    public virtual ICollection<WorkdayMaterial> WorkdayMaterials { get; set; }
    public virtual ICollection<Notification> Notifications { get; set; }
    public virtual Client Client { get; set; }
  }
}