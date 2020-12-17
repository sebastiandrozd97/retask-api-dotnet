using Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
    {
      if (!userManager.Users.Any())
      {
        var users = new List<AppUser>
        {
          new AppUser
          {
            DisplayName = "Seba",
            UserName = "seba",
            FirstName = "Sebastian",
            LastName = "Drozd",
            PhoneNumber = "673443112",
            isSupervisor = true,
            Email = "seba@test.com"
          },
          new AppUser
          {
            DisplayName = "Piotr",
            UserName = "piotr",
            FirstName = "Piotr",
            LastName = "Płytkowy",
            PhoneNumber = "775554666",
            isSupervisor = false,
            Email = "piotr@test.com"
          },
          new AppUser
          {
            DisplayName = "Artur",
            UserName = "artur",
            FirstName = "Artur",
            LastName = "Malowniczy",
            PhoneNumber = "884443454",
            isSupervisor = false,
            Email = "artur@test.com"
          },
        };
        foreach (var user in users)
        {
          await userManager.CreateAsync(user, "Passw0rd!");
        }
      }

      if (!context.Workdays.Any())
      {
        var workdays = new List<Workday>
        {
        new Workday
        {
            Task = "Malowanie, tapetowanie, fugowanie"
        },
        new Workday
        {
            Task = "Malowanie"
        },
        new Workday
        {
            Task = "Sprzątanie"
        },
        new Workday
        {
            Task = "Fugowanie"
        },
        new Workday
        {
            Task = "Szpachlowanie"
        },
        new Workday
        {
            Task = "Tapetowanie"
        },
        new Workday
        {
            Task = "Zamiatanie"
        },
        };

        context.Workdays.AddRange(workdays);
        context.SaveChanges();
      }
    }
  }
}
