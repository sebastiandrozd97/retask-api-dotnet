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
            Email = "seba@test.com"
          },
          new AppUser
          {
            DisplayName = "Piotr",
            UserName = "piotr",
            Email = "piotr@test.com"
          },
          new AppUser
          {
            DisplayName = "Artur",
            UserName = "artur",
            Email = "artur@test.com"
          },
        };
        foreach (var user in users)
        {
          await userManager.CreateAsync(user, "Passw0rd!");
        }
      }

      if (!context.Employees.Any())
      {
        var employees = new List<Employee>
        {
        new Employee
        {
            FirstName = "Sebastian",
            LastName = "Drozd",
            Telephone = "638334112"
        },
        new Employee
        {
            FirstName = "Artur",
            LastName = "Płytkowy",
            Telephone = "698332444"
        },
        new Employee
        {
            FirstName = "Piotr",
            LastName = "Malowniczy",
            Telephone = "638334112"
        },
        new Employee
        {
            FirstName = "Kamil",
            LastName = "Fugowy",
            Telephone = "638334112"
        },
        new Employee
        {
            FirstName = "Karol",
            LastName = "Szpachlowy",
            Telephone = "638334112"
        },
        new Employee
        {
            FirstName = "Damian",
            LastName = "Randomowy",
            Telephone = "638334112"
        },
        new Employee
        {
            FirstName = "Marcin",
            LastName = "Książkowy",
            Telephone = "698332444"
        },
        new Employee
        {
            FirstName = "Mateusz",
            LastName = "Ścianowy",
            Telephone = "638334112"
        },
        new Employee
        {
            FirstName = "Paweł",
            LastName = "Doniczkowy",
            Telephone = "638334112"
        },
        new Employee
        {
            FirstName = "Krystian",
            LastName = "Biurkowy",
            Telephone = "638334112"
        }
        };

        context.Employees.AddRange(employees);
        context.SaveChanges();
      }
    }
  }
}
