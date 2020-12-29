using System;

namespace Application.Notifications
{
  public class NotificationDto
  {
    public Guid Id { get; set; }
    public string Action { get; set; }
    public DateTime Date { get; set; }
    public bool isSeen { get; set; }
    public string WorkerFirstName { get; set; }
    public string WorkerLastName { get; set; }
    public string Workplace { get; set; }
  }
}