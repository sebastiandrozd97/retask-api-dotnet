using System;

namespace Application.Users
{
  public class User
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsSupervisor { get; set; }
    public bool IsHired { get; set; }
    public string Token { get; set; }
    public string UserName { get; set; }
  }
}