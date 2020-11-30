using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Employee>()
            .HasData
            (
              new Employee {Id = Guid.NewGuid(), FirstName = "Sebastian", LastName = "Drozd", Telephone = "638334112"},
              new Employee {Id = Guid.NewGuid(), FirstName = "Artur", LastName = "Płytkowy", Telephone = "698332444"},
              new Employee {Id = Guid.NewGuid(), FirstName = "Piotr", LastName = "Malowniczy", Telephone = "638334112"},
              new Employee {Id = Guid.NewGuid(), FirstName = "Kamil", LastName = "Fugowy", Telephone = "638334112"},
              new Employee {Id = Guid.NewGuid(), FirstName = "Karol", LastName = "Szpachlowy", Telephone = "638334112"}
            );
        }
    }
}
