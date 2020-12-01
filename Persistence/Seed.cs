using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Persistence
{
  public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if(!context.Employees.Any())
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
