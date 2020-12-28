using System;

namespace Application.WorkdayMaterials
{
  public class WorkdayMaterialDto
  {
    public Guid Id { get; set; }
    public string Item { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public string WorkerFirstName { get; set; }
    public string WorkerLastName { get; set; }
    public string Workplace { get; set; }
  }
}