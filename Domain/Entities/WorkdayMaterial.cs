using System;

namespace Domain
{
  public class WorkdayMaterial
  {
    public Guid Id { get; set; }
    public string Item { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public virtual AppUser Worker { get; set; }
    public virtual Workplace Workplace { get; set; }
  }
}