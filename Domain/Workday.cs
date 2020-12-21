using System;

namespace Domain
{
  public class Workday
  {
    public Guid Id { get; set; }
    public string Task { get; set; }
    public DateTime Date { get; set; }
    public string WorkingFrom { get; set; }
    public string WorkingTo { get; set; }
    public double Worktime { get; set; }
    public string AdditionalInfo { get; set; }
    public virtual AppUser Worker { get; set; }
    public virtual Workplace Workplace { get; set; }
  }
}
