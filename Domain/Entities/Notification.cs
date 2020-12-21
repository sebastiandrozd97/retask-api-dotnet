using System;

namespace Domain
{
  public class Notification
  {
    public Guid Id { get; set; }
    public string Action { get; set; }
    public DateTime Date { get; set; }
    public virtual AppUser Worker { get; set; }
    public virtual Workplace Workplace { get; set; }
  }
}