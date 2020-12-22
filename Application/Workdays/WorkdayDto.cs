using System;

namespace Application.Workdays
{
  public class WorkdayDto
  {
    public Guid Id { get; set; }
    public string Task { get; set; }
    public DateTime Date { get; set; }
    public string WorkingFrom { get; set; }
    public string WorkingTo { get; set; }
    public double Worktime { get; set; }
    public string AdditionalInfo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Workplace { get; set; }
  }
}