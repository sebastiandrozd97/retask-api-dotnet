using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
  public class AppUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool isSupervisor { get; set; }
    public virtual ICollection<Workday> Workdays { get; set; }
  }
}