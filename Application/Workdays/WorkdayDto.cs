using System;

namespace Application.Workdays
{
  public class WorkdayDto
  {
    public Guid Id { get; set; }
    public string Task { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}