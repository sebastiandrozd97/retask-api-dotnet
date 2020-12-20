using System;

namespace Domain
{
  public class Notification
  {
    public static class ActionType
    {
      public const string Create = "create";
      public const string Update = "update";
      public const string Delete = "delete";
    }

    public Guid Id { get; set; }
    public string Action { get; set; }
    public virtual AppUser Worker { get; set; }
    public virtual Workplace Workplace { get; set; }
  }
}