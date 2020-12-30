using System;

namespace Application.Users
{
  public class UserDto
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool isSupervisor { get; set; }
    public bool isHired { get; set; }
    public string UserName { get; set; }
  }
}