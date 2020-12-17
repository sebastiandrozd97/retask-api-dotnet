using System;

namespace Domain
{
  public class Workday
  {
    public Guid Id { get; set; }
    public string Task { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
  }
}
